using System;
using System.IO;

namespace DeliveryApp.Constants
{
    public class Database
    {

        public static string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "deliveryDB.db3");

        public Database()
        {
        }
    }
}
