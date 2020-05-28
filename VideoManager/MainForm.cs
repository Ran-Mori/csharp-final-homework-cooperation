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

namespace VideoManager
{
    public partial class MainForm : Form
    {
        public string KeyWord { get; set; }//输入的搜索内容
        public string Path { get; set; }//扫描的路径
        VideoService service;

        public MainForm()
        {
            InitializeComponent();
            service = new VideoService();
            textBox1.DataBindings.Add("Text", this, "KeyWord");
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = this.imageList1;

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.DrawItem += ListBox1_DrawItem;
            listBox1.MeasureItem += ListBox1_MeasureItem;

            InitListBoxItems();

            List<string> imageNames = service.GetAllVideos();
            ListViewUpdate(imageNames);
        }

        private  void InitListBoxItems()//初始化listbox中的项目
        {
            listBox1.Items.Add("全部视频");
            listBox1.Items.Add("收藏夹");//始终存在所以直接添加
            List<string> listNames = service.GetVideoList();
            foreach (string list in listNames)
            {
                listBox1.Items.Add(list);
            }
        }

        private void ListViewUpdate(List<string> imageNames)//更新listview中的内容
        {
            imageList1.Images.Clear();
            listView1.Clear();
            int pgbSpeed = 0;
            if (imageNames.Count != 0)
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
                List<string> imageNames = service.QueryByName(KeyWord);
                ListViewUpdate(imageNames);
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
            foreach (string s in imageFiles)
            {
                if (s != null)
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
                List<string> imageNames = service.GetAllVideos();
                ListViewUpdate(imageNames);
            }
            else if (listBox1.SelectedIndex == 1)//收藏夹
            {
                List<string> imageNames = service.GetCollection();
                ListViewUpdate(imageNames);
            }
            else //其他视频列表
            {

                string listname = listBox1.SelectedItem.ToString();
                ListDetailForm f = new ListDetailForm(listname,listBox1);
                f.ShowDialog();

            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)//右击视频添加至收藏夹，按ctrl可批量化操作
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count > 0)
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
                            string itemName = item.Text;
                            string msg = "确定将 " + itemName + " 添入收藏夹？";

                            if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                            {
                                service.UpdateCollected(item.Name, true);
                                MessageBox.Show("添加成功！");
                            }
                        }
                    }
                }
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)//进行播放或打开列表目录
        {
           
        }
    }
}
