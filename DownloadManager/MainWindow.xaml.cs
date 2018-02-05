using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DownloadManager.Logic;

namespace DownloadManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DownloadLogic downloadLogic;
        public MainWindow()
        {
            InitializeComponent();
            downloadLogic = new DownloadLogic()
            {
                filepath = $@"C:\Users\{Environment.UserName}\Downloads"
            };
            DirectoryDisplay.Text = downloadLogic.filepath;
            downloadLogic.MainWindow = this;
            
        }

        private void AddUrlBtn_Click(object sender, RoutedEventArgs e)
        {
            var addurlform = new AddUrlFrm(this);
            addurlform.ShowDialog();
        }

        public void BindData()
        {
            DownloadListBox.ItemsSource = downloadLogic.downloadQueue;
        }

        private void DirectoryDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DirectoryDisplay_Initialized(object sender, EventArgs e)
        {
            
        }

        private void DownloadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
