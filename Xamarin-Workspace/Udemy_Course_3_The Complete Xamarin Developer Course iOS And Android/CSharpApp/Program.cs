using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace CSharpApp
{
    class Program
    {
        static float n1 = 200, n2 = 100;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            #region using a class instance
            /* Program p = new Program();



             var a = p.Add(100, 200);

             WriteLine(a);
            */
            #endregion

            var add = Add();
            var sub = Sub();
            var div = Div();
            var mult = Mult();
            WriteLine( "Add = {0} \n Sub = {1} \n Mult = {2} \n Div = {3}",add,sub,mult,div);

            Console.ReadLine();
        }

       private static float Add( )
        {
            return n1 + n2; 

        }

        private static float Sub()
        {
            return Math.Abs(n1 - n2); 
        }

        private static float Mult()
        {
            if (n1 == 0 || n2 == 0)
                return 0;

            return n1 * n2; 
        }

        private static float Div()
        {
            if (n1 == 0 || n2 == 0)
                return 0;

            return n1 / n2; 
        }
    }
}
