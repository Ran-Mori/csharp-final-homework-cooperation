using System;
using System.Collections.Generic;

namespace DBInterface
{
    public class VideoService
    {
        private static SqLiteHelper helper = null;
        private static string SQLFileName = "\\test.db";//SQLFileName数据库文件放在启动项目的debug文件下

        public VideoService()
        {
            helper = new SqLiteHelper(System.IO.Directory.GetCurrentDirectory() + SQLFileName);
        }

        //添加视频文件
        public bool AddFile(string filePath)
        {
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "address", "=", filePath);
            if (sr.HasRows)
            {
                return false;
            }
            Video video = new Video(filePath);
            helper.InsertValues("video",
                new string[] { video.Address, video.Name, video.Time.ToString(), video.Collected.ToString(), video.ListID.ToString(), video.Note });
            return true;
        }

        public List<string> GetAllVideos()//返回数据库中所有视频文件
        {
            string sql = $"select * from video";
            System.Data.SQLite.SQLiteDataReader sr = helper.ExecuteQuery(sql);
            List<string> result = new List<string>();
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }

        //视频名查询,返回文件地址的list
        public List<string> QueryByName(string name)
        {
            //string sql = $"select * from video where name like '%{name}%'";
            string sname = $"%{name}%";
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "name", "like", sname);
            List<string> result = new List<string>();
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }

        //视频名查询,返回对应视频的备注
        public string SeekNote(string name)
        {
            //string sql = $"select * from video where name like '%{name}%'";
            string sname = $"%{name}%";
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "name", "like", sname);
            string note = "";
            while (sr.Read())
            {
                note = sr.GetString(sr.GetOrdinal("note"));
            }
            return note;
        }

        //相似日期查询,返回文件地址的list,time使用DateTime格式
        public List<string> QueryByDate(string time)
        {
            string[] strs = time.Split(' ');
            string stime = $"{strs[0]}%";//提取年月日
            //string sql = $"select * from video where date like '{silimarTime}%'";
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "date", "like", stime);
            List<string> result = new List<string>();
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }

        //创建收藏的文件列表,返回文件地址的list
        public List<string> GetCollection()
        {
            List<string> result = new List<string>();
            //string sql = $"select * from video where collected = 'true'";
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "collected", "=", "True");
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }

        //获取给定视频地址的Video对象list
        public List<Video> GetVideo(string address)
        {
            List<Video> result = new List<Video>();
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "address", "=", address);
            while (sr.Read())
            {
                string name = sr.GetString(sr.GetOrdinal("name"));
                DateTime time = Convert.ToDateTime(sr.GetString(sr.GetOrdinal("date")));
                bool collected = sr.GetBoolean(sr.GetOrdinal("collected"));
                int id = sr.GetInt16(sr.GetOrdinal("listid"));
                string note = sr.GetString(sr.GetOrdinal("note"));
                Video video = new Video(address, name, time, collected, id, note);
                result.Add(video);
            }
            return result;
        }

        //变更视频名称
        public void UpdateFlieName(string oldName, string newName)
        {
            string sql = $"update video set name = '{newName}' where name = '{oldName}'";
            helper.ExecuteQuery(sql);
        }

        //变更收藏
        public void UpdateCollected(string fileAddress, bool b)
        {
            string bb = b.ToString();
            string sql = $"update video set collected = '{bb}' where address = '{fileAddress}'";
            helper.ExecuteQuery(sql);
        }

        //变更视频所在的列表
        public void UpdateFileList(string fileAddress, int listid)
        {
            string id = listid.ToString();
            string sql = $"update video set listid = '{id}' where address = '{fileAddress}'";
            helper.ExecuteQuery(sql);
        }

        //变更视频备注
        public void UpdateNote(string name, string newNote)
        {
            string sql = $"update video set note = '{newNote}' where name = '{name}'";
            helper.ExecuteQuery(sql);
        }

        //移除文件
        public void RemoveFlie(string fileAddress)
        {
            helper.DeleteValuesAND("video", new string[] { "address" }, new string[] { "=" }, new string[] { fileAddress });
        }

        //以下是对videolist表的操作,因为videolist表比较简单所以只有简单的增删查

        //添加videolist
        public bool AddVideoList(VideoList videoList)
        {
            List<string> listNames = GetVideoList(videoList.ListID.ToString());
            if (listNames.Count > 0) return false;

            helper.InsertValues("videolist", new string[] { videoList.ListID.ToString(), videoList.Name });
            return true;
        }

        //读取所有videolist
        public List<String> GetVideoList()
        {
            List<String> lists = new List<String>();
            System.Data.SQLite.SQLiteDataReader sr = helper.ExecuteQuery("select * from videolist");
            while (sr.Read())
            {

                lists.Add(sr.GetString(sr.GetOrdinal("name")));
            }
            return lists;
        }

        //查询指定name的listid
        public List<String> GetVideoList(string name)
        {
            List<String> result = new List<String>();
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("videolist", "name", "=", name);
            while (sr.Read())
            {
                result.Add(sr[0].ToString());
            }
            return result;
        }

        //移除videolist
        public void RemoveVideoList(int id)
        {
            helper.DeleteValuesAND("videolist", new string[] { "listid" }, new string[] { "=" }, new string[] { id.ToString() });
        }

        //获取指定listid的视频，返回文件地址的list
        public List<string> GetFileFromList(string listid)
        {
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "listid", "=", listid.ToString());
            List<string> result = new List<string>();
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }
        //更新列表name
        public void UpdateListName(string id, string newName)
        {
            string sql = $"update videolist set name = '{newName}' where listid = '{id}'";
            helper.ExecuteQuery(sql);
        }

        //更新列表id
        public void UpdateListID(string newid, string name)
        {
            string sql = $"update videolist set listid = '{newid}' where name = '{name}'";
            helper.ExecuteQuery(sql);
        }

        //添加新视频到列表
        public bool AddVideosToList(string filePath, string listId)
        {
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("video", "address", "=", filePath);
            if (sr.HasRows)
            {
                return false;
            }
            Video video = new Video(filePath);
            helper.InsertValues("video",
                new string[] { video.Address, video.Name, video.Time.ToString(), video.Collected.ToString(), listId });
            return true;
        }

        //以下是对Document表的操作
        public bool AddDocument(string filePath)
        {
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("document", "address", "=", filePath);
            if (sr.HasRows)
            {
                return false;
            }
            Document document = new Document(filePath);
            helper.InsertValues("document",
                new string[] { document.Address, document.Name, document.ListID.ToString() });
            return true;
        }

        //获取所有document的地址
        public List<string> GetAllDocument()
        {
            string sql = $"select * from document";
            System.Data.SQLite.SQLiteDataReader sr = helper.ExecuteQuery(sql);
            List<string> result = new List<string>();
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }

        //从列表id获取document
        public List<string> GetDocument(int listid)
        {
            string ID = listid.ToString();
            System.Data.SQLite.SQLiteDataReader sr = helper.Query("document", "listid", "=", ID);
            List<string> result = new List<string>();
            while (sr.Read())
            {
                result.Add(sr.GetString(sr.GetOrdinal("address")));
            }
            return result;
        }

        //移除document
        public void RemoveDocument(string fileAddress)
        {
            helper.DeleteValuesAND("document", new string[] { "address" }, new string[] { "=" }, new string[] { fileAddress });
        }

        public void Close()
        {
            helper.CloseConnection();
        }
    }
}
