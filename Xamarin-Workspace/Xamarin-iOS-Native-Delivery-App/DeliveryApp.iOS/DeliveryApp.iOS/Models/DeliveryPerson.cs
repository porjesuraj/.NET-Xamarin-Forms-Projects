using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace DeliveryApp.iOS.Models
{
    public class DeliveryPerson
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }


        public DeliveryPerson()
        {
        }

        public static async Task<DeliveryPerson> GetDeliveryPerson(int Id)
        {

            DeliveryPerson deliveryPerson = new DeliveryPerson();


            deliveryPerson = await AppDelegate.connect.Table<DeliveryPerson>().Where(p => p.Id == Id).FirstOrDefaultAsync();



            if (deliveryPerson != null)
                return deliveryPerson;
            else
                return null;
        }
    }
}
