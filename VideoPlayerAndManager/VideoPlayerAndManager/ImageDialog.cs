//图片缩略图类
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace VideoPlayerAndManager
{
    public partial class ImageDialog : Form
    {
        public ImageDialog()
        {
            InitializeComponent();
        }

        public void SetImage(string filename)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(SetImageIntern));
            thread.IsBackground = true;
            thread.Start(filename);
        }

        private void SetImageIntern(object filename)
        {
            this.imageViewer2.Image = Image.FromFile((string)filename);
            this.imageViewer2.Invalidate();
        }

        private void ImageDialog_Resize(object sender, EventArgs e)
        {
            this.imageViewer2.Invalidate();
        }

        private void imageViewer2_Load(object sender, EventArgs e)
        {

        }

        private void ImageDialog_Load(object sender, EventArgs e)
        {

        }

       

        private void ImageDialog_Load_1(object sender, EventArgs e)
        {
            
        }

       
    }
}