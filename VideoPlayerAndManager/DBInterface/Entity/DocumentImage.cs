using System;

namespace DBInterface
{
    public class DocumentImage
    {
        //public int Index { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int ListID { get; set; }//收藏列表的序列号

        //主要用于向数据库添加文件时用的构造方法
        public DocumentImage(string address)
        {
            this.Address = address;
            this.Name = System.IO.Path.GetFileNameWithoutExtension(address);
            this.ListID = 0;
        }

        public DocumentImage(string address, string name, int listID)
        {
            this.Address = address;
            this.Name = name;
            this.ListID = listID;
        }

        //地址相同就相等
        public override bool Equals(object obj)
        {
            DocumentImage v = obj as DocumentImage;
            if (v == null) return false;

            return this.Address == v.Address;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}