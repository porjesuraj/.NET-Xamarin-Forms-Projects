using MakeUpStoreApplication.Common.SQLiteDataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MakeUpStoreApplication.Common.Models
{
   
   public class MakeUpProduct : IDatabaseItem
    {
            [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int ProductId { get; set; }

            public string Name { get; set; }
 
            public string Price { get; set; }

            public string ImageLink { get; set; }

            public string Description { get; set; }

             public int Quantity { get; set; }
             public double? Rating { get; set; }

        private double? totalAmount;

        public double? TotalAmount
        {
            get 
            {

                return Double.Parse(Price) * Quantity;
            }
            set { totalAmount = value; }
        }

    }
}
