using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VideoManager
{
    public partial class ListDetailForm : Form
    {
        public string ListName { get; set; }//输入的列表名称
        public string Path { get; set; }//扫描的路径
        public string ListID { get; set; }//该视频列表的id
        public  string oldName; //之前的名字
        VideoService service;
        ListBox lb;

        public ListDetailForm()
        {
            InitializeComponent();

        }

        public ListDetailForm(string name,ListBox box)
        {
            InitializeComponent();
            service = new VideoService();
            lb = box;
            ListName = name;
            oldName = name;
            listNameText.DataBindings.Add("Text", this, "ListName");
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = this.imageList1;

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.DrawItem += ListBox1_DrawItem;
            listBox1.MeasureItem += ListBox1_MeasureItem;
            listBox1.Items.Add("当前列表内视频");
            listBox1.Items.Add("全部视频");

            List<String> listID = service.GetVideoList(name);
            ListID = listID[0];
            List<String> videos = service.GetFileFromList(ListID);
            ListViewUpdate(videos);
        }

        //更新listview中的内容,listview中是该列表的视频
        private void ListViewUpdate(List<string> imageNames)
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

        //listbox设置
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

        //更新列表的name信息
        private void button1_Click(object sender, EventArgs e)
        {
            try{lb.Items.Remove(oldName); }
            catch {
                MessageBox.Show("修改成功！");
            }
            lb.Items.Add(listNameText.Text);
            service.UpdateListName(ListID, listNameText.Text);
            
            
        }

        //视频列表切换，listView中切换内容
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)//当前列表内视频
            {
                List<string> imageNames = service.GetFileFromList(ListID);
                ListViewUpdate(imageNames);
            }
            else if (listBox1.SelectedIndex == 1)//全部视频
            {
                List<string> imageNames = service.GetAllVideos();
                ListViewUpdate(imageNames);
            }
        }

        // 从文件中扫描视频
        private void addVideoButton_Click(object sender, EventArgs e)
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
                    if (listBox1.SelectedIndex == 0)
                    {
                        service.AddVideosToList(s, ListID);
                        List<string> videos = service.GetFileFromList(ListID);
                        ListViewUpdate(videos);
                    }
                    else if (listBox1.SelectedIndex == 1)
                    {
                        service.AddFile(s);
                        List<string> videos = service.GetAllVideos();
                        ListViewUpdate(videos);

                    }

                }
            }

        }

        //播放视频
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        //右击视频移入、移出视频列表
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            List<string> videos = service.GetFileFromList(ListID);

            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count > 0)
                {

                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                        string itemName = item.Name;
                        if (videos.Contains(itemName))
                        {
                            string msg = "确定将 " + itemName + " 移出" + ListName + "?";

                            if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                            {
                                service.UpdateFileList(itemName, 0);
                                MessageBox.Show("删除成功！");
                                
                            }
                        }
                        else
                        {
                            string msg = "确定将 " + itemName + " 添入" + ListName + " ? ";

                            if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                            {
                                service.UpdateFileList(itemName, int.Parse(ListID));
                                MessageBox.Show("添加成功！");
                                
                            }
                        }
                        List<string> imageNames = service.GetFileFromList(ListID);
                        ListViewUpdate(imageNames);
                        listBox1.SelectedIndex = 0;
                    }
                }
            }
        }

        //删除当前列表
        private void deleteButton_Click(object sender, EventArgs e)
        {
            string msg = "确定将 "  + ListName + " 删除吗? ";

            if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
            {
                List<string> videos = service.GetFileFromList(ListID);
                List<string> lists = service.GetVideoList();
                foreach(string video in videos)
                {
                    service.UpdateFileList(video, 0);
                }
                service.RemoveVideoList(int.Parse(ListID));
                lists.Remove(listNameText.Text);
                for(int i=0;i<lists.Count;i++)
                {
                    string newID = (i + 1).ToString();
                    List<String> oldID = service.GetVideoList(lists[i]);
                    string old = oldID[0];
                    List<string> thevideos = service.GetFileFromList(old);
                    foreach (string video in thevideos)
                    {
                        service.UpdateFileList(video, int.Parse(newID));
                    }
                    service.UpdateListID(newID, lists[i]);

                }

                try { lb.Items.Remove(listNameText.Text); }
                catch
                {
                    this.Close();
                }
                MessageBox.Show("删除成功！");

            }
        }
    }
}
