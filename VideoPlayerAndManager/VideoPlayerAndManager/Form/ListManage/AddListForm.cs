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
    public partial class AddListForm : Form
    {
        public string ListName { get; set; }//输入的列表名称
        public string Path { get; set; }//扫描的路径
        VideoService service;
        ListBox lb;

        public AddListForm()
        {
            InitializeComponent();
            service = new VideoService();
            listnameText.DataBindings.Add("Text", this, "ListName");
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = this.imageList1;

            List<string> videos = service.GetAllVideos();
            ListViewUpdate(videos);

        }
        public AddListForm(ListBox box)
        {
            InitializeComponent();
            service = new VideoService();
            lb = box;
            listnameText.DataBindings.Add("Text", this, "ListName");
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = this.imageList1;

            List<string> videos = service.GetAllVideos();
            ListViewUpdate(videos);

        }

        public void SetDefault()
        {
            listnameText.Text = "列表名称";
            listnameText.ForeColor = Color.Gray;
        }

        private void ListViewUpdate(List<string> imageNames)//更新listview中的内容,listview中是已扫描过的视频
        {
            imageList1.Images.Clear();
            listView1.Clear();

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

            }

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

        private void AddListForm_Load(object sender, EventArgs e)
        {
            SetDefault();


        }

        private void listnameText_Enter(object sender, EventArgs e)
        {
            listnameText.Text = "";
            listnameText.ForeColor = Color.Black;
        }

        private void listnameText_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(listnameText.Text))//如果文本框为空时
            {
                SetDefault();//设置默认值
            }
        }


        private void addListButton_Click(object sender, EventArgs e)
        {
            List<String> lists = service.GetVideoList();
            if (lb.Items.Contains(listnameText.Text))
            {
                MessageBox.Show("列表已存在！");
            }
            else
            {
                VideoList newList = new VideoList(lists.Count + 1, listnameText.Text);
                if (service.AddVideoList(newList))
                {

                    lb.Items.Add(listnameText.Text);
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)//右击视频添加至当前新建的视频列表，按ctrl可批量化操作
        {
            int listID = service.GetVideoList().Count;
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count > 0)
                {

                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                        string itemName = item.Text;
                        string msg = "确定将 " + itemName + " 添入" + listnameText.Text + "?";

                        if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                        {
                            service.UpdateFileList(item.Name, listID);
                            //service.UpdateListCover(listID, item.Name);
                            MessageBox.Show("添加成功！");
                        }

                    }
                }
            }
        }

        private void addVideosButton_Click(object sender, EventArgs e)
        {
            List<string> ListID = service.GetVideoList(ListName);
            string listId = ListID[0];
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
                    service.AddVideosToList(s, listId);
                }
            }
            List<string> videos = service.GetFileFromList(listId);
            ListViewUpdate(videos);
        }

        private void listnameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddListForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}

