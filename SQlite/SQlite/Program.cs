using System;
using System.Data.SQLite;

namespace SQlite
{
    class Program
    {
        static void Main(string[] args)
        {

            //创建一个数据库帮助对象，对象内封装了增删改查方法。其中参数是数据库的路径，现在填入的是绝对路径，肯定要修改。
            Helper.SqLiteCRUD helper = new Helper.SqLiteCRUD("D:\\Program\\CSharpHomework\\SQlite\\SQlite\\test.db");


            //创建一张表，把参数转换成SQL如下
            /*
             CREATE TABLE IF NOT EXISTS table1
                     (ID INTERGER, Name TEXT, Age INTERGER, Email TEXT)
             */
            helper.CreateTable("table1", new string[] { "ID", "Name", "Age", "Email" }, new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" });


            //插入数据, 把参数转换成sql如下
            /*
                INSERT INTO table1 values( `1`, `张三`, `16`, `Zhang@163.com`)
             */
            helper.InsertValues("table1", new string[] { "1", "张三", "16", "Zhang@163.com" });
            helper.InsertValues("table1", new string[] { "2", "李四", "17", "Li4@163.com" });
            helper.InsertValues("table1", new string[] { "5", "王也", "20", "Li4@gmail.com" });


            //更新数据，把参数转换成sql如下
            /*
              update table1
              set Name=`调整后的名字`
              where Name=`张三`,  Age=`16`
             */
            helper.UpdateValues("table1", new string[] { "Name" }, new string[] { "调整后的名字" }, new string[] { "Name","Age" }, new string[] { "=","=" }, new string[] { "张三","16" });


            //删除数据，把参数转换成sql如下
            /*
              delete from table1
              where Name=`王也`,  Age=`20`
             */
            helper.DeleteValuesAND("table1", new string[] { "Name", "Age" }, new string[] { "=", "=" }, new string[] { "王也", "20" });


            //查询整张表
            SQLiteDataReader reader = helper.ReadFullTable("table1");
            while (reader.Read())
            {
                //读取ID
                Console.WriteLine("" + reader.GetInt32(reader.GetOrdinal("ID")));
                //读取Name
                Console.WriteLine("" + reader.GetString(reader.GetOrdinal("Name")));
                //读取Age
                Console.WriteLine("" + reader.GetInt32(reader.GetOrdinal("Age")));
                //读取Email
                Console.WriteLine("" +reader.GetString(reader.GetOrdinal("Email")));
            }


            //关闭连接
            helper.CloseConnection();
        }
    }
 }

