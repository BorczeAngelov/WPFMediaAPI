using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
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

            if (openFileDialog.ShowDialog() == true)
            {
                var fullFileName = openFileDialog.FileName;
                var mediaFileUri = new Uri(fullFileName);
                MediaElement.Source = mediaFileUri;
                MediaElement.Play();
            }
        }

        private void MediaToolKitGrabThumbnail(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.wmv)|*.wmv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                var fullFileName = openFileDialog.FileName;
                var inputFile = new MediaFile { Filename = fullFileName };

                var outputFileName = fullFileName + " Thumbnail.jpg";
                var outputFile = new MediaFile { Filename = outputFileName };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);

                    // Saves the frame located on the 15th second of the video.
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(15) };
                    engine.GetThumbnail(inputFile, outputFile, options);
                }
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
