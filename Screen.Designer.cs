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
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.loadButton = new System.Windows.Forms.Button();
			this.marchingTimer = new System.Windows.Forms.Timer(this.components);
			this.picturePanel = new System.Windows.Forms.Panel();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.cropButton = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.sizeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.picturePanel.SuspendLayout();
			this.buttonPanel.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(958, 629);
			this.pictureBox.TabIndex = 1;
			this.pictureBox.TabStop = false;
			this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Picture_Paint);
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseDown);
			this.pictureBox.MouseHover += new System.EventHandler(this.Picture_Hover);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseUp);
			// 
			// loadButton
			// 
			this.loadButton.Location = new System.Drawing.Point(4, 8);
			this.loadButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.loadButton.Name = "loadButton";
			this.loadButton.Size = new System.Drawing.Size(142, 40);
			this.loadButton.TabIndex = 4;
			this.loadButton.Text = "Load Image";
			this.loadButton.UseVisualStyleBackColor = true;
			this.loadButton.Click += new System.EventHandler(this.LoadImage_Click);
			// 
			// marchingTimer
			// 
			this.marchingTimer.Interval = 50;
			this.marchingTimer.Tick += new System.EventHandler(this.MarchingTimer_Tick);
			// 
			// picturePanel
			// 
			this.picturePanel.AutoScroll = true;
			this.picturePanel.AutoScrollMinSize = new System.Drawing.Size(300, 300);
			this.picturePanel.AutoSize = true;
			this.picturePanel.Controls.Add(this.pictureBox);
			this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picturePanel.Location = new System.Drawing.Point(0, 59);
			this.picturePanel.Name = "picturePanel";
			this.picturePanel.Size = new System.Drawing.Size(978, 649);
			this.picturePanel.TabIndex = 5;
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.cropButton);
			this.buttonPanel.Controls.Add(this.loadButton);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonPanel.Location = new System.Drawing.Point(0, 0);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(978, 59);
			this.buttonPanel.TabIndex = 6;
			// 
			// cropButton
			// 
			this.cropButton.Location = new System.Drawing.Point(153, 8);
			this.cropButton.Name = "cropButton";
			this.cropButton.Size = new System.Drawing.Size(142, 40);
			this.cropButton.TabIndex = 5;
			this.cropButton.Text = "Crop";
			this.cropButton.UseVisualStyleBackColor = true;
			this.cropButton.Click += new System.EventHandler(this.CropButton_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeStatusLabel,
            this.statusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 708);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(978, 36);
			this.statusStrip.TabIndex = 7;
			// 
			// sizeStatusLabel
			// 
			this.sizeStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.sizeStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sizeStatusLabel.Name = "sizeStatusLabel";
			this.sizeStatusLabel.Size = new System.Drawing.Size(181, 29);
			this.sizeStatusLabel.Text = "Image size: 100x100.";
			// 
			// statusLabel
			// 
			this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(543, 29);
			this.statusLabel.Text = "Selection top left: {x}, {y}. Bounding rectangle size: {width} x {height}.";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Screen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(978, 744);
			this.Controls.Add(this.picturePanel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.buttonPanel);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Screen";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.picturePanel.ResumeLayout(false);
			this.buttonPanel.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Timer marchingTimer;
		private System.Windows.Forms.Panel picturePanel;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Button cropButton;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.ToolStripStatusLabel sizeStatusLabel;
	}
}

