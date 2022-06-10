using dataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dataAccess.DataPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileSystemPage1 : ContentPage
    {
        string fileName = "MyFile.txt";
        public FileSystemPage1()
        {
            InitializeComponent();

            btnWrite.Clicked += (sender, e) =>
            {
                string data = txtText.Text;
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, data);

                txtText.Text = string.Empty;
            };

            btnRead.Clicked += (sender, e) =>
            {
                string data = DependencyService.Get<IFileReadWrite>().ReadData(fileName);

                readText.Text = data;

            };
        }
    }
}