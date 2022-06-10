using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Inheritence.InterfaceClasses
{
    class Chair : Furniture, IDestroyable
    {
        public string DestructionSound { get; set; }

        public Chair(string color, string material)
        {
            this.Color = color;
            this.Material = material;
            this.DestructionSound = "ChairDestructionSound.mp3";
        }


        public void Destroy()
        {
            Console.WriteLine($"The {Color} chair was Destroyed");
            Console.WriteLine("playing destruction sound {0}",DestructionSound);
            Console.WriteLine("Spawning chair parts");
        }
    }
}
