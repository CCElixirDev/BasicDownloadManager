using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadManager
{
    public class Download
    {
        public string FileName;

        public Uri URL;

        public double progressPercent;

        public Download(string fileName, string url)
        {
            FileName = fileName;
        }

        public Download(string fileName, Uri url)
        {
            FileName = fileName;
            URL = url;
        }


    }
}
