using Microsoft.Win32;
using System;
using System.Windows;

namespace WPFMediaAPI_Demo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenMediaElementFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.wmv)|*.wmv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog()== true)
            {
                var fullFileName = openFileDialog.FileName;
                var mediaFileUri = new Uri(fullFileName);
                MediaElement.Source = mediaFileUri;
                MediaElement.Play();
            }
        }

        //private void OpenMediaPlayerElementFile(object sender, RoutedEventArgs e)
        //{
        //    var openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Media files (*.wmv)|*.wmv|All Files (*.*)|*.*";

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        var fullFileName = openFileDialog.FileName;
        //        var mediaFileUri = new Uri(fullFileName);
        //        MediaPlayerElement.Source = fullFileName;
        //        MediaElement.Play();
        //    }
        //}
    }
}
