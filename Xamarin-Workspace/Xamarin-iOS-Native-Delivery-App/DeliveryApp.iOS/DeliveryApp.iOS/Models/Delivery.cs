using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace DeliveryApp.iOS.Models
{
    public class Delivery
    {

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }

       /// <summary>
       /// 0 = waiting delivery person
       /// 1 = being delivered
       /// 2 = delivered
       /// </summary>
        public int Status { get; set; }


        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }

        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }

        public Delivery()
        {
        }


        public static async Task<List<Delivery>> GetDeliveries()
        {

            List<Delivery> deliveries = new List<Delivery>();


            deliveries = await AppDelegate.connect.Table<Delivery>().ToListAsync();


            if (deliveries != null)
                return deliveries;
            else
                return null;
        }

        internal static async Task<List<Delivery>> GetDelivered()
        {
            List<Delivery> deliveries = new List<Delivery>();


            deliveries = await AppDelegate.connect.Table<Delivery>().Where(d => d.Status == 1).ToListAsync();


            if (deliveries != null)
                return deliveries;
            else
                return null;
        }

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
              int row =  await AppDelegate.connect.InsertAsync(delivery);

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
