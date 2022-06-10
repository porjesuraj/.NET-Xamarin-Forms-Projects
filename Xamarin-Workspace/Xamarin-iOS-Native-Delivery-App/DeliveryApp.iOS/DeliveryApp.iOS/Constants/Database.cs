using System;
using System.IO;
using System.Threading.Tasks;

namespace DeliveryApp.iOS.Constants
{
    public class Database
    {

        public static string DbPath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "DeliveryApp.db3");

           
        public Database()
        {
        }


        public async static Task<bool> Insert<T>(T objectToInsert)
        {
            try
            {
                var result = await AppDelegate.connect.InsertAsync(objectToInsert);

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception )
            {
                return false;
            }

          
            



        }
    }
}
