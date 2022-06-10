using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.InterfaceClasses
{
    class Ticket : IEquatable<Ticket>
    {
    

        public int DurationInHours { get; set; }
    

        public Ticket(int durationInHours)
        {
            DurationInHours = durationInHours;
        }

        public bool Equals(Ticket other)
        {
            if (this.DurationInHours == other.DurationInHours)
                return true;

            return false;
        }
    }
}
