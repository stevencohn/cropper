//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace Cropper
{
	using System;
	using System.Drawing;
	using System.IO;
	using System.Reflection;
	using System.Windows.Forms;


	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void loadButton_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				CropImage(dialog.FileName);
			}
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			CropImage(Path.Combine(path, "Lion.jpg"));
		}


		private void CropImage(string filename)
		{
			var image = Image.FromFile(filename);
			DialogResult result;

			using (var dialog = new CropImageDialog(image))
			{
				result = dialog.ShowDialog(this);
				if (result == DialogResult.OK)
				{
					image = dialog.Image;
				}
			}

			if (result == DialogResult.OK)
			{
				using (var dialog = new CropImageDialog(image))
				{
					dialog.ShowDialog(this);
				}
			}
		}
	}
}
