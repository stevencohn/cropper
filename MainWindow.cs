//************************************************************************************************
// Copyright © 2020 Steven M Cohn.  All rights reserved.
//************************************************************************************************

namespace Cropper
{
	using System;
	using System.Drawing;
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
			CropImage(@"\Github\OneMore\Screenshots\CodeBox.jpg");
		}


		private void CropImage(string filename)
		{
			var image = Image.FromFile(filename);

			using (var dialog = new ImageCropDialog(image))
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
				}
			}
		}
	}
}
