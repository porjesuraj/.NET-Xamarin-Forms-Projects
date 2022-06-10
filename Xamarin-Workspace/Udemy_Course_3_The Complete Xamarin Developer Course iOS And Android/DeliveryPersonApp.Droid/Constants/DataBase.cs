using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryPersonApp.Droid.Constants
{
   public class DataBase
    {

        public static readonly string DbPath = Path.Combine( System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"DeliveryPerson.db3");

        public async  static Task<bool> Insert<T>(T objectToInsert)
        {
            try
            {
               await   MainActivity.connect.InsertAsync(objectToInsert);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

            
        }

       
    }
}