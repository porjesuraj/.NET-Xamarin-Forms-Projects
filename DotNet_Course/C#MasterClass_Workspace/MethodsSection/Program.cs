using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsSection
{
    class Program
    {
        #region Operators

        static void Main(string[] args)
        {
            int num1 = 5;
            int num2 = 3;
            int num3 = 0;

            //unary operator
            num3 = -num1;
            Console.WriteLine($"num3 is {num3}");

            bool isSunny = true;
            Console.WriteLine("is it sunny? {0}", !isSunny);

            // increment operator 

            int num = 0;
            num++;

                Console.WriteLine("num is {0}",num);
                Console.WriteLine("num is {0}",num++);
                Console.WriteLine("num is {0}",++num);

            // decrement operator 

            num--;
            Console.WriteLine("num is {0}", num);
            Console.WriteLine("num is {0}", num--);
            Console.WriteLine("num is {0}", --num);


            // mathematical operator 

            int result;
            result = num1 + num2;

            Console.WriteLine("reuslt of  num1 + num2 is {0}",result);

            result = num1 * num2;
            Console.WriteLine("reuslt of  num1 * num2 is {0}", result);

            result = num1 / num2;
            Console.WriteLine("reuslt of  num1 / num2 is {0}", result);

            result = num1 % num2;
            Console.WriteLine("reuslt of  num1 % num2 is {0}", result);


            // relational and type operator 
            bool isLower;

            isLower = num1 < num2;

            Console.WriteLine("result of {0} < {1} is {2}",num1,num2,isLower);

            //equality operator 

            bool isEqual;
            isEqual = num1 == num2;
            Console.WriteLine("result of {0} == {1} is {2}", num1, num2, isEqual);

            isEqual = num1 != num2;
            Console.WriteLine("result of {0} != {1} is {2}", num1, num2, isEqual);

            // conditional operator 

            bool isLowerAndSunny;
            isLowerAndSunny = isSunny && isLower;

            Console.WriteLine("result of isLower && isSunny is {0}", isLowerAndSunny) ;

            isLowerAndSunny = isSunny || isLower;

            Console.WriteLine("result of isLower || isSunny is {0}", isLowerAndSunny);


            Console.ReadKey();

        }
        #endregion

        #region Exception Handling
        static void Main5(string[] args)
        {
            Console.WriteLine("Enter a number");

            try
            {
               // int number = int.Parse(Console.ReadLine());


                int num1 = 4, num2 = 0;

                int result = num1 / num2; 
            }
            catch (FormatException ex)
            {

                Console.WriteLine("message 1 = : " + ex.Message);
            }
            catch (OverflowException ex)
            {

                Console.WriteLine("message 2 = : " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("message 3 = : " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("message : " + ex.Message);
            }
            finally
            {
                Console.WriteLine("this is called always");
                Console.ReadLine();
            }
              



             
        }
        #endregion

        #region User Input

        static void Main4(string[] args)
        {


            Add();
          
        }


        static void Add()
        {

            Console.WriteLine("Enter first number ");
            double num1 = double.Parse((Console.ReadLine()));
            Console.WriteLine("Enter second number ");
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.ReadLine();
        }

        #endregion

        #region Assignment1
        static void Main3(string[] args)
        {
            string friend1 = "raj";
            string friend2 = "mohit";
            string friend3 = "shaunak";

            GreetFriend(friend1);
            GreetFriend(friend2);
            GreetFriend(friend3);

            Console.Read();
        }


        static void GreetFriend(string friendName)
        {
            Console.WriteLine($"Hi {friendName} , my friend!");
        }
        #endregion


        #region Method with return type
        /// <summary>
        /// Method with Return type
        /// </summary>
        /// <param name="suraj"></param>

        static void Main2(string[] suraj)
        {

            Console.WriteLine( "Addition = "+Add(Add(1, 2), Add(3, 4)));

            Console.WriteLine("Addition = " + Add(10,20));

            Console.WriteLine("Multiply = " + Multiply(5,5));

            Console.WriteLine("Divide = " + Divide(10,5.5));
            Console.Read();
        }

           static double Divide(double num1,double num2)
            {
            if (num1 > 0 && num2 > 0)
                return num1 / num2;

            else return 0; 
            }
        public static int Multiply(int num1,int num2)
        {
            return num1 * num2;
        }


        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        #endregion


        #region Void Methods
        /// <summary>
        /// Void Methods
        /// </summary>
        /// <param name="args"></param>
        static void Main1(string[] args)
        {
            Write();

            WriteSpecific("I am an argument and i am called from a method ");

            Console.ReadLine();
        }

        public static void WriteSpecific(string text)
        {
            Console.WriteLine(text);

        }

        public static void Write()
        {
            Console.WriteLine("I am called from a method");


        }
        #endregion

    }
}
