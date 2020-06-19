using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using DBInterface;
//using System.Runtime.InteropServices;

namespace VideoPlayerAndManager
{
    public partial class PlayerForm : Form
    {
        public event Action<string> AddtoLike;

        private playMode mode=playMode.Sequence;

        private Video currentMovie = null;

        private VideoService service = new VideoService();

        private List<Video> movieList = new List<Video>();//电影类

        //不同的构造函数可以调用
        public PlayerForm()
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public PlayerForm(Video movie, List<Video> movies,ImageList.ImageCollection imgs)
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.ItemHeight = 50;
            currentMovie = movie;
            movieList = movies;
            foreach (Image i in imgs) {
                imageList1.Images.Add(i);
            }
            foreach (Video one in movies)
            {
                listBox1.Items.Add(one.name);
            }
            try
            {
                axWindowsMediaPlayer1.URL = currentMovie.url;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = service.GetPlayedTime(currentMovie.url);
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch
            {
                MessageBox.Show("播放失败");
            }
        }

        public PlayerForm(Video movie)
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            currentMovie = movie;
            foreach (Video one in movieList)
            {
                listBox1.Items.Add(one.name);
            }
            try
            {
                axWindowsMediaPlayer1.URL = currentMovie.url;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = service.GetPlayedTime(currentMovie.url);
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch
            {
                MessageBox.Show("播放失败");
            }
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (!axWindowsMediaPlayer1.fullScreen)
                {
                    axWindowsMediaPlayer1.fullScreen = true;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "mp4文件|*.mp4|mkv文件|*.mkv|avi文件|*。avi";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string url = openFileDialog1.FileName;
                axWindowsMediaPlayer1.URL = url;
                try
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    currentMovie = new Video(fileName, openFileDialog1.FileName);
                    if (!listBox1.Items.Contains(openFileDialog1.SafeFileName))
                    {
                        Bitmap bm = WindowsThumbnailProvider.GetThumbnail(url, 256, 256, ThumbnailOptions.None);
                        Image img = Image.FromHbitmap(bm.GetHbitmap());
                        imageList1.Images.Add(img);
                        listBox1.Items.Add(fileName);
                        movieList.Add(currentMovie);
                    }
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                catch
                {
                    MessageBox.Show("播放失败");
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //service.UpdatePlayedTime(currentMovie.url, axWindowsMediaPlayer1.Ctlcontrols.currentPosition + "");
            this.Close();
        }

        
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddtoLike(currentMovie.url);
            MessageBox.Show("添加成功");
        }

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest,    //目标DC的句柄
            int nXDest,        //目标DC的矩形区域的左上角的x坐标
            int nYDest,        //目标DC的矩形区域的左上角的y坐标
            int nWidth,        //目标DC的句型区域的宽度值
            int nHeight,       //目标DC的句型区域的高度值
            IntPtr hdcSrc,     //源DC的句
            int nXSrc,         //源DC的矩形区域的左上角的x坐标
            int nYSrc,         //源DC的矩形区域的左上角的y坐标
            System.Int32 dwRo  //光栅的处理数值
        );

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static IntPtr GetDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public extern static int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private void 视频截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(axWindowsMediaPlayer1.Width, axWindowsMediaPlayer1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(PointToScreen(new Point(axWindowsMediaPlayer1.Left, axWindowsMediaPlayer1.Top)), new Point(0, 0), bmp.Size);
                g.Dispose();
            }
            saveFileDialog1.Filter = "jpeg文件|*.jpeg|png文件|*.png|bmp文件|*.bmp";
            //保存对话框是否记忆上次打开的目录
            saveFileDialog1.RestoreDirectory = true;
            //点了保存按钮进入
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = saveFileDialog1.FileName.ToString();
                bmp.Save(localFilePath);
            }
        }

            //绘制listbox的项
            private void listBox1_DrawItem_1(object sender, DrawItemEventArgs e)
        {
           
            Brush myBrush = Brushes.Black;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                myBrush = new SolidBrush(Color.CornflowerBlue);
            }
            else if (e.Index % 2 == 0)
            {
                myBrush = new SolidBrush(Color.CornflowerBlue);
            }
            else
            {
                myBrush = new SolidBrush(Color.White);
            }
            e.Graphics.FillRectangle(myBrush, e.Bounds);
            e.DrawFocusRectangle();//焦点框 

            //绘制图标 
            Image image = imageList1.Images[imageList1.Images.Count-1-e.Index];
            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;
            Rectangle imageRect = new Rectangle(
            bounds.X,
            bounds.Y,
            bounds.Height,
            bounds.Height);
            Rectangle textRect = new Rectangle(
            imageRect.Right,
            bounds.Y,
            bounds.Width - imageRect.Right,
            bounds.Height);

            if (image != null)
            {
                g.DrawImage(
                image,
                imageRect,
                0,
                0,
                image.Width,
                image.Height,
                GraphicsUnit.Pixel);
            }

            //文本 
            StringFormat strFormat = new StringFormat();
            //strFormat.Alignment = StringAlignment.Center; 
            strFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), textRect, strFormat);

        }

        //中文切换，读取中国版本的资源,还没改
        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            ResourceManager rm = new ResourceManager(typeof(PlayerForm));
            this.Text= rm.GetString("$this.Text");
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Text = rm.GetString(item.Name + ".Text");
                if (item.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem dropitem in item.DropDownItems)
                    {
                        dropitem.Text = rm.GetString(dropitem.Name + ".Text");
                        if (dropitem.HasDropDownItems)
                        {
                            foreach (ToolStripMenuItem detailitem in dropitem.DropDownItems)
                            {
                                detailitem.Text = rm.GetString(detailitem.Name + ".Text");
                            }
                        }
                    }
                }
            }
            label1.Text= rm.GetString("label1.Text");
            label2.Text = rm.GetString("label2.Text");
            label3.Text = rm.GetString("label3.Text");
            label4.Text = rm.GetString("label4.Text");
            label5.Text = rm.GetString("label7.Text");
            label6.Text = rm.GetString("label8.Text");
            tabPage1.Text= rm.GetString("tabPage1.Text");
            tabPage2.Text = rm.GetString("tabPage2.Text");
        }


        //英文切换，读取英国版本的资源
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            ResourceManager rm = new ResourceManager(typeof(PlayerForm));
            this.Text = rm.GetString("$this.Text");
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Text = rm.GetString(item.Name + ".Text");
                if (item.HasDropDownItems)
                {
                    foreach (ToolStripMenuItem dropitem in item.DropDownItems)
                    {
                        dropitem.Text = rm.GetString(dropitem.Name + ".Text");
                        if (dropitem.HasDropDownItems)
                        {
                            foreach (ToolStripMenuItem detailitem in dropitem.DropDownItems)
                            {
                                detailitem.Text = rm.GetString(detailitem.Name + ".Text");
                            }
                        }
                    }
                }
            }
                    label1.Text = rm.GetString("label1.Text");
                    label2.Text = rm.GetString("label2.Text");
                    label3.Text = rm.GetString("label3.Text");
                    label4.Text = rm.GetString("label4.Text");
                    label5.Text = rm.GetString("label7.Text");
                    label6.Text = rm.GetString("label8.Text");
                    tabPage1.Text = rm.GetString("tabPage1.Text");
                    tabPage2.Text = rm.GetString("tabPage2.Text");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                axWindowsMediaPlayer1.URL = movieList[listBox1.SelectedIndex].url;
                try
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    currentMovie = movieList[listBox1.SelectedIndex];
                }
                catch {
                    MessageBox.Show("播放失败");
                }
            }
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMovie.name != "")
            {
                string name = axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");
                string length = axWindowsMediaPlayer1.currentMedia.getItemInfo("Duration");
                string url = axWindowsMediaPlayer1.currentMedia.getItemInfo("sourceURL");
                InformationForm informationForm = new InformationForm(name, length, url, this.skinEngine1.SkinFile);
                informationForm.ShowDialog();
            }
        }


        private void getPath()
        {

            switch (mode)
            {
                case playMode.Sequence:
                    int length1 = listBox1.Items.Count;
                    int num1 = 0;
                    for (int i = 0; i < length1; i++)
                    {
                        if (listBox1.Items[i].Equals(currentMovie.name))
                        {
                            num1 = i;
                        }
                    }
                    currentMovie = movieList[(num1 + 1) % length1];
                    axWindowsMediaPlayer1.URL = movieList[(num1 + 1) % length1].url;
                    break;
                case playMode.Random:
                    int length = movieList.Count;
                    Random rd = new Random();
                    int num2 = rd.Next(0, length);
                    currentMovie = movieList[num2];
                    axWindowsMediaPlayer1.URL = movieList[num2].url;
                    break;
                case playMode.Self:
                    int length3 = listBox1.Items.Count;
                    int num3 = 0;
                    for (int i = 0; i < length3; i++)
                    {
                        if (listBox1.Items[i].Equals(currentMovie.name))
                        {
                            num3 = i;
                        }
                    }
                    currentMovie = movieList[num3];
                    axWindowsMediaPlayer1.URL = movieList[num3].url;
                    break;
            }
        }
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                service.UpdatePlayedTime(currentMovie.url, axWindowsMediaPlayer1.Ctlcontrols.currentPosition + "");
                getPath();
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                label2.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("Title");
                label4.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("Duration");
                label6.Text = axWindowsMediaPlayer1.currentMedia.getItemInfo("sourceURL");
            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            getPath();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMovie != null) {
                string url = currentMovie.url;
                System.IO.FileInfo file = new System.IO.FileInfo(url);
                string v_OpenFolderPath = file.DirectoryName; 
                System.Diagnostics.Process.Start("explorer.exe", v_OpenFolderPath);
            }
        }

        private void speedToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in 倍速ToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
                if (item.Name == e.ClickedItem.Name) {
                    item.Checked = true;
                    switch (e.ClickedItem.Name)
                    {
                        case "toolStripMenuItem1":
                            axWindowsMediaPlayer1.settings.rate = 1;
                            break;
                        case "toolStripMenuItem2":
                            axWindowsMediaPlayer1.settings.rate = 1.25;
                            break;
                        case "toolStripMenuItem3":
                            axWindowsMediaPlayer1.settings.rate = 1.5;
                            break;
                        case "toolStripMenuItem4":
                            axWindowsMediaPlayer1.settings.rate = 1.75;
                            break;
                        case "toolStripMenuItem5":
                            axWindowsMediaPlayer1.settings.rate = 2.0;
                            break;
                        case "toolStripMenuItem6":
                            SpeedForm s = new SpeedForm(this.skinEngine1.SkinFile);
                            if (s.ShowDialog() == DialogResult.OK)
                            {
                                axWindowsMediaPlayer1.settings.rate = s.getValue();
                            }
                            break;
                    }
                }
            }
            
        }

        private void languageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
                if (item.Text == e.ClickedItem.Text)
                {
                    item.Checked = true;
                }
            }
        }

        private void playmodeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in playmodeToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
                if (item.Text == e.ClickedItem.Text)
                {
                    item.Checked = true;
                }
            }
        }

        private void skinToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripMenuItem item in skinToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
                if (item.Name == e.ClickedItem.Name)
                {
                    item.Checked = true;
                    if (skinEngine1.Active == false)
                    {
                        skinEngine1.Active = true;
                    }
                    switch (e.ClickedItem.Name) {
                        case "originToolStripMenuItem":
                            skinEngine1.Active = false;
                            break;
                        case "blueToolStripMenuItem":
                            skinEngine1.SkinFile= "DiamondBlue.ssk"; 
                            break;
                        case "orangeToolStripMenuItem":
                            skinEngine1.SkinFile = "GlassOrange.ssk"; ; 
                            break;
                        case "silverToolStripMenuItem":
                            skinEngine1.SkinFile = "XPSliver.ssk" ;
                            break;
                    }
                }
            }
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.UpdatePlayedTime(currentMovie.url, axWindowsMediaPlayer1.Ctlcontrols.currentPosition+"");
            this.Hide();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            listBox1.ItemHeight = 50;
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.UpdatePlayedTime(currentMovie.url, axWindowsMediaPlayer1.Ctlcontrols.currentPosition + "");
        }
    }

    public enum playMode { Sequence, Random , Self};


    public class Video
    {
        public string name { get; set; }

        public string url { get; set; }

        public Video(string name, string url)
        {
            this.name = name;
            this.url = url;
        }
    }
}
