using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Collections.Classes
{
    class Order
    {
        public int OrderId { get; set; }

        public int orderQuantity { get; set; }

        public Order(int orderId, int orderQuantity)
        {
            OrderId = orderId;
            this.orderQuantity = orderQuantity;
        }

        // print message on the screen that the order was processed

        public void Processorder()
        {
            Console.WriteLine($"Order {OrderId} processed!.");

        }
    }
}
