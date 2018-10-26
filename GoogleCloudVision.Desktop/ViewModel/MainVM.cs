using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Desktop.Infrastructure;
using ImageSource = System.Windows.Media.ImageSource;

namespace GoogleCloudVision.Desktop.ViewModel
{
    public class MainVM : ViewModelBase
    {
        public string DocumentType { get; set; }

        public string DocumentData { get; set; }

        public ImageSource Image { get; set; }

        private RelayCommand _loadCommand;
        private RelayCommand _processCommand;

        private ImageContext _imageContext;
        private ImageAnnotatorClient _client;

        public MainVM()
        {
            _imageContext = new ImageContext()
            {
                // Language to detect
                LanguageHints = { "ua" }
            };

            // Instantiates a client
            _client = ImageAnnotatorClient.Create();
        }

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new RelayCommand(ExecuteLoadCommand, delegate { return true; });

                return _loadCommand;
            }
        }

        public ICommand ProcessCommand
        {
            get
            {
                if (_processCommand == null)
                    _processCommand = new RelayCommand(ExecuteProcessCommand, delegate { return true; });

                return _processCommand;
            }
        }

        private void ExecuteLoadCommand(object obj)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathToFile = openFileDialog.FileName;
                    Image = new BitmapImage(new Uri(pathToFile));
                    OnPropertyChanged("Image");
                }
            }
        }

        private void ExecuteProcessCommand(object obj)
        {
        }
    }
}
