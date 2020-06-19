using System;

namespace DBInterface
{
    public class Video
    {
        //public int Index { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public bool Collected { get; set; }
        public int ListID { get; set; }//收藏列表的序列号
        public string Note { get; set; }//视频备注
        public bool IsBinded { get; set; }
        public string PlayedTime { get; set; }

        //主要用于向数据库添加文件时用的构造方法
        public Video(string address)
        {
            this.Address = address;
            this.Name = System.IO.Path.GetFileNameWithoutExtension(address);
            this.Time = DateTime.Now;
            this.Collected = false;
            this.ListID = 0;
            this.Note = "";
            this.IsBinded = false;
            this.PlayedTime = "0";
        }

        public Video(string address, string name, DateTime time, bool collected, int listID, string note,bool binded, string pTime)
        {
            this.Address = address;
            this.Name = name;
            this.Time = time;
            this.Collected = collected;
            this.ListID = listID;
            this.Note = note;
            this.IsBinded = binded;
            this.PlayedTime = pTime;
        }

        //地址相同就相等
        public override bool Equals(object obj)
        {
            Video v = obj as Video;
            if (v == null) return false;

            return this.Address == v.Address;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}