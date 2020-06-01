//图片缩略图类
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsThumbnailProvider;

namespace VideoPlayerAndManager
{
    public partial class ImageDialogMain : Form
    {
        public event ImageThumbnailEventHandler OnImageSizeChanged;

        private GetImageThumbnail Controller;

        private ImageDialog m_ImageDialog;

        private ImageViewer m_ActiveImageViewer;

        private int trackIndex = 0;//新增参数，防止未选择图片拉动调整大小控件报错

        private int ImageSize
        {
            get
            {
                return (64 * (this.trackBarSize.Value + 1));
            }
        }

        public ImageDialogMain()//构造函数
        {
            InitializeComponent();

            

            m_ImageDialog = new ImageDialog();

            m_AddImageDelegate = new DelegateAddImage(this.AddImage);

            Controller = new GetImageThumbnail();
            Controller.OnStart += new GetImageThumbnailEventHandler(m_Controller_OnStart);
            Controller.OnAdd += new GetImageThumbnailEventHandler(m_Controller_OnAdd);
            Controller.OnEnd += new GetImageThumbnailEventHandler(m_Controller_OnEnd);
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)//浏览图片按钮
        {
            this.AddFolder();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Controller.CancelScanning = true;
        }

        private void AddFolder()//添加扫描的文件夹
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = @"选择文件路径";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.flowLayoutPanelMain.Controls.Clear();
                Controller.AddFolder(dlg.SelectedPath);
               
             
            }
            trackIndex++;
        }

        private void m_Controller_OnStart(object sender, GetImageThumbnailEventArgs e)
        {

        }

        private void m_Controller_OnAdd(object sender, GetImageThumbnailEventArgs e)
        {
            this.AddImage(e.ImageFilename);
            this.Invalidate();
        }

        private void m_Controller_OnEnd(object sender, GetImageThumbnailEventArgs e)
        {
            
            if (this.InvokeRequired)
            {
                this.Invoke(new GetImageThumbnailEventHandler(m_Controller_OnEnd), sender, e);
            }
            else
            {
               
                this.button2.Enabled = true;
            }
        }

        delegate void DelegateAddImage(string imageFilename);
        private DelegateAddImage m_AddImageDelegate;

        private void AddImage(string imageFilename)
        {
            // thread safe
            if (this.InvokeRequired)
            {
                this.Invoke(m_AddImageDelegate, imageFilename);
            }
            else
            {
                int size = ImageSize;

                ImageViewer imageViewer = new ImageViewer();
                imageViewer.Dock = DockStyle.Bottom;
                imageViewer.LoadImage(imageFilename, 256, 256);
                imageViewer.Width = size;
                imageViewer.Height = size;
                imageViewer.IsThumbnail = true;
                imageViewer.MouseClick += new MouseEventHandler(imageViewer_MouseClick);

                this.OnImageSizeChanged += new ImageThumbnailEventHandler(imageViewer.ImageSizeChanged);

                this.flowLayoutPanelMain.Controls.Add(imageViewer);
            }
        }

        private void imageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (m_ActiveImageViewer != null)
            {
                m_ActiveImageViewer.IsActive = false;
            }

            m_ActiveImageViewer = (ImageViewer)sender;
            m_ActiveImageViewer.IsActive = true;

            if (m_ImageDialog.IsDisposed) m_ImageDialog = new ImageDialog();
            if (!m_ImageDialog.Visible) m_ImageDialog.Show();

            m_ImageDialog.SetImage(m_ActiveImageViewer.ImageLocation);
        }

        private void trackBarSize_ValueChanged(object sender, EventArgs e)
        {
            if (trackIndex == 0)
            {

            }
            else
            {
                this.OnImageSizeChanged(this, new ImageThumbnailEventArgs(ImageSize));//bug
                trackIndex++;
            }
           
        }

        private void flowLayoutPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ImageDialog_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.AddFolder();
        }

        private void flowLayoutPanelMain_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class ImageThumbnailEventArgs : EventArgs
    {
        public ImageThumbnailEventArgs(int size)
        {
            this.Size = size;
        }

        public int Size;
       
    }

    public delegate void ImageThumbnailEventHandler(object sender, ImageThumbnailEventArgs e);

}