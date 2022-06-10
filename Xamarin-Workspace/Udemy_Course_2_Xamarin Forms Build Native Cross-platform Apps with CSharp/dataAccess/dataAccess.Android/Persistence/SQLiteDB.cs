﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dataAccess.Droid.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using dataAccess.Interface;
using SQLite;
using System.IO;
[assembly : Dependency(typeof(SQLiteDB))]
namespace dataAccess.Droid.Persistence
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}