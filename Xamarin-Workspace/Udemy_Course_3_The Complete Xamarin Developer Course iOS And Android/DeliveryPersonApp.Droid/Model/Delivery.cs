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
   public class Delivery
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }

        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }

        /// <summary>
        /// 0 = waiting delivery person
        /// 1 = being delived
        /// 2 = delivered
        /// </summary>
        public int Status { get; set; }
        public static async Task<List<Delivery>> GetDeliveries()
        {
            List<Delivery> deliveries = new List<Delivery>();

            deliveries = await MainActivity.connect.Table<Delivery>().Where(d => d.Status != 2).ToListAsync();

            return deliveries; 
        }


        public static async Task<List<Delivery>> GetDelivered()
        {
            List<Delivery> deliveries = new List<Delivery>();

            deliveries = await MainActivity.connect.Table<Delivery>().Where(d => d.Status == 2).ToListAsync();

            return deliveries;
        }

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
          int row =  await MainActivity.connect.InsertAsync(delivery);

            if (row > 0)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"{Name} - {Status}";
        }

    }
}