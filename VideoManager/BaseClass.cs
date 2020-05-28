using System;

namespace VideoManager
{
    public class Video
    {
        //public int Index { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public bool Collected { get; set; }
        public int ListID { get; set; }//收藏列表的序列号

        //主要用于向数据库添加文件时用的构造方法
        public Video(string address)
        {
            this.Address = address;
            this.Name= System.IO.Path.GetFileNameWithoutExtension(address);
            this.Time = DateTime.Now;
            this.Collected = false;
            this.ListID = 0;
        }

        public Video(string address,string name,DateTime time,bool collected,int listID)
        {
            this.Address = address;
            this.Name = name;
            this.Time = time;
            this.Collected = collected;
            this.ListID = listID;
        }

        //地址相同就相等
        public override bool Equals(object obj)
        {
            Video v = obj as Video;
            if (v == null) return false;

            return this.Address==v.Address;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class VideoList
    {
        public int ListID { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }//用作列表缩略图的视频地址
        public VideoList(int i,string name)
        {
            this.ListID = i;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            VideoList list = obj as VideoList;
            if (list == null) return false;
            return this.ListID == list.ListID && this.Name == list.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
