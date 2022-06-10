using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegateDemo
{
    class Program
    {
        static void Main4(string[] args)
        {
            Func<string> Print = delegate ()
            {
                return "uisng anonymous method";
            };
            // Print = null;
            Console.WriteLine(Print?.Invoke());

            Console.ReadLine();
        }


        static void Main3(string[] args)
        {
            Func<string> Print = () => 
            {
                return "SP";
            };
            // Print = null;
            Console.WriteLine(Print?.Invoke());

            Console.ReadLine();
        }

        static void Main2(string[] args)
        {
            Func<string> Print = PrintMyName;
           // Print = null;
            Console.WriteLine(Print?.Invoke());

            Console.ReadLine();
        }

        private static string PrintMyName()
        {
            return "Suraj";
        }

        static void Main(string[] args)
        {
            
            Func<int,int,int> Addition = Sum;

            int one = 10, two = 20;

            Console.WriteLine(Addition?.Invoke( one ,  two));

            Console.ReadLine();
        }

        private static int Sum(int arg1, int arg2)
        {
            return arg1 + arg2; 
        }
    }
}
