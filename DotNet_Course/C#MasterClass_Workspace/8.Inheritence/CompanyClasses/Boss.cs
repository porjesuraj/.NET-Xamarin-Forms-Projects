using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.CompanyClasses
{
    class Boss : Employee
    {
        public Boss(string name, string firstName, double salary,string companyCar) : base(name, firstName, salary)
        {
            CompanyCar = companyCar;
        }

        public string CompanyCar { get; set; }

        public void Lead()
        {
            Console.WriteLine("I {0} am the Boss  of the Company , if you work as hard as me , you can buy the {1} car i drive in 5 years, that costs 1 million dollar",Name, CompanyCar);
        }
    }
}
