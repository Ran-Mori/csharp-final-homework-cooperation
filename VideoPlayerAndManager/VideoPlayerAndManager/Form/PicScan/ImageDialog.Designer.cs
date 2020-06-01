namespace VideoPlayerAndManager
{
    partial class ImageDialog
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
            this.imageViewer2 = new VideoPlayerAndManager.ImageViewer();
            this.SuspendLayout();
            // 
            // imageViewer2
            // 
            this.imageViewer2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.imageViewer2.BackColor = System.Drawing.SystemColors.Info;
            this.imageViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer2.Image = null;
            this.imageViewer2.ImageLocation = null;
            this.imageViewer2.IsActive = false;
            this.imageViewer2.IsThumbnail = false;
            this.imageViewer2.Location = new System.Drawing.Point(0, 0);
            this.imageViewer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.imageViewer2.Name = "imageViewer2";
            this.imageViewer2.Size = new System.Drawing.Size(587, 436);
            this.imageViewer2.TabIndex = 0;
            this.imageViewer2.Load += new System.EventHandler(this.imageViewer2_Load);
            // 
            // ImageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 436);
            this.Controls.Add(this.imageViewer2);
            this.Name = "ImageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ImageDialog";
            this.Load += new System.EventHandler(this.ImageDialog_Load);
            this.Resize += new System.EventHandler(this.ImageDialog_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        
        private ImageViewer imageViewer2;
    }
}