using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


//https://www.codeproject.com/articles/27748/marching-ants


namespace Cropper
{
	public partial class Screen : Form
	{
		private enum MoveState
		{
			None,
			Selecting,
			Moving,
			Sizing
		}
		private enum HandlePosition
		{
			TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left
		}
		private class SelectionHandle
		{
			public HandlePosition Position;
			public RectangleF Bounds;
		}

		private const int ImageTop = 8;
		private const int ImageLeft = 8;

		private Point startPoint;
		private Point endPoint;
		private Point movePoint;
		private Rectangle selectionBounds;
		private readonly Region selectionRegion;
		private readonly GraphicsPath selectionPath;
		private readonly Image background;

		private Image image;
		private Rectangle imageBounds;
		private SelectionHandle currentHandle;
		private readonly List<SelectionHandle> handles;

		private int antOffset;
		private MoveState moveState;

		public Screen()
		{
			InitializeComponent();

			selectionRegion = new Region();
			selectionRegion.MakeEmpty();
			selectionPath = new GraphicsPath();
			selectionPath.Reset();

			pictureBox.Image = background = new Bitmap(pictureBox.Width, pictureBox.Height);

			handles = new List<SelectionHandle>();
			moveState = MoveState.None;

			// temp
			LoadImage(@"C:\Github\OneMore\Screenshots\CodeBox.jpg");
		}

		private void LoadImage_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				LoadImage(dialog.FileName);
			}
		}

		private void LoadImage(string filename)
		{
			image = Image.FromFile(filename);
			imageBounds = new Rectangle(ImageLeft, ImageTop, image.Width, image.Height);

			picturePanel.AutoScrollMinSize = 
				new Size(imageBounds.Width + (ImageLeft * 2), imageBounds.Height + (ImageTop * 2));

			sizeStatusLabel.Text = $"Image size: {imageBounds.Width} x {imageBounds.Height}.";
			pictureBox.Refresh();
		}

		#region Paint
		private void Picture_Paint(object sender, PaintEventArgs e)
		{
			handles.Clear();

			e.Graphics.DrawImageUnscaled(background, 0, 0);

			if (image != null)
			{
				e.Graphics.DrawImageUnscaled(image, ImageLeft, ImageTop);
			}

			if (selectionRegion.IsEmpty(e.Graphics))
			{
				statusLabel.Text = string.Empty;
				return;
			}

			using (var fill = new SolidBrush(Color.FromArgb(40, 0, 138, 244)))
			{
				// fill for selecting region
				e.Graphics.FillRegion(fill, selectionRegion);
			}

			using (var pen = new Pen(Color.White, 1f))
			{
				pen.DashStyle = DashStyle.Dash;
				pen.DashPattern = new float[2] { 3, 3 };
				pen.DashOffset = antOffset;

				// set up pen for the ants
				using (var ant = new Bitmap(pictureBox.Width, pictureBox.Height))
				{
					using (var g = Graphics.FromImage(ant))
					{
						// region is magenta but we'll use that as our transparent color
						g.Clear(Color.Magenta);

						using (var outline = MakeOutlinePath())
						{
							g.DrawPath(Pens.Black, outline);
							g.DrawPath(pen, outline);
						}

						g.FillRegion(Brushes.Magenta, selectionRegion);
					}

					// make center of ant region transparent
					ant.MakeTransparent(Color.Magenta);

					// draw the ants on the image
					e.Graphics.DrawImageUnscaled(ant, 0, 0);
				}

				var bounds = selectionRegion.GetBounds(e.Graphics);

				AddHandle(HandlePosition.TopLeft, bounds.Left, bounds.Top, e.Graphics);
				AddHandle(HandlePosition.TopRight, bounds.Right, bounds.Top, e.Graphics);
				AddHandle(HandlePosition.BottomRight, bounds.Right, bounds.Bottom, e.Graphics);
				AddHandle(HandlePosition.BottomLeft, bounds.Left, bounds.Bottom, e.Graphics);

				AddHandle(HandlePosition.Top, bounds.Left + ((bounds.Right - bounds.Left) / 2), bounds.Top, e.Graphics);
				AddHandle(HandlePosition.Right, bounds.Right, bounds.Top + ((bounds.Bottom - bounds.Top) / 2), e.Graphics);
				AddHandle(HandlePosition.Bottom, bounds.Left + ((bounds.Right - bounds.Left) / 2), bounds.Bottom, e.Graphics);
				AddHandle(HandlePosition.Left, bounds.Left, bounds.Top + ((bounds.Bottom - bounds.Top) / 2), e.Graphics);
			}

			statusLabel.Text = 
				$"Selection top left: {selectionBounds.X - ImageLeft}, {selectionBounds.Y - ImageTop}. " +
				$"Bounding rectangle size: {selectionBounds.Width} x {selectionBounds.Height}.";
		}

		private void AddHandle(HandlePosition position, float x, float y, Graphics g)
		{
			var rectangle = new RectangleF(x - 3, y - 3, 6, 6);
			g.DrawArc(Pens.Black, rectangle.Left, rectangle.Top, 6, 6, 0, 360);

			rectangle.Inflate(6, 6);
			handles.Add(new SelectionHandle
			{
				Position = position,
				Bounds = rectangle
			});
		}

		private void SetSelection(Rectangle rectangle)
		{
			selectionRegion.MakeEmpty();
			selectionPath.Reset();

			if (!rectangle.IsEmpty)
			{
				selectionPath.AddRectangle(rectangle);
				selectionRegion.Union(selectionPath);
			}
		}

		public GraphicsPath MakeOutlinePath()
		{
			var path = new GraphicsPath();
			if (selectionPath.PointCount > 0)
			{
				path.AddPath(selectionPath, false);
				path.Widen(Pens.White);
			}
			return path;
		}
		#endregion Paint

		private void Picture_MouseDown(object sender, MouseEventArgs e)
		{
			if (image == null)
			{
				return;
			}

			// did we just grab a handle?
			if ((currentHandle = HitHandle(e.Location)) != null)
			{
				switch (currentHandle.Position)
				{
					case HandlePosition.Top:
					case HandlePosition.Left:
					case HandlePosition.TopLeft:
						startPoint.X = selectionBounds.Right;
						startPoint.Y = selectionBounds.Bottom;
						break;

					case HandlePosition.TopRight:
						startPoint.X = selectionBounds.Left;
						startPoint.Y = selectionBounds.Bottom;
						break;

					case HandlePosition.BottomLeft:
						startPoint.X = selectionBounds.Right;
						startPoint.Y = selectionBounds.Top;
						break;

					case HandlePosition.Bottom:
					case HandlePosition.Right:
					case HandlePosition.BottomRight:
						startPoint.X = selectionBounds.Left;
						startPoint.Y = selectionBounds.Top;
						break;
				}

				moveState = MoveState.Sizing;
				return;
			}

			if (selectionBounds.Contains(e.Location))
			{
				movePoint = e.Location;
				moveState = MoveState.Moving;
				return;
			}

			// else starting a new region
			if (imageBounds.Contains(e.Location))
			{
				startPoint.X = e.X;
				startPoint.Y = e.Y;
				selectionBounds = new Rectangle(e.X, e.Y, 0, 0);
			}
			else
			{
				startPoint.X = startPoint.Y = -1;
				selectionBounds = Rectangle.Empty;
			}

			SetSelection(Rectangle.Empty);

			if (!marchingTimer.Enabled)
			{
				marchingTimer.Start();
			}

			moveState = MoveState.Selecting;
		}

		private SelectionHandle HitHandle(Point location)
		{
			foreach (var handle in handles)
			{
				if (handle.Bounds.Contains(location))
				{
					return handle;
				}
			}

			return null;
		}

		private void Picture_MouseMove(object sender, MouseEventArgs e)
		{
			if (moveState == MoveState.Selecting)
			{
				SelectRegion(e.Location);
			}
			else if (moveState == MoveState.Sizing)
			{
				ResizeRegion(e.Location);
			}
			else if (moveState == MoveState.Moving)
			{
				MoveRegion(e.Location);
			}
			else
			{
				var handle = HitHandle(e.Location);
				if (handle != null)
				{
					switch (handle.Position)
					{
						case HandlePosition.Left:
						case HandlePosition.Right:
							pictureBox.Cursor = Cursors.SizeWE;
							break;

						case HandlePosition.Top:
						case HandlePosition.Bottom:
							pictureBox.Cursor = Cursors.SizeNS;
							break;

						case HandlePosition.TopLeft:
						case HandlePosition.BottomRight:
							pictureBox.Cursor = Cursors.SizeNWSE;
							break;


						case HandlePosition.TopRight:
						case HandlePosition.BottomLeft:
							pictureBox.Cursor = Cursors.SizeNESW;
							break;
					}
					return;
				}

				if (selectionBounds.Contains(e.Location))
				{
					pictureBox.Cursor = Cursors.SizeAll;
					return;
				}

				pictureBox.Cursor = Cursors.Cross;
			}
		}

		private void SelectRegion(Point location)
		{
			ConstrainLocation(ref location, imageBounds);

			// do we have an in-bounds start point yet?
			if (!imageBounds.Contains(startPoint))
			{
				startPoint.X = location.X;
				startPoint.Y = location.Y;
			}

			// new end point
			endPoint.X = location.X;
			endPoint.Y = location.Y;

			selectionBounds = new Rectangle(
					Math.Min(startPoint.X, endPoint.X),
					Math.Min(startPoint.Y, endPoint.Y),
					Math.Abs(startPoint.X - endPoint.X),
					Math.Abs(startPoint.Y - endPoint.Y)
					);

			SetSelection(selectionBounds);
			pictureBox.Refresh();
		}

		private void ResizeRegion(Point location)
		{
			ConstrainLocation(ref location, imageBounds);

			switch (currentHandle.Position)
			{
				case HandlePosition.Top:
					endPoint.X = selectionBounds.Left;
					endPoint.Y = location.Y;
					break;

				case HandlePosition.Right:
					endPoint.X = location.X;
					endPoint.Y = selectionBounds.Bottom;
					break;

				case HandlePosition.Bottom:
					endPoint.X = selectionBounds.Right;
					endPoint.Y = location.Y;
					break;

				case HandlePosition.Left:
					endPoint.X = location.X;
					endPoint.Y = selectionBounds.Top;
					break;

				case HandlePosition.TopLeft:
				case HandlePosition.TopRight:
				case HandlePosition.BottomLeft:
				case HandlePosition.BottomRight:
					endPoint.X = location.X;
					endPoint.Y = location.Y;
					break;
			}

			selectionBounds = new Rectangle(
					Math.Min(startPoint.X, endPoint.X),
					Math.Min(startPoint.Y, endPoint.Y),
					Math.Abs(startPoint.X - endPoint.X),
					Math.Abs(startPoint.Y - endPoint.Y)
					);

			SetSelection(selectionBounds);
			pictureBox.Refresh();
		}

		private void MoveRegion(Point location)
		{
			var s = new Point(startPoint.X, startPoint.Y);
			s.Offset(location.X - movePoint.X, location.Y - movePoint.Y);

			if (!imageBounds.Contains(s))
			{
				movePoint = location;
				ConstrainLocation(ref movePoint, selectionBounds);
				return;
			}

			var e = new Point(endPoint.X, endPoint.Y);
			e.Offset(location.X - movePoint.X, location.Y - movePoint.Y);

			if (!imageBounds.Contains(e))
			{
				movePoint = location;
				ConstrainLocation(ref movePoint, selectionBounds);
				return;
			}

			startPoint.X = s.X;
			startPoint.Y = s.Y;

			endPoint.X = e.X;
			endPoint.Y = e.Y;

			selectionBounds = new Rectangle(
				Math.Min(startPoint.X, endPoint.X),
				Math.Min(startPoint.Y, endPoint.Y),
				Math.Abs(startPoint.X - endPoint.X),
				Math.Abs(startPoint.Y - endPoint.Y)
				);

			SetSelection(selectionBounds);
			pictureBox.Refresh();

			movePoint = location;
		}

		private void ConstrainLocation(ref Point location, Rectangle bounds)
		{
			if (!imageBounds.Contains(location))
			{
				// force it into bounds
				if (location.X < bounds.Left)
				{
					location.X = bounds.Left;
				}
				else if (location.X > bounds.Right)
				{
					location.X = bounds.Right;
				}

				if (location.Y < bounds.Top)
				{
					location.Y = bounds.Top;
				}
				else if (location.Y > bounds.Bottom)
				{
					location.Y = bounds.Bottom;
				}
			}
		}

		private void Picture_MouseUp(object sender, MouseEventArgs e)
		{
			if (image == null)
			{
				return;
			}

			if (moveState == MoveState.Selecting)
			{
				if (imageBounds.Contains(e.Location))
				{
					endPoint.X = e.X;
					endPoint.Y = e.Y;
				}

				selectionBounds = new Rectangle(
					Math.Min(startPoint.X, endPoint.X),
					Math.Min(startPoint.Y, endPoint.Y),
					Math.Abs(startPoint.X - endPoint.X),
					Math.Abs(startPoint.Y - endPoint.Y)
					);

				SetSelection(selectionBounds);

				if (selectionBounds.IsEmpty)
				{
					marchingTimer.Stop();
				}

				pictureBox.Refresh();
			}

			moveState = MoveState.None;
		}

		private void MarchingTimer_Tick(object sender, EventArgs e)
		{
			antOffset--;
			antOffset %= 6;
			pictureBox.Refresh();
		}

		private void CropButton_Click(object sender, EventArgs e)
		{
			if (selectionBounds.IsEmpty)
			{
				return;
			}

			var crop = new Bitmap(selectionBounds.Width, selectionBounds.Height);
			using (var g = Graphics.FromImage(crop))
			{
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.CompositingQuality = CompositingQuality.HighQuality;

				selectionBounds.Offset(-ImageLeft, -ImageTop);

				g.DrawImage(image, 0, 0, selectionBounds, GraphicsUnit.Pixel);

				image = crop;
			}

			moveState = MoveState.None;

			SetSelection(Rectangle.Empty);
			startPoint.X = startPoint.Y = -1;
			selectionBounds = Rectangle.Empty;
			handles.Clear();
			marchingTimer.Stop();

			pictureBox.Refresh();
		}

		private void Picture_Hover(object sender, EventArgs e)
		{
			pictureBox.Focus();
		}
	}
}
