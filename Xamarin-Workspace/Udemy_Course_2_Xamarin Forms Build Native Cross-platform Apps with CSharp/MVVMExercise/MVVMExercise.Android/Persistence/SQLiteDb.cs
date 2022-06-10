using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MVVMExercise.Droid.Persistence;
using MVVMExercise.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace MVVMExercise.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {


            var folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(folderPath, "MyContacts2.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}