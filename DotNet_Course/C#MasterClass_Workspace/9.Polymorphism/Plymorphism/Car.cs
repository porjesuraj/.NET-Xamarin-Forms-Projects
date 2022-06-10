using _9.Polymorphism.Plymorphism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Polymorphism.Inheritence_Challenge_Classes
{
    class Car
    {
        public double HP { get; set; }

        public string Color { get; set; }

        // has a relationshi[ 

        protected CarIDInfo carIDInfo = new CarIDInfo();

        public void SetCarIDInfo(int idnum,string owner)
        { 
            carIDInfo.IDNUm = idnum;
            carIDInfo.Owner = owner;
        }

        public void GetCarIdInfo()
        {
            Console.WriteLine($"the car has the ID : {carIDInfo.IDNUm} and owned by {carIDInfo.Owner}");
        }

        public Car(double hp, string color)
        {
            HP = hp;
            Color = color;

        }


        public virtual string ShowDetails()
        {
            return $" the car color is {Color} and HP is {HP}";
        }

        public virtual void Repair()
        {
            Console.WriteLine("Car was Repaired!");

        }
    }
}
