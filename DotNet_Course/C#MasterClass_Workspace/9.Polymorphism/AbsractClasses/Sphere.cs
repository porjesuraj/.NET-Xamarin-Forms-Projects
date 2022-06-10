using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Polymorphism.AbsractClasses
{
    class Sphere : Shape
    {
        public const float PI = 3.14f;

        public Sphere(double radius)
        {
            Name = "Sphere";
            Radius = radius;
        }

        public double Radius { get; set; }
        public override double Volume()
        {
            return (4 / 3) * PI * Radius * Radius;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"the radius of sphere is {Radius} and volume is {Volume():N}");
        }

    }
}
