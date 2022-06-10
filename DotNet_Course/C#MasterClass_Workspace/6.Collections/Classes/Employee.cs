using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Collections.Classes
{
    class Employee
    {

        #region Properties
        public string Role { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public float Rate { get; set; }

        public float Salary
        {
            get
            {
                return Rate * 8 * 5 * 4 * 12;
            }
        }
        #endregion

        #region constructor
        public Employee(string role, string name, int age, float rate)
        {
            Role = role;
            Name = name;
            Age = age;
            Rate = rate;
        }
        #endregion

        public override string ToString()
        {
            return $"Employee Name: {Name}, Role : {Role} ,Age : {Age}, Salary : {Salary}";
        }

    }

}
