using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dataAccess.Droid;
using dataAccess.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace dataAccess.Droid
{

    class FileHelper : IFileReadWrite
    {
        public string ReadData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
            
        }

        public void WriteData(string fileName, string data)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
         //   File.WriteAllText(filePath, data);
            File.AppendAllText(filePath, data);
        }
    }
}