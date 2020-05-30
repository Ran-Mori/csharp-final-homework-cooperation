//获得图片缩略图类
using System;
using System.Drawing;
using System.Threading;
using System.IO;

namespace WindowsThumbnailProvider
{
    public class GetImageThumbnailEventArgs : EventArgs
    {
        public GetImageThumbnailEventArgs(string imageFilename)
        {
            this.ImageFilename = imageFilename;
        }

        public string ImageFilename;
    }

    public delegate void GetImageThumbnailEventHandler(object sender, GetImageThumbnailEventArgs e);

    public class GetImageThumbnail
    {
        private bool m_CancelScanning;
        static readonly object cancelScanningLock = new object();

        public bool CancelScanning
        {
            get
            {
                lock (cancelScanningLock)
                {
                    return m_CancelScanning;
                }
            }
            set
            {
                lock (cancelScanningLock)
                {
                    m_CancelScanning = value;
                }
            }
        }
        //开始、增加、结束事件
        public event GetImageThumbnailEventHandler OnStart;
        public event GetImageThumbnailEventHandler OnAdd;
        public event GetImageThumbnailEventHandler OnEnd;

        public GetImageThumbnail()
        {

        }

        //浏览选取文件夹
        public void AddFolder(string folderPath)
        {
            CancelScanning = false;

            Thread thread = new Thread(new ParameterizedThreadStart(AddFolder));
            thread.IsBackground = true;
            thread.Start(folderPath);
        }
        //浏览选取文件夹
        private void AddFolder(object folderPath)
        {
            string path = (string)folderPath;

            if (this.OnStart != null)
            {
                this.OnStart(this, new GetImageThumbnailEventArgs(null));
            }

            this.AddFolderIntern(path);

            if (this.OnEnd != null)
            {
                this.OnEnd(this, new GetImageThumbnailEventArgs(null));
            }

            CancelScanning = false;
        }

        private void AddFolderIntern(string folderPath)
        {
            if (CancelScanning) return;

            // not using AllDirectories
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                if (CancelScanning) break;

                Image img = null;

                try
                {
                    img = Image.FromFile(file);
                }
                catch
                {
                    
                }

                if (img != null)
                {
                    this.OnAdd(this, new GetImageThumbnailEventArgs(file));

                    img.Dispose();
                }
            }

           // 遍历文件夹
            string[] directories = Directory.GetDirectories(folderPath);
            foreach (string dir in directories)
            {
                if (CancelScanning) break;

                AddFolderIntern(dir);
            }
        }
    }
}
