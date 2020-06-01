using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePlayer
{
    public class Video
    {
        public string name { get; set; }

        public string url { get; set; }

        public Video(string name, string url)
        {
            this.name = name;
            this.url = url;
        }
    }
}
