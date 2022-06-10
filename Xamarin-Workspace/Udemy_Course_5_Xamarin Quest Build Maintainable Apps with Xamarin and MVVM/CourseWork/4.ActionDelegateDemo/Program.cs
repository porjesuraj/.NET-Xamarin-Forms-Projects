using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.ActionDelegateDemo
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Action<int> Print = ConsolePrint;

            Action<int> Print2 = new Action<int>(ConsolePrint);


            Action<int> Print3 = delegate (int i)
            {
                ConsolePrint(i);

            };


            Action<int> Print4 = s =>
            {
                ConsolePrint(s);
            };


            Print4?.Invoke(500);


            Print3?.Invoke(200);


            Print?.Invoke(100000);
            Print2?.Invoke(000);

            Console.ReadLine();
         }

        private static void ConsolePrint(int obj)
        {
            Console.WriteLine(obj);
        }

        static void Main1(string[] args)
        {
            Action<string> Conveters = StringTOInt;

            Conveters.Invoke("1234");

            Console.ReadLine();
        }

        private static void StringTOInt(string obj)
        {
            int number;
          int.TryParse(obj,out number);

            ///    number = int.Parse(obj);

            Console.WriteLine(number);
        }
    }
}
