using Singleton_Pattern.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    class Program
    {

        /// <summary>
        /// Singleton is a object creation design pattern , while static is a keyword
        /// Singleton provides us object, while static classes provides us static methods
        /// Singleton obey conventional class ,while static class does'nt allow a constructor
        /// S can implement interfaces, inherit from other classes and align with OOps concept
        /// S support object disposal , object cloning,its stored in heap
        /// static class stored on stack, there are created when any method in class is static
        /// </summary>
        /// <param name="args"></param>
        #region Difference between Singleton and static classes

        static void Main(string[] args)
        {
            // static class 
            double celcius = 37, fahrenheit = 98.6;
            Console.WriteLine($"Value of {celcius} celcius to farenheit is {Converter.ToFarenheit(celcius)}");
            
            Console.WriteLine($"Value of {fahrenheit}  farenheit to celcius is {Converter.ToCelcius(fahrenheit)}");

            Console.ReadLine();




              
        }
        #endregion

        #region Lazy vs Eager Loading(initialization
        static void Main2(string[] args)
        {
            // here instance are created first, so its eager init
            // also CLR takes care of variavle init and thread safety
            Parallel.Invoke(
                () => PrintEmployeeDetails_Eager(),
                () => PrintStudentDetails_Eager()
                );

            // we can convert eager to lazy init by using Lazy keyword

            Parallel.Invoke(
               () => PrintEmployeeDetails_Lazy(),
               () => PrintStudentDetails_Lazy()
               );


            Console.ReadLine();
        }

        private static void PrintEmployeeDetails_Eager()
        {
            Singleton_Eager fromEmployee = Singleton_Eager.GetInstance;
            fromEmployee.PrintDetials("From Employee ");
        }

        private static void PrintStudentDetails_Eager()
        {
            Singleton_Eager fromStudent = Singleton_Eager.GetInstance;
            fromStudent.PrintDetials("From Student");
        }


        private static void PrintEmployeeDetails_Lazy()
        {
            Singleton_Lazy fromEmployee = Singleton_Lazy.GetInstance;
            fromEmployee.PrintDetials("From Employee ");
        }

        private static void PrintStudentDetails_Lazy()
        {
            Singleton_Lazy fromStudent = Singleton_Lazy.GetInstance;
            fromStudent.PrintDetials("From Student");
        }
        #endregion


        #region Create Singleton class 
        static void Main1(string[] args)
        {
            /* running the two methods in parralel shows that in multi threaded environment
             multiple instance are created of singleton object, due to race condition 
            */
            Parallel.Invoke(
                () => PrintEmployeeDetails(),
                () => PrintStudentDetails()
                );


            //  PrintStudentDetails();

            //  PrintEmployeeDetails();


            #region if Singleton class is not Sealed, we can create multiple instance using derived class
            /*Console.WriteLine("-----------------------");
         Singleton.DerivedSingleton derivedObj = new Singleton.DerivedSingleton();
         derivedObj.PrintDetials("from Derived");*/
            #endregion



            Console.ReadLine();
        }

        private static void PrintEmployeeDetails()
        {
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetials("From Employee ");
        }

        private static void PrintStudentDetails()
        {
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetials("From Student");
        }
        #endregion

    }
}
