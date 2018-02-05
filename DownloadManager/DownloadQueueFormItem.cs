using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DownloadManager
{
    public class DownloadQueueFormItem
    {
        public Label urlLabel;
        public Label fileNameLabel;
        public ProgressBar progressdownloading;

        public DownloadQueueFormItem(string url, string fileName, Point position)
        {
            urlLabel = new Label()
            {
                Height = 20,
                Width = 100,
                Content = url
            };
            fileNameLabel = new Label()
            {
                Content = fileName,
                Height = 20,
                Width = 100
            };
            progressdownloading = new ProgressBar();
        }
    }
}
