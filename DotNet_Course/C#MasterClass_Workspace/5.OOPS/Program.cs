using _5.OOPS.Classes_Basics;
using _5.OOPS.Members_Basics;
using _5.OOPS.Property_Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.OOPS
{
    class Program
    {

       #region Finalizer and Class Member
         static void Main(string[] args)
         {
            Members members = new Members();
            members.Introducing(false);

            members.Introducing(true);

            Console.ReadLine();


         }
         #endregion

        #region Properties Demo
        static void Main3(string[] args)
        {

            Box box = new Box(3,4,5);

           // box.SetLength(12); 
           // box.Height = -4;
           // box.Width = 5;

            Console.WriteLine("Box Length is {0}",box.GetLength());
            Console.WriteLine("Box Width is {0}",box.Width);
            box.DisplayInfo();

            Console.WriteLine("Front Surface of Box is {0} sq.metre",box.FrontSurface);

            Console.ReadLine();
                 
        }
        #endregion

        #region Consturctor demo
        static void Main2(string[] args)
        {

            Human Suraj = new Human("suraj", "porje");
            
            Human NewHuman = new Human("raj", "dhinge", "Black", 27);

            Human Micheal = new Human("Micheal");

            Suraj.IntroduceMyself();
            NewHuman.IntroduceMyself();
            Micheal.IntroduceMyself();
            Console.ReadLine();
        }
        #endregion
        #region Classes_Basics
        static void Main1(string[] args)
        {

            Human suraj = new Human();

            suraj.firstName = "Suraj";

            suraj.IntroduceMyself();


            Human raj = new Human();

            raj.firstName = "Rajkumar";
            raj.lastName = "Dhinge";
            raj.IntroduceMyself();




            Console.ReadLine();
        }
        #endregion

    }
}
