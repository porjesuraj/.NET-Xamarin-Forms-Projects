using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DeliveryPersonApp.Droid.Model
{
   public class DeliveryPerson
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public static async Task<DeliveryPerson> GetDeliveryPerson(int id)
        {
            DeliveryPerson person = new DeliveryPerson();

            person = await (MainActivity.connect.Table<DeliveryPerson>().Where(p => p.Id == id).FirstOrDefaultAsync());

            return person;
        }
    }
}