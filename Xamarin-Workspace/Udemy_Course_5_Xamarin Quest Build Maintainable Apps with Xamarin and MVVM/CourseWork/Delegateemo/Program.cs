using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegateemo
{
    public delegate void Print(string message);

    public delegate int PrintCount();

    public delegate T Operation<T>(T val1, T val2);
    class Program
    {

        static int count = 0;


        static void Main(string[] args)
        {

            Operation<int> Add = Sum;

            Console.WriteLine($"10 + 20 = {Sum(10, 20)}");

            Operation<string> con = Concat;

            Console.WriteLine(con("Hello","World"));


            Console.ReadLine();

        }


        public static int Sum(int val1, int val2)
        {
            return val1 + val2;
        }

        public static string Concat(string str1, string str2)
        {
            return str1 + str2;
        }













        static void Main4(string[] args)
        {

            PrintCount print1 = HelloMessage.Count;
            PrintCount print2 = GoodByeMessage.Count;

            PrintCount print = print1 + print2;



            Console.WriteLine(print());

            print += () => 300;


            Console.WriteLine(print());


            Console.ReadLine();
        }


        static void Main3(string[] args)
        {
            Print print = HelloMessage.Send;

            print += GoodByeMessage.Send;

            print += s => Console.WriteLine($"See You Next Time {s}");

            print("Test");

            print -= GoodByeMessage.Send;


            print("Test2");
            Console.ReadLine();
        }



        static void Main2(string[] args)
        {

            Print print = HelloMessage.Send;

            InvokeDelegate(print);

            print = GoodByeMessage.Send;


            InvokeDelegate(print);


            print = m => Console.WriteLine($"GoodBye {m}");

            InvokeDelegate(print);



            Console.ReadLine();


        }


        static void InvokeDelegate(Print print)
        {
            
            print($"Visited {++count} Times");
        }




        static void Main1(string[] args)
        {
            Print print = new Print(Message);

            print("Suraj Porje");

            print.Invoke("World");


            print = p => Console.WriteLine($"Bye {p}");

            print("Suraj Porje");


            Console.ReadLine();
        }



      

        static void Message(string msg)
        {
            Console.WriteLine($"Hello {msg}");
        }
    }

    class HelloMessage
    {
        static public void Send(string msg)
        {
            Console.WriteLine($"Hello {msg}");

        }


     public   static  int Count()
        {
            return 100;

        }

    }


    class GoodByeMessage
    {
        static public void Send(string msg)
        {
            Console.WriteLine($"GoodBye {msg}");

        }

        static public int Count()
        {
            return 200;

        }

    }

}
