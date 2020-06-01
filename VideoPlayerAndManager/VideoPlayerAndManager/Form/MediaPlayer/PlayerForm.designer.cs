namespace MoviePlayer
{
    partial class PlayerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一个ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语言ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.倍速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外观ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.皮肤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.原皮肤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.浅橘色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.钻石蓝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.炫酷银ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视频截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顺序播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.随机播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.循环播放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem_1);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.外观ToolStripMenuItem,
            this.录制ToolStripMenuItem,
            this.模式ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.收藏ToolStripMenuItem,
            this.信息ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.下一个ToolStripMenuItem,
            this.打开文件夹ToolStripMenuItem,
            this.管理器ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            // 
            // 打开ToolStripMenuItem
            // 
            resources.ApplyResources(this.打开ToolStripMenuItem, "打开ToolStripMenuItem");
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 收藏ToolStripMenuItem
            // 
            resources.ApplyResources(this.收藏ToolStripMenuItem, "收藏ToolStripMenuItem");
            this.收藏ToolStripMenuItem.Name = "收藏ToolStripMenuItem";
            this.收藏ToolStripMenuItem.Click += new System.EventHandler(this.收藏ToolStripMenuItem_Click);
            // 
            // 信息ToolStripMenuItem
            // 
            resources.ApplyResources(this.信息ToolStripMenuItem, "信息ToolStripMenuItem");
            this.信息ToolStripMenuItem.Name = "信息ToolStripMenuItem";
            this.信息ToolStripMenuItem.Click += new System.EventHandler(this.信息ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            resources.ApplyResources(this.关闭ToolStripMenuItem, "关闭ToolStripMenuItem");
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 下一个ToolStripMenuItem
            // 
            resources.ApplyResources(this.下一个ToolStripMenuItem, "下一个ToolStripMenuItem");
            this.下一个ToolStripMenuItem.Name = "下一个ToolStripMenuItem";
            this.下一个ToolStripMenuItem.Click += new System.EventHandler(this.下一个ToolStripMenuItem_Click);
            // 
            // 打开文件夹ToolStripMenuItem
            // 
            resources.ApplyResources(this.打开文件夹ToolStripMenuItem, "打开文件夹ToolStripMenuItem");
            this.打开文件夹ToolStripMenuItem.Name = "打开文件夹ToolStripMenuItem";
            this.打开文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开文件夹ToolStripMenuItem_Click);
            // 
            // 管理器ToolStripMenuItem
            // 
            resources.ApplyResources(this.管理器ToolStripMenuItem, "管理器ToolStripMenuItem");
            this.管理器ToolStripMenuItem.Name = "管理器ToolStripMenuItem";
            // 
            // 显示ToolStripMenuItem
            // 
            resources.ApplyResources(this.显示ToolStripMenuItem, "显示ToolStripMenuItem");
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全屏ToolStripMenuItem,
            this.语言ToolStripMenuItem,
            this.倍速ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            // 
            // 全屏ToolStripMenuItem
            // 
            resources.ApplyResources(this.全屏ToolStripMenuItem, "全屏ToolStripMenuItem");
            this.全屏ToolStripMenuItem.Name = "全屏ToolStripMenuItem";
            this.全屏ToolStripMenuItem.Click += new System.EventHandler(this.全屏ToolStripMenuItem_Click);
            // 
            // 语言ToolStripMenuItem
            // 
            resources.ApplyResources(this.语言ToolStripMenuItem, "语言ToolStripMenuItem");
            this.语言ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中文ToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.语言ToolStripMenuItem.Name = "语言ToolStripMenuItem";
            this.语言ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.语言ToolStripMenuItem_DropDownItemClicked);
            // 
            // 中文ToolStripMenuItem
            // 
            resources.ApplyResources(this.中文ToolStripMenuItem, "中文ToolStripMenuItem");
            this.中文ToolStripMenuItem.Checked = true;
            this.中文ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            this.中文ToolStripMenuItem.Click += new System.EventHandler(this.中文ToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // 倍速ToolStripMenuItem
            // 
            resources.ApplyResources(this.倍速ToolStripMenuItem, "倍速ToolStripMenuItem");
            this.倍速ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.自定义ToolStripMenuItem});
            this.倍速ToolStripMenuItem.Name = "倍速ToolStripMenuItem";
            this.倍速ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.倍速ToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Checked = true;
            this.toolStripMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // 自定义ToolStripMenuItem
            // 
            resources.ApplyResources(this.自定义ToolStripMenuItem, "自定义ToolStripMenuItem");
            this.自定义ToolStripMenuItem.Name = "自定义ToolStripMenuItem";
            this.自定义ToolStripMenuItem.Click += new System.EventHandler(this.自定义ToolStripMenuItem_Click);
            // 
            // 外观ToolStripMenuItem
            // 
            resources.ApplyResources(this.外观ToolStripMenuItem, "外观ToolStripMenuItem");
            this.外观ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.皮肤ToolStripMenuItem});
            this.外观ToolStripMenuItem.Name = "外观ToolStripMenuItem";
            // 
            // 皮肤ToolStripMenuItem
            // 
            resources.ApplyResources(this.皮肤ToolStripMenuItem, "皮肤ToolStripMenuItem");
            this.皮肤ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.原皮肤ToolStripMenuItem,
            this.浅橘色ToolStripMenuItem,
            this.钻石蓝ToolStripMenuItem,
            this.炫酷银ToolStripMenuItem});
            this.皮肤ToolStripMenuItem.Name = "皮肤ToolStripMenuItem";
            this.皮肤ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.皮肤ToolStripMenuItem_DropDownItemClicked);
            // 
            // 原皮肤ToolStripMenuItem
            // 
            resources.ApplyResources(this.原皮肤ToolStripMenuItem, "原皮肤ToolStripMenuItem");
            this.原皮肤ToolStripMenuItem.Checked = true;
            this.原皮肤ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.原皮肤ToolStripMenuItem.Name = "原皮肤ToolStripMenuItem";
            this.原皮肤ToolStripMenuItem.Click += new System.EventHandler(this.原皮肤ToolStripMenuItem_Click);
            // 
            // 浅橘色ToolStripMenuItem
            // 
            resources.ApplyResources(this.浅橘色ToolStripMenuItem, "浅橘色ToolStripMenuItem");
            this.浅橘色ToolStripMenuItem.Name = "浅橘色ToolStripMenuItem";
            this.浅橘色ToolStripMenuItem.Click += new System.EventHandler(this.浅橘色ToolStripMenuItem_Click);
            // 
            // 钻石蓝ToolStripMenuItem
            // 
            resources.ApplyResources(this.钻石蓝ToolStripMenuItem, "钻石蓝ToolStripMenuItem");
            this.钻石蓝ToolStripMenuItem.Name = "钻石蓝ToolStripMenuItem";
            this.钻石蓝ToolStripMenuItem.Click += new System.EventHandler(this.钻石蓝ToolStripMenuItem_Click);
            // 
            // 炫酷银ToolStripMenuItem
            // 
            resources.ApplyResources(this.炫酷银ToolStripMenuItem, "炫酷银ToolStripMenuItem");
            this.炫酷银ToolStripMenuItem.Name = "炫酷银ToolStripMenuItem";
            this.炫酷银ToolStripMenuItem.Click += new System.EventHandler(this.炫酷银ToolStripMenuItem_Click);
            // 
            // 录制ToolStripMenuItem
            // 
            resources.ApplyResources(this.录制ToolStripMenuItem, "录制ToolStripMenuItem");
            this.录制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视频截图ToolStripMenuItem});
            this.录制ToolStripMenuItem.Name = "录制ToolStripMenuItem";
            // 
            // 视频截图ToolStripMenuItem
            // 
            resources.ApplyResources(this.视频截图ToolStripMenuItem, "视频截图ToolStripMenuItem");
            this.视频截图ToolStripMenuItem.Name = "视频截图ToolStripMenuItem";
            this.视频截图ToolStripMenuItem.Click += new System.EventHandler(this.视频截图ToolStripMenuItem_Click);
            // 
            // 模式ToolStripMenuItem
            // 
            resources.ApplyResources(this.模式ToolStripMenuItem, "模式ToolStripMenuItem");
            this.模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顺序播放ToolStripMenuItem,
            this.随机播放ToolStripMenuItem,
            this.循环播放ToolStripMenuItem});
            this.模式ToolStripMenuItem.Name = "模式ToolStripMenuItem";
            this.模式ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.模式ToolStripMenuItem_DropDownItemClicked);
            // 
            // 顺序播放ToolStripMenuItem
            // 
            resources.ApplyResources(this.顺序播放ToolStripMenuItem, "顺序播放ToolStripMenuItem");
            this.顺序播放ToolStripMenuItem.Checked = true;
            this.顺序播放ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.顺序播放ToolStripMenuItem.Name = "顺序播放ToolStripMenuItem";
            this.顺序播放ToolStripMenuItem.Click += new System.EventHandler(this.顺序播放ToolStripMenuItem_Click);
            // 
            // 随机播放ToolStripMenuItem
            // 
            resources.ApplyResources(this.随机播放ToolStripMenuItem, "随机播放ToolStripMenuItem");
            this.随机播放ToolStripMenuItem.Name = "随机播放ToolStripMenuItem";
            this.随机播放ToolStripMenuItem.Click += new System.EventHandler(this.随机播放ToolStripMenuItem_Click);
            // 
            // 循环播放ToolStripMenuItem
            // 
            resources.ApplyResources(this.循环播放ToolStripMenuItem, "循环播放ToolStripMenuItem");
            this.循环播放ToolStripMenuItem.Name = "循环播放ToolStripMenuItem";
            this.循环播放ToolStripMenuItem.Click += new System.EventHandler(this.循环播放ToolStripMenuItem_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label6);
            this.panel2.Name = "panel2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.LightCoral;
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.NavajoWhite;
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.LightCoral;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.NavajoWhite;
            this.label2.Name = "label2";
            // 
            // axWindowsMediaPlayer1
            // 
            resources.ApplyResources(this.axWindowsMediaPlayer1, "axWindowsMediaPlayer1");
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // PlayerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayerForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收藏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 语言ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 倍速ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外观ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 皮肤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视频截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem 自定义ToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 浅橘色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 钻石蓝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 炫酷银ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 顺序播放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 随机播放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 循环播放ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 管理器ToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ToolStripMenuItem 下一个ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 原皮肤ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
    }
}

