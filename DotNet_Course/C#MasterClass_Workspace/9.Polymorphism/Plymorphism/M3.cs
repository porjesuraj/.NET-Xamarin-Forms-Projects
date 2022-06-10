using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Polymorphism.Inheritence_Challenge_Classes
{
    class M3 : BMW
    {
        public M3(double hp, string color, string model) : base(hp, color, model)
        {
        }

        // Not Allowed
     /*   public override void Repair()
        {
            base.Repair();
        }*/
    }
}
