using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpApp2.Classes;
using static System.Console;
namespace CSharpApp2
{
    class Program
    {

        static IOperations omaths;
        static void Main(string[] args)
        {
            BankAccount bankAccount1 = new BankAccount(10000, "Suraj");
            ChildBankAccount bankAccount2 = new ChildBankAccount(1000, "ganesh", "shiv");
            WriteLine("Old balance {0}", bankAccount1.Balance);

            bankAccount1.AddBalance(5000f);
            WriteLine("New balance {0}", bankAccount1.Balance);


            WriteLine("using method overload Old balance {0}", bankAccount1.Balance);

            bankAccount1.AddBalance(5f, false);
            WriteLine(" using method overload  New balance {0}", bankAccount1.Balance);


            WriteLine("child object Old balance {0}", bankAccount2.Balance);

            bankAccount2.AddBalance(5f);
            WriteLine(" child object  New balance {0}", bankAccount2.Balance);


            AdvancedMath maths = new AdvancedMath();

            WriteLine($" Remainder of 7 and 3 is { maths.Remainder(7, 3)}");

            omaths = new AdvancedMath();

            WriteLine($"using Interface reference and class Object \n Remainder of 10 and 3 is { omaths.Remainder(10, 3)}");


            WriteLine("asyncronous programming ");

            GetData();

            ReadLine();
        }

        static void Main2(string[] args)
        {

            #region Object with default constructor and public fields
            /* BankAccount bankAccount1 = new BankAccount();

             bankAccount1.owner = "Jane Doe";
             bankAccount1.balance = 12000.34f;

             BankAccount bankAccount2 = new BankAccount();

             bankAccount2.owner = "John Cena";
             bankAccount2.balance = 10000.5f;

             WriteLine(bankAccount1.AddBalance(100f));
             WriteLine(bankAccount2.AddBalance(100f));*/
            #endregion

            BankAccount bankAccount3 = new BankAccount(10000, "Suraj");
            WriteLine(bankAccount3.AddBalance(100f));
            ReadLine();
        }



        static void Main1(string[] args)
        {

            Console.WriteLine(SimpleMath.Add(100.4f, 100.5f));


            Console.ReadLine();
        }
    
    
       async static void GetData()
        {
            BankAccount bankAccount = new BankAccount(5000, "Loki");

            WriteLine("Log In");
         var task = await  bankAccount.GetData();

            WriteLine(task);
        }
    
    }

    interface IOperations
    {
        float Remainder(float dividend, float divisor);
    }

    class AdvancedMath : SimpleMath, IOperations
    {
        public float Remainder(float dividend, float divisor)
        {
            if (dividend == 0 || divisor == 0)
                return 0;

            return dividend % divisor;
        }
    }

    class SimpleMath
    {
        public static float Add(float n1, float n2)
        {
            return n1 + n2; 
        }
        public static float Sub(float n1, float n2)
        {
            return  n1 - n2;
        }
        public static float Mult(float n1, float n2)
        {
            if (n1 == 0 || n2 == 0)
                return 0;

            return n1 * n2;
        }
        public static float Div(float n1, float n2)
        {
            if (n1 == 0 || n2 == 0)
                return 0;

            return n1 / n2;
        }

       
    }
}
