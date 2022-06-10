using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.OOPS.Property_Basics
{
    class Box
    {
        // member variable 
        private int length;
        
      

        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 0)
                    height = -value;
                else 
                    height = value;
            }
        }

        public int Width { get; set; }

        /* private int width;
         public int Width
         {
             get
             {
                 return this.width;
             }

             set
             {
                 width = value;
             }
         }*/

        private  int volume;

        public int Volume
        {
            get
            {
                return  this.length * this.Width * this.Height; ;
            }
           
        }

        public void SetLength(int length)
        {
            if(length < 0)
               throw new Exception("Length should be higher than zero");
            else 
               this.length = length;
        }

        public int GetLength()
        {
            return this.length;
        }

        /* public int GetVolume()
         {
             return this.length * this.Width * this.height;
         }*/


        public int FrontSurface
        {   get
            {
                return Height * length;
            }
        }

        public Box(int length,int height,int width)
        {
            this.length = length;
            Height = height;
            Width = width;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(" length is {0} and height is {1} and width is {2} so the volume is {3}",length,Height,Width,Volume);

        }

    }
}
