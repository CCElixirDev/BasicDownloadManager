using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DownloadManager
{
    /// <summary>
    /// Interaction logic for AddUrlFrm.xaml
    /// </summary>
    public partial class AddUrlFrm : Window
    {
        MainWindow parentWindow;
        public AddUrlFrm(MainWindow parentForm)
        {
            InitializeComponent();
            parentWindow = parentForm;
        }

        private void EnqueueButton_Click(object sender, RoutedEventArgs e)
        {
            Uri result = null;
            string filename = FileNameText.Text.Replace(' ', '_');
            if (Uri.TryCreate(UrlText.Text, UriKind.Absolute, out result))
            {
                parentWindow.downloadLogic.AddToDownloadQueue(result, filename);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to create URI please try again");
            }
        }
    }
}
