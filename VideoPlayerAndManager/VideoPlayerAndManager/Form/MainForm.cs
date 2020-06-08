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

        public MainForm()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", this, "KeyWord");
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = this.imageList1;

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.DrawItem += ListBox1_DrawItem;
            listBox1.MeasureItem += ListBox1_MeasureItem;
            InitListBoxItem();


            videoNames = service.GetAllVideos();
            ListViewUpdate(videoNames);
        }

        //初始化listBox
        private void InitListBoxItem()
        {
            listBox1.Items.Add("全部视频");
            listBox1.Items.Add("收藏夹");//始终存在所以直接添加
            List<string> lists = service.GetVideoList();
            foreach (string list in lists)
            {
                listBox1.Items.Add(list);
            }
        }

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

        private void Button2_Click(object sender, EventArgs e)//扫描磁盘中所有磁盘文件
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
            foreach(string s in imageFiles)
            {
                if(s != null)
                {
                    service.AddFile(s);
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
                videoNames = service.GetAllVideos();
                ListViewUpdate(videoNames);
            }
            else if (listBox1.SelectedIndex == 1)//收藏夹
            {
                videoNames = service.GetCollection();
                ListViewUpdate(videoNames);
            }
           
            else //其他列表
            {
                string name = listBox1.SelectedItem.ToString();
                ListDetailForm f = new ListDetailForm(name, listBox1);

                f.ShowDialog();

            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)//右击视频添加至收藏夹，按ctrl可批量化操作
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
                VideoPlayerAndManager.Video video = new VideoPlayerAndManager.Video(name, url);
                List<VideoPlayerAndManager.Video> lists = new List<VideoPlayerAndManager.Video>();
                foreach (string movieurl in videoNames)
                {
                    string moviename = System.IO.Path.GetFileNameWithoutExtension(movieurl);
                    VideoPlayerAndManager.Video v = new VideoPlayerAndManager.Video(moviename, movieurl);
                    lists.Add(v);
                }
                VideoPlayerAndManager.PlayerForm player = new VideoPlayerAndManager.PlayerForm(video, lists);
                player.Show();
                player.AddtoLike += AddLike;
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
        }
    }
}
