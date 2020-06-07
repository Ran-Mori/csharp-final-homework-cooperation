using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerAndManager
{
    class GetFile
    {
        public static List<string> GetVideo(string path, List<string> FileList)
        {
            string[] extension = { ".mp4", ".avi", ".mkv", ".MP4", ".AVI", ".MKV","mov"};
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] fil = dir.GetFiles();
                DirectoryInfo[] dii = dir.GetDirectories();
                foreach (FileInfo f in fil)
                {
                    if (f.Length > 0 && extension.Contains<string>(f.Extension))
                    {
                        FileList.Add(f.FullName);//添加文件路径到列表中 
                    }
                }
                //获取子文件夹内的文件列表，递归遍历  
                foreach (DirectoryInfo d in dii)
                {
                    GetVideo(d.FullName, FileList);
                }                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return FileList;
        }

        public static string DocumentFilter
        {
            get { return "(*.doc;*.docx)|*.doc;*.docx|(*.ppt;*.pptx)|*.ppt;*.pptx|(*.pdf)|*.pdf";}
        }
    }
}
