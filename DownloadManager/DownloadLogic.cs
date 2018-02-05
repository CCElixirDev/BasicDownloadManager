using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.IO;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace DownloadManager.Logic
{
    public class DownloadLogic
    {
        private static Lazy<IWebProxy> lazy = new Lazy<IWebProxy>();

        private const int bufferSize = 32767;

        public Queue<Download> downloadQueue = new Queue<Download>(10);

        public string filepath;

        public Thread t;

        public MainWindow MainWindow;

        public void AddToDownloadQueue(string uri, string filename)
        {
            Uri result = null;
            if (Uri.TryCreate(uri, UriKind.Absolute, out result))
            {
                downloadQueue.Enqueue(new Download(filename, result));
            }
        }
        public void AddToDownloadQueue(Uri uri, string filename)
        {
            downloadQueue.Enqueue(new Download(filename, uri));
            var _listViewItem = new ListViewItem();
            
            MainWindow.BindData();
        }

        public void InvokeThreading()
        {
            t = new Thread(() => BeginDownloading());
            t.Start();

        }

        public void BeginDownloading()
        {
            while (downloadQueue.Count > 0)
            {
                using (var client = new WebClient())
                {
                    //client.DownloadProgressChanged +=
                    client.DownloadFileAsync(downloadQueue.FirstOrDefault().URL, $@"{filepath}\{downloadQueue.FirstOrDefault().FileName}");
                }
                downloadQueue.Dequeue();
            }
        }
    }
}
