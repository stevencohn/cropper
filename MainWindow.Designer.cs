namespace Cropper
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.loadButton = new System.Windows.Forms.Button();
			this.openButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// loadButton
			// 
			this.loadButton.Location = new System.Drawing.Point(32, 29);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new System.Drawing.Size(192, 23);
			this.loadButton.TabIndex = 0;
			this.loadButton.Text = "Choose image to load";
			this.loadButton.UseVisualStyleBackColor = true;
			this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
			// 
			// openButton
			// 
			this.openButton.Location = new System.Drawing.Point(32, 58);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(192, 23);
			this.openButton.TabIndex = 1;
			this.openButton.Text = "Open demo image";
			this.openButton.UseVisualStyleBackColor = true;
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(258, 111);
			this.Controls.Add(this.openButton);
			this.Controls.Add(this.loadButton);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cropper Demo";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.Button openButton;
	}
}