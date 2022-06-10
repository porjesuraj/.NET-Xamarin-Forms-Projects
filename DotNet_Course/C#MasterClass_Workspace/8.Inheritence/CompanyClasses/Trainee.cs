using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.CompanyClasses
{
    class Trainee : Employee
    {
       

        public double WorkingHours { get; set; }

        public double SchoolHours { get; set; }

        public Trainee(string name, string firstName, double salary, double wHours, double sHours) : base(name, firstName, salary)
        {
            WorkingHours = wHours;
            SchoolHours = sHours;
        }

        public void Learn()
        {
            Console.WriteLine("I {0} as a trainee ,am Learning for {1} Hrs",Name,SchoolHours);
        }
        public override void Work()
        {
            Console.WriteLine("Trainee{0} Work for  {1} Hr",Name,WorkingHours);
        }
    }
}
