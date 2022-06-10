using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Polymorphism.Inheritence_Challenge_Classes
{
    class BMW : Car
    {
        public string Model { get; set; }

        private string brand = "BMW";

        public BMW(double hp, string color,string model) : base(hp, color)
        {
            Model = model;
        }

        public new string ShowDetails()
        {
           return $"The car brand is  {brand}  and Model is {Model} , having {Color} color and Hp of {HP}";

        }

        public sealed override void Repair()
        {
            Console.WriteLine($"The car with brand  {brand}  and Model  {Model} is Repaired");
        }
    }
}
