namespace VideoPlayerAndManager
{
    partial class ListDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListDetailForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.listNameText = new System.Windows.Forms.TextBox();
            this.addVideoButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addDocument = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移入或移出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加相关文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移入或移出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.18629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.81371F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listNameText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addVideoButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.addDocument, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(20, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "修改列表名称";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listNameText
            // 
            this.listNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.listNameText.Location = new System.Drawing.Point(181, 37);
            this.listNameText.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.listNameText.Name = "listNameText";
            this.listNameText.Size = new System.Drawing.Size(210, 25);
            this.listNameText.TabIndex = 1;
            // 
            // addVideoButton
            // 
            this.addVideoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addVideoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addVideoButton.BackgroundImage")));
            this.addVideoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addVideoButton.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addVideoButton.Location = new System.Drawing.Point(431, 30);
            this.addVideoButton.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.addVideoButton.Name = "addVideoButton";
            this.addVideoButton.Size = new System.Drawing.Size(181, 39);
            this.addVideoButton.TabIndex = 2;
            this.addVideoButton.Text = "添加视频";
            this.addVideoButton.UseVisualStyleBackColor = true;
            this.addVideoButton.Click += new System.EventHandler(this.addVideoButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(635, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(119, 94);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteButton.Location = new System.Drawing.Point(762, 29);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(167, 42);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "删除当前列表";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
            // 
            // addDocument
            // 
            this.addDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addDocument.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addDocument.BackgroundImage")));
            this.addDocument.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addDocument.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addDocument.Location = new System.Drawing.Point(944, 31);
            this.addDocument.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.addDocument.Name = "addDocument";
            this.addDocument.Size = new System.Drawing.Size(121, 38);
            this.addDocument.TabIndex = 5;
            this.addDocument.Text = "添加其他文件";
            this.addDocument.UseVisualStyleBackColor = true;
            this.addDocument.Click += new System.EventHandler(this.addDocument_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 100);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1075, 474);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(250, 147);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "pdf.jpg");
            this.imageList2.Images.SetKeyName(1, "ppt.jpg");
            this.imageList2.Images.SetKeyName(2, "doc.jpg");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移入或移出ToolStripMenuItem,
            this.添加相关文件ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 52);
            // 
            // 移入或移出ToolStripMenuItem
            // 
            this.移入或移出ToolStripMenuItem.Name = "移入或移出ToolStripMenuItem";
            this.移入或移出ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.移入或移出ToolStripMenuItem.Text = "移入或移出";
            this.移入或移出ToolStripMenuItem.Click += new System.EventHandler(this.移入或移出ToolStripMenuItem_Click);
            // 
            // 添加相关文件ToolStripMenuItem
            // 
            this.添加相关文件ToolStripMenuItem.Name = "添加相关文件ToolStripMenuItem";
            this.添加相关文件ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.添加相关文件ToolStripMenuItem.Text = "添加相关文件";
            this.添加相关文件ToolStripMenuItem.Click += new System.EventHandler(this.添加相关文件ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移入或移出ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(211, 56);
            // 
            // 移入或移出ToolStripMenuItem1
            // 
            this.移入或移出ToolStripMenuItem1.Name = "移入或移出ToolStripMenuItem1";
            this.移入或移出ToolStripMenuItem1.Size = new System.Drawing.Size(210, 24);
            this.移入或移出ToolStripMenuItem1.Text = "移入或移出";
            this.移入或移出ToolStripMenuItem1.Click += new System.EventHandler(this.移入或移出ToolStripMenuItem1_Click);
            // 
            // ListDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 574);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListDetailForm";
            this.Text = "ListDetailForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox listNameText;
        private System.Windows.Forms.Button addVideoButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addDocument;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 移入或移出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加相关文件ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 移入或移出ToolStripMenuItem1;
    }
}