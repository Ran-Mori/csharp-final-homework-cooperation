namespace VideoPlayerAndManager
{
    partial class ImageDialogMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDialogMain));
            this.button2 = new System.Windows.Forms.Button();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(76, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "选择文件夹\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBarSize
            // 
            this.trackBarSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSize.AutoSize = false;
            this.trackBarSize.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.trackBarSize.LargeChange = 1;
            this.trackBarSize.Location = new System.Drawing.Point(661, 14);
            this.trackBarSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackBarSize.Maximum = 2;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(165, 27);
            this.trackBarSize.TabIndex = 5;
            this.trackBarSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSize.Value = 1;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            this.trackBarSize.ValueChanged += new System.EventHandler(this.trackBarSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(495, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "缩略图大小控制滚轮";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.flowLayoutPanelMain);
            this.panelMain.Location = new System.Drawing.Point(0, 47);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(848, 540);
            this.panelMain.TabIndex = 4;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FloralWhite;
            this.flowLayoutPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelMain.CausesValidation = false;
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(848, 540);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMain_Paint);
            // 
            // ImageDialogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(849, 582);
            this.Controls.Add(this.trackBarSize);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ImageDialogMain";
            this.ShowIcon = false;
            this.Text = "浏览图片";
            this.Load += new System.EventHandler(this.ImageDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
    }
}