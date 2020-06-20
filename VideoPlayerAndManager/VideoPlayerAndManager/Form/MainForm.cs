using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBInterface;

namespace VideoPlayerAndManager
{
    public partial class MainForm : Form
    {
        public string KeyWord { get; set; }//输入的搜索内容
        public string Path { get; set; }//扫描的路径

        VideoService service = new VideoService();
        List<string> videoNames;

        private BackgroundWorker backgroundWorker1 = null;

        public MainForm()
        {
            InitializeComponent();            
            InitListView();
            InitListBoxItem();
            InitBackgroundWorker();

            textBox1.DataBindings.Add("Text", this, "KeyWord");

            videoNames = service.GetAllVideos();
            ListViewUpdate(videoNames);
        }

        //初始化listBox
        private void InitListBoxItem()
        {
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.DrawItem += ListBox1_DrawItem;
            listBox1.MeasureItem += ListBox1_MeasureItem;
            listBox1.Items.Add("全部视频");
            listBox1.Items.Add("收藏夹");
            listBox1.Items.Add("最近播放");//始终存在所以直接添加
            List<string> lists = service.GetVideoList();
            foreach (string list in lists)
            {
                listBox1.Items.Add(list);
            }
        }

        //初始化ListView
        private void InitListView()
        {
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList1;
        }

        //初始化BackgroundWorker
        private void InitBackgroundWorker()
        {
            backgroundWorker1 = new BackgroundWorker();
            //设置报告进度更新
            backgroundWorker1.WorkerReportsProgress = true;
            //注册线程主体方法
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            //注册更新UI方法
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            //注册线程结束后方法
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bgWorker_WorkerCompleted);
        }

        //异步实现视频缩略图的获取和主界面listview的刷新
        //--------------------------------------------------------------------------
        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //...执行线程任务                        
            List<string> imageNames = service.GetAllVideos();
            int pic_size = 256;
            for (int i = imageNames.Count - 1; i >= 0; i--)
            {                
                if (!File.Exists(imageNames[i]))
                {
                    service.RemoveFlie(imageNames[i]);
                    imageNames.Remove(imageNames[i]);
                    continue;
                }
                Bitmap bm = WindowsThumbnailProvider.GetThumbnail(imageNames[i], pic_size, pic_size, ThumbnailOptions.None);
                Image img = Image.FromHbitmap(bm.GetHbitmap());
                //在线程中更新UI（通过ReportProgress方法）
                backgroundWorker1.ReportProgress((1-i/imageNames.Count)*100, img);               
            }
        }
        public void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = e.ProgressPercentage;
            Image img = (Image)e.UserState;
            imageList1.Images.Add(img);
        }

        public void bgWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            List<string> imageNames = service.GetAllVideos();
            for (int i = imageNames.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = imageNames.Count - 1 - i;
                lvi.Name = imageNames[i];
                lvi.Text = System.IO.Path.GetFileNameWithoutExtension(imageNames[i]);
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }
        //----------------------------------------------------------------------------------
     
        private void ListViewUpdate(List<string> imageNames)//更新listview中的内容
        {
            imageList1.Images.Clear();
            listView1.Clear();
            int pgbSpeed = 0;
            if(imageNames.Count != 0)
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                pgbSpeed = 100 / imageNames.Count;
            }

            int pic_size = 256;
            for (int i = imageNames.Count - 1; i >= 0; i--)
            {
                if (!File.Exists(imageNames[i]))
                {
                    service.RemoveFlie(imageNames[i]);
                    imageNames.Remove(imageNames[i]);
                    continue;
                }
                Bitmap bm = WindowsThumbnailProvider.GetThumbnail(imageNames[i], pic_size, pic_size, ThumbnailOptions.None);
                Image img = Image.FromHbitmap(bm.GetHbitmap());
                imageList1.Images.Add(img);
                progressBar1.Value += pgbSpeed;
            }


            for (int i = imageNames.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = imageNames.Count - 1 - i;
                lvi.Name = imageNames[i];
                lvi.Text = System.IO.Path.GetFileNameWithoutExtension(imageNames[i]);
                //string str = imageNames[i];
                //string[] name = str.Split('\\');
                //lvi.Text = name[name.Length - 1];

                listView1.Items.Add(lvi);
            }
            progressBar1.Value = 100;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            listView1.EndUpdate();
        }

        private void Button1_Click(object sender, EventArgs e)//查询按钮
        {
            if (KeyWord == "" || KeyWord == null)
                return;
            else
            {
                imageList1.Images.Clear();
                listView1.Clear();
                videoNames = service.QueryByName(KeyWord);
                ListViewUpdate(videoNames);
            }
        }

        //扫描磁盘中所有磁盘文件
        private void Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Path = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + Path, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            List<string> imageFiles = new List<string>();
            imageFiles = GetFile.GetVideo(Path, imageFiles);

            List<string> lists = service.GetVideoList();//为扫描获得的视频建立一个列表
            int listid = lists.Count + 1;

            int nullNum = 1;
            string listname = "未命名列表" + nullNum;
            VideoList newList = new VideoList(listid, listname);
            while(!service.AddVideoList(newList))
            {
                nullNum++;
                listname = listname.Substring(0, listname.Length - 1) + nullNum;
                newList.Name = listname;
            }
            listBox1.Items.Add(listname);

            foreach (string s in imageFiles)
            {
                if(s != null)
                {
                    service.AddFile(s);                    
                    service.UpdateFileList(s, listid);
                }               
            }    
        }

        private void Button3_Click(object sender, EventArgs e)//创建新的视频列表
        {
            AddListForm f1 = new AddListForm(listBox1);

            f1.ShowDialog();
        }

        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)//set listbox1 item height
        {
            e.ItemHeight = 50;
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)//使listbox元素居中显示
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            System.Drawing.StringFormat strFmt = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
            strFmt.Alignment = StringAlignment.Center;
            strFmt.LineAlignment = StringAlignment.Center;

            RectangleF rf = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            //You can also use DrawImage to add some customized image before or after text string， of course background image
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new System.Drawing.SolidBrush(e.ForeColor), rf, strFmt);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)//视频列表切换，listView中切换内容
        {
            if (listBox1.SelectedIndex == 0)//全部视频
            {
                textBox1.Clear();
                //DateTime beforeDT = System.DateTime.Now;
                imageList1.Images.Clear();
                listView1.Clear();
                backgroundWorker1.RunWorkerAsync();
                //videoNames = service.GetAllVideos();
                //ListViewUpdate(videoNames);
                //DateTime afterDT = System.DateTime.Now;
                //TimeSpan dt = afterDT.Subtract(beforeDT);
                //MessageBox.Show("程序耗时:"+ dt.ToString() + "秒");                
            }
            else if (listBox1.SelectedIndex == 1)//收藏夹
            {
                textBox1.Clear();
                videoNames = service.GetCollection();
                ListViewUpdate(videoNames);
            }
            else if (listBox1.SelectedIndex == 2)//最近播放
            {
                textBox1.Clear();
                videoNames = service.GetByTime();
                if (videoNames.Count == 0)
                {
                    return;
                }
                List<string> rctVideo=new List<string>();
                for(int i=7;i>=0;i--)
                {
                    rctVideo.Add(videoNames[i]);
                }
                ListViewUpdate(rctVideo);
            }
            else //其他列表
            {
                string name = listBox1.SelectedItem.ToString();
                ListDetailForm f = new ListDetailForm(name, listBox1);

                f.ShowDialog();

            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)//右击视频进行操作，按ctrl可批量化操作
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)//进行播放
        {
            ListViewHitTestInfo info = this.listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                string url = info.Item.Name;
                string name = System.IO.Path.GetFileNameWithoutExtension(url);
                Video video = new Video(name, url);
                List<Video> lists = new List<Video>();
                foreach (string movieurl in videoNames)
                {
                    string moviename = System.IO.Path.GetFileNameWithoutExtension(movieurl);
                    Video v = new Video(moviename, movieurl);
                    lists.Add(v);
                }
                PlayerForm player = new PlayerForm(video, lists, imageList1.Images);
                player.Show();
                player.AddtoLike += AddLike;
                service.UpdateTime(name, DateTime.Now);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImageDialogMain imageDialog = new ImageDialogMain();
            imageDialog.ShowDialog();
        }

        private void AddLike(string url) {
            string msg = "确定将 " + url + " 添入收藏夹？";
            if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
            {
                service.UpdateCollected(url, true);
                MessageBox.Show("添加成功！");
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                if (listBox1.SelectedIndex == 1)
                {
                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                        string itemName = item.Text;
                        string msg = "确定将 " + itemName + " 移出收藏夹？";

                        if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                        {
                            service.UpdateCollected(item.Name, false);
                            MessageBox.Show("删除成功！");
                        }
                    }
                    List<string> imageNames = service.GetCollection();
                    ListViewUpdate(imageNames);
                }
                else
                {
                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                        AddLike(item.Name);
                    }
                }
            }
            else if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                foreach (ListViewItem item in this.listView1.SelectedItems)
                {
                    string itemName = item.Text;
                    string note = service.SeekNote(itemName);
                    Notebox notebox = new Notebox(itemName, note);
                    notebox.Show();
                }
            }
            else if (((ContextMenuStrip)sender).Items[2] == e.ClickedItem)
            {
                foreach (ListViewItem item in this.listView1.SelectedItems)
                {
                    string itemName = item.Text;
                    string msg = "确定将 " + itemName + " 删除？";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                    {
                        service.RemoveFlie(item.Name);
                        MessageBox.Show("删除成功！");
                        videoNames = service.GetAllVideos();
                        ListViewUpdate(videoNames);
                    }
                }
            }
        }
    }
}
