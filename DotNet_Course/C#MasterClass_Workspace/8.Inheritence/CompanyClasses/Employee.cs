using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.CompanyClasses
{
    class Employee
    {
        public Employee(string name, string firstName, double salary)
        {
            Name = name;
            FirstName = firstName;
            Salary = salary;
        }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public double Salary { get; set; }


        public virtual void Work()
        {
            Console.WriteLine("I {0} am Working",Name);

        }

        public virtual void Pause()
        {
            Console.WriteLine("I am Taking a Break");

        }
    }

}
