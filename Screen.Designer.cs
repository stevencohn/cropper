namespace Cropper
{
    partial class Screen
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
			this.components = new System.ComponentModel.Container();
			this.Picture = new System.Windows.Forms.PictureBox();
			this.LoadImage = new System.Windows.Forms.Button();
			this.AntTimer = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Picture
			// 
			this.Picture.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.Picture.Cursor = System.Windows.Forms.Cursors.Cross;
			this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Picture.Location = new System.Drawing.Point(10, 10);
			this.Picture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Picture.Name = "Picture";
			this.Picture.Size = new System.Drawing.Size(1104, 660);
			this.Picture.TabIndex = 1;
			this.Picture.TabStop = false;
			this.Picture.Paint += new System.Windows.Forms.PaintEventHandler(this.Picture_Paint);
			this.Picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
			this.Picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
			this.Picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseUp);
			// 
			// LoadImage
			// 
			this.LoadImage.Location = new System.Drawing.Point(4, 8);
			this.LoadImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.LoadImage.Name = "LoadImage";
			this.LoadImage.Size = new System.Drawing.Size(186, 40);
			this.LoadImage.TabIndex = 4;
			this.LoadImage.Text = "Load Image";
			this.LoadImage.UseVisualStyleBackColor = true;
			this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
			// 
			// AntTimer
			// 
			this.AntTimer.Interval = 50;
			this.AntTimer.Tick += new System.EventHandler(this.AntTimer_Tick);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.Picture);
			this.panel1.Location = new System.Drawing.Point(12, 77);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(1124, 680);
			this.panel1.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.LoadImage);
			this.panel2.Location = new System.Drawing.Point(12, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1124, 59);
			this.panel2.TabIndex = 6;
			// 
			// Screen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1148, 769);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Screen";
			((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.Timer AntTimer;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}

