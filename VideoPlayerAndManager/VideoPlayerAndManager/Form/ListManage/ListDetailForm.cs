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
using DBInterface;
using System.Diagnostics;

namespace VideoPlayerAndManager
{
    public partial class ListDetailForm : Form
    {
        public string ListName { get; set; }//输入的列表名称
        public string Path { get; set; }//扫描的路径
        public string ListID { get; set; }//该视频列表的id
        public string oldName; //之前的名字
        VideoService service;
        ListBox lb;
        List<string> videos;
        List<string> documents;
        public ListDetailForm()
        {
            InitializeComponent();

        }

        public ListDetailForm(string name, ListBox box)
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

            InitListBoxItem();

            List<string> listID = service.GetVideoList(name);
            ListID = listID[0];
            videos = service.GetFileFromList(ListID);
            documents = service.GetDocument(ListID);
            ListViewUpdate(videos);
            ListViewUpdate(ListID);
        }

        //初始化listBox
        private void InitListBoxItem()
        {
            listBox1.Items.Add("当前列表");
            listBox1.Items.Add("全部视频");

        }

        //更新listview中的内容,listview中是该列表的视频
        private void ListViewUpdate(List<string> Videos)
        {
            imageList1.Images.Clear();
            listView1.Clear();
            List<string> BindedVideos = service.GetBindedVideos(ListID);
            List<string> ImageNames=new List<string>();
            int pic_size = 256;

            for (int i = Videos.Count - 1; i >= 0; i--)
               {
                string imageName = Videos[i];
                if (!File.Exists(imageName))
                {
                    service.RemoveFlie(imageName);
                    Videos.Remove(imageName);
                    continue;
                }
                Bitmap bm = WindowsThumbnailProvider.GetThumbnail(imageName, pic_size, pic_size, ThumbnailOptions.None);
                Image img = Image.FromHbitmap(bm.GetHbitmap());
                imageList1.Images.Add(img);
                ImageNames.Add(imageName);
               
                if (BindedVideos.Contains(imageName)){
                    List<string> Document = service.GetFilesOfVideo(ListID,imageName);
                    for (int j = Document.Count - 1; j >= 0; j--)
                    {
                            if (!File.Exists(Document[j]))
                            {
                                service.RemoveDocument(Document[j]);
                                Document.Remove(Document[j]);
                                continue;
                            }
                       
                        string extension = Document[j].Substring(Document[j].LastIndexOf(".") + 1,
                            Document[j].Length - Document[j].LastIndexOf(".") - 1);
                        Image img1;
                        switch (extension)
                        {
                            case "pdf":
                                img1 = imageList2.Images[0];
                                imageList1.Images.Add(img1);
                                break;
                            case "ppt":
                                img1 = imageList2.Images[1];
                                imageList1.Images.Add(img1);
                                break;
                            case "pptx":
                                img1 = imageList2.Images[1];
                                imageList1.Images.Add(img1);
                                break;
                            case "doc":
                                img1 = imageList2.Images[2];
                                imageList1.Images.Add(img1);
                                break;
                            case "docx":
                                img1 = imageList2.Images[2];
                                imageList1.Images.Add(img1);
                                break;
                        }
                        ImageNames.Add(Document[j]);

                    }
                }
                
            }

            for (int i = 0; i<ImageNames.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Name = ImageNames[i];
                lvi.Text = System.IO.Path.GetFileNameWithoutExtension(ImageNames[i]);

                listView1.Items.Add(lvi);
            }

            listView1.EndUpdate();
        }

        private void ListViewUpdate(string listid)//更新其他文件于listview上
        {
            List<string> Document = service.GetFilesOfNoVideos(ListID);
            if (Document.Count == 0)
                return;
           
            for (int i = Document.Count - 1; i >= 0; i--)
            {
                if (!File.Exists(Document[i]))
                {
                    service.RemoveDocument(Document[i]);
                    Document.Remove(Document[i]);
                    continue;
                }
                string extension = Document[i].Substring(Document[i].LastIndexOf(".") + 1,
                    Document[i].Length - Document[i].LastIndexOf(".") - 1);
                Image img;
                switch (extension)
                {
                    case "pdf":
                        img = imageList2.Images[0];
                        imageList1.Images.Add(img);
                        break;
                    case "ppt":
                        img = imageList2.Images[1];
                        imageList1.Images.Add(img);
                        break;
                    case "pptx":
                        img = imageList2.Images[1];
                        imageList1.Images.Add(img);
                        break;
                    case "doc":
                        img = imageList2.Images[2];
                        imageList1.Images.Add(img);
                        break;
                    case "docx":
                        img = imageList2.Images[2];
                        imageList1.Images.Add(img);
                        break;
                }
            }
            int count = imageList1.Images.Count;
            for (int i = Document.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = count - 1 - i;
                lvi.Name = Document[i];
                lvi.Text = System.IO.Path.GetFileNameWithoutExtension(Document[i]);
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
            service.UpdateListName(ListID, listNameText.Text);
            try { lb.Items.Remove(oldName); }
            catch
            {
            }
            lb.Items.Add(listNameText.Text);
            MessageBox.Show("修改成功！");
            oldName = listNameText.Text;
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
                    if (listBox1.SelectedIndex != 1)
                    {
                        service.AddVideosToList(s, ListID);
                        videos = service.GetFileFromList(ListID);
                        ListViewUpdate(videos);
                        ListViewUpdate(ListID);
                        listBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        service.AddFile(s);
                        List<string> allVideos = service.GetAllVideos();
                        ListViewUpdate(allVideos);
                    }


                }
            }

        }

        //播放视频或打开文件
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = this.listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                string url = info.Item.Name;
                string extension = url.Substring(url.LastIndexOf(".") + 1,
                    url.Length - url.LastIndexOf(".") - 1);
                string name = System.IO.Path.GetFileNameWithoutExtension(url);
                if (extension == "mp4" || extension == "avi" || extension == "mkv")
                {
                    Video video = new Video(name, url);
                    List<Video> lists = new List<Video>();
                    foreach (string movieurl in videos)
                    {
                        string moviename = System.IO.Path.GetFileNameWithoutExtension(movieurl);
                        Video v = new Video(moviename, movieurl);
                        lists.Add(v);
                    }
                    PlayerForm player = new PlayerForm(video, lists, imageList1.Images);
                    player.Show();
                }
                else
                {
                    Process.Start(url);
                }
            }
        }

        //右击出现操作菜单
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    
                    if (listBox1.SelectedIndex != 1)
                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    else if(listBox1.SelectedIndex==1)
                        contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        //删除当前列表

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            string msg = "确定将 " + ListName + " 删除吗? ";

            if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
            {
                videos = service.GetFileFromList(ListID);
                documents = service.GetDocument(ListID);
                List<string> lists = service.GetVideoList();
                foreach (string video in videos)
                {
                    service.UpdateFileList(video, 0);
                }
                foreach (string doc in documents)
                {
                    service.RemoveDocument(doc);
                }
                service.RemoveVideoList(int.Parse(ListID));
                lists.Remove(listNameText.Text);
                for (int i = 0; i < lists.Count; i++)
                {
                    string newID = (i + 1).ToString();
                    List<String> oldID = service.GetVideoList(lists[i]);
                    string old = oldID[0];
                    List<string> thevideos = service.GetFileFromList(old);
                    List<string> thedocs = service.GetDocument(old);
                    foreach (string video in thevideos)
                    {
                        service.UpdateFileList(video, int.Parse(newID));
                    }
                    foreach (string doc in thedocs)
                    {
                        service.UpdateDocList(doc, int.Parse(newID));
                    }

                    service.UpdateListID(newID, lists[i]);

                }

                try { lb.Items.Remove(listNameText.Text); }
                catch
                {
                    this.Close();
                }
                this.Close();
                MessageBox.Show("删除成功！");

            }
        }

        //视频列表切换，listView中切换内容
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)//当前列表内视频和其他文件
            {
                videos = service.GetFileFromList(ListID);
                ListViewUpdate(videos);
                ListViewUpdate(ListID);
            }
            else if (listBox1.SelectedIndex == 1)
            {
                List<string> allVideos = service.GetAllVideos();
                ListViewUpdate(allVideos);

            }


        }

        //点击添加其他文件（pdf,ppt,word）
        private void addDocument_Click(object sender, EventArgs e)
        {
            OpenFileDialog od1 = new OpenFileDialog();
            od1.InitialDirectory = "c:\\";
            od1.Filter = GetFile.DocumentFilter;
            od1.FilterIndex = 2;
            od1.RestoreDirectory = true;

            if (od1.ShowDialog() == DialogResult.OK)
            {
                Path = od1.FileName;
                MessageBox.Show("已选择文件:" + Path, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            service.AddDocument(Path, ListID);
            videos = service.GetFileFromList(ListID);
            ListViewUpdate(videos);
            ListViewUpdate(ListID);
            listBox1.SelectedIndex = 0;
        }

        private void 移入或移出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                string itemName = item.Name;

                if (videos.Contains(itemName) || documents.Contains(itemName))
                {
                    string msg = "确定将 " + itemName + " 移出" + ListName + "?";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                    {
                        if (videos.Contains(itemName))
                        {
                            service.UpdateFileList(itemName, 0);
                            service.UpdateBindedDocList(itemName, 0);
                        }
                        else if (documents.Contains(itemName))
                        {
                            service.RemoveDocument(itemName);

                        }
                        MessageBox.Show("删除成功！");
                    }
                }
                else
                {
                    string msg = "确定将 " + itemName + " 添入" + ListName + " ? ";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                    {
                        service.UpdateFileList(itemName, int.Parse(ListID));
                        service.UpdateBindedDocList(itemName, int.Parse(ListID));
                        MessageBox.Show("添加成功！");

                    }
                }
                documents = service.GetDocument(ListID);
                videos = service.GetFileFromList(ListID);
                ListViewUpdate(videos);
                ListViewUpdate(ListID);
                listBox1.SelectedIndex = 0;
            }
        }

        private void 添加相关文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                string itemName = item.Name;
                OpenFileDialog od1 = new OpenFileDialog();
                od1.InitialDirectory = "c:\\";
                od1.Filter = GetFile.DocumentFilter;
                od1.FilterIndex = 2;
                od1.RestoreDirectory = true;

                if (od1.ShowDialog() == DialogResult.OK)
                {
                    Path = od1.FileName;
                    MessageBox.Show("已选择文件:" + Path, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                service.BindFile(Path, ListID, itemName);
                service.AddBinding(itemName,true);

            }
            documents = service.GetDocument(ListID);
            videos = service.GetFileFromList(ListID);
            ListViewUpdate(videos);
            ListViewUpdate(ListID);
            listBox1.SelectedIndex = 0;
        }

        private void 移入或移出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                string itemName = item.Name;

                if (videos.Contains(itemName) || documents.Contains(itemName))
                {
                    string msg = "确定将 " + itemName + " 移出" + ListName + "?";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                    {
                        if (videos.Contains(itemName))
                        {
                            service.UpdateFileList(itemName, 0);
                            service.UpdateBindedDocList(itemName, 0);

                        }
                        else if (documents.Contains(itemName))
                        {
                            service.RemoveDocument(itemName);

                        }
                        MessageBox.Show("删除成功！");
                    }
                }
                else
                {
                    string msg = "确定将 " + itemName + " 添入" + ListName + " ? ";

                    if ((int)MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel) == 1)
                    {
                        service.UpdateFileList(itemName, int.Parse(ListID));
                        service.UpdateBindedDocList(itemName, int.Parse(ListID));
                        MessageBox.Show("添加成功！");

                    }
                }
                documents = service.GetDocument(ListID);
                videos = service.GetFileFromList(ListID);
                ListViewUpdate(videos);
                ListViewUpdate(ListID);
                listBox1.SelectedIndex = 0;
            }
        }
    }
}
