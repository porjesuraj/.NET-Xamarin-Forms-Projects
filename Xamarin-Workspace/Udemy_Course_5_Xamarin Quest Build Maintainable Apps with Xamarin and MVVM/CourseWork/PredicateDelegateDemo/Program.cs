using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> CheckForUpperCase = IsUpperCase;


            Predicate<string> CheckForLowerCase = delegate(string s)
            {
                return s.Equals(s.ToLower());
            };

            Predicate<string> CheckForNUll = s => string.IsNullOrEmpty(s);


            string one = "HELLO";
                string two = "hello";

            string three = "";
         var result1 =   CheckForUpperCase?.Invoke(one);

            Console.WriteLine( $"{one} Is Upper  {result1}");

            var result2 = CheckForLowerCase(two);

            Console.WriteLine($"{two} Is Lower  {result2}");


            var result3 = CheckForNUll?.Invoke(three);
            Console.WriteLine($"{three} string Is Null/Empty {result3}");


            Console.ReadLine();
        
        }

        private static bool IsUpperCase(string obj)
        {
            return obj.Equals(obj.ToUpper());
        }
    }
}
