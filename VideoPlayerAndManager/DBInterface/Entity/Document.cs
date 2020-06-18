using System;

namespace DBInterface
{
    public class Document
    {
        
        public string Address { get; set; }
        public string Name { get; set; }
        public int ListID { get; set; }//收藏列表的序列号
        public String Binding { get; set; }

        //主要用于向数据库添加文件时用的构造方法
        public Document(string address)
        {
            this.Address = address;
            this.Name = System.IO.Path.GetFileNameWithoutExtension(address);
            this.ListID = 0;
            Binding = "";
        }

        public Document(string address, string name, int listID,string binding)
        {
            this.Address = address;
            this.Name = name;
            this.ListID = listID;
            this.Binding = binding;
        }

        //地址相同就相等
        public override bool Equals(object obj)
        {
            Document v = obj as Document;
            if (v == null) return false;

            return this.Address == v.Address;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}