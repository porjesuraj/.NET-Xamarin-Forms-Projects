using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesAndVariables
{
    class Program
    {

        const double PI = 3.14;
        const int weeks = 52, month = 12;
        const string birthDay = "01/01/1994";

        /// <summary>
        /// Constants demoy
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           

            Console.WriteLine("My Birthday is {0}",birthDay);

            Console.ReadKey();


        }

        /// <summary>
        /// Assignment 3 on Data Types
        /// </summary>
        /// <param name="args"></param>
        static void Main9(string[] args)
        {

            byte bNumber = 255;

            sbyte sbNumber = 127;

            int iNumber = 2000;

            uint uiNumber = 100;

            short sNumber =  32767;

            ushort unNumber = 65535;

            long lNumber = (long)Math.Pow(10, 18);

            ulong ulNumber = (ulong)Math.Pow(10, 18);

            float fNumbwer = 3.40f;

            double dNumber = 1.79;

            char word = 'c';

            bool isProgram = true;

            string Value = "Good";

            decimal decimalNumber = 7.8M;

            string firstValue = "i control text";

            string secondValue = "100";

            int converter = Int32.Parse(secondValue);

            Console.WriteLine(bNumber + "\n" + sbNumber + "\n" + iNumber + uiNumber + "\n" + sNumber + "\n" + unNumber + "\n" + lNumber + "\n" + ulNumber + "\n" +
                fNumbwer + "\n" + dNumber + "\n" + word + "\n" + isProgram + "\n" + Value + "\n" + decimalNumber + "\n" + firstValue + "\n" + converter);

            Console.ReadLine();
        }

        /// <summary>
        /// Assignment 2 on String 
        /// </summary>
        /// <param name="args"></param>
        static void Main8(string[] args)
        {
            string subject;
            char search;
            Console.WriteLine("Enter a string here");
            subject = Console.ReadLine();

            Console.WriteLine("Enter the character to search");

            search = Console.ReadLine()[0];

            int result = subject.IndexOf(search);

           
            Console.WriteLine($"{ search} char was on { result} index");

            Console.WriteLine("Enter your First name, and Press Enter");
          
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your Last name, and Press Enter");

            string lastName = Console.ReadLine();

            string fullName = string.Concat(firstName, " ", lastName);

            Console.WriteLine(fullName);


            Console.ReadLine();


        }
        /// <summary>
        /// Assignment 1 on String 
        /// </summary>
        /// <param name="args"></param>
        static void Main7(string[] args)
        {
            string name;


            Console.WriteLine("Please Enter Your Name and Press Enter");

            name = Console.ReadLine();

            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.ToLower());
            Console.WriteLine(name.Trim());

            Console.WriteLine(name.Substring(1));

            Console.ReadLine();


        }

        /// <summary>
        /// String Manipualtion and methods for that
        /// </summary>
        /// <param name="args"></param>
        static void Main6(string[] args)
        {
            string name = "Suraj";
            string email = " suraj@gmail.com ";
            string subject = " String Manipualtion and methods for that";

            string filter = subject.Substring(7);

            Console.WriteLine(filter);
            Console.WriteLine(filter.ToLower());
            Console.WriteLine(filter.ToUpper());

            // used for email address from a form
           string trimmedEmail = email.Trim();

            Console.WriteLine($"email without spaces {trimmedEmail} ");

            int signIndex = trimmedEmail.IndexOf('@');

            Console.WriteLine($"@ is at position {signIndex}");

            Console.WriteLine("is email null or blank " + string.IsNullOrWhiteSpace(trimmedEmail));

            Console.WriteLine(string.Format("My name is {0}", name));
            
            Console.ReadLine();


        }


        /// <summary>
        /// String ormatting Demo 
        /// </summary>
        /// <param name="args"></param>
        static void Main5(string[] args)
        {
            int age = 31;

            string name = "Sunny";
            string job = "developer";
            // 1. String concatination 
            Console.WriteLine("String Concationation");

            Console.WriteLine("Hello my name is " + name + ", I am " + age + "years old");

            // 2. String formating 
            Console.WriteLine("String Formatting");

            Console.WriteLine("Hello my name is {0} , I am  {1} years old, I'm a {2}",name,age,job);


            // 3. String Interpolation 
            // it uses $ at the start which will allow us to write our variable like {v}

            Console.WriteLine(" String Interpolation ");
            Console.WriteLine($"Hello my name is {name} , I am  {age} years old, I'm a {job}");

            /* 4. Verbatim strings 
             verbatim strings starts with @ and tells the compiler to take the string
            literally and ignore any spaces and escape characters like \n 
            */

            Console.WriteLine("Verbatim Strings");
            Console.WriteLine(@"Hello All,

SCRUM is iterative, incremental methodology for project management often seen in Agile software Development.

This training is intended to enhance your knowledge on Agile Project Development…. So those who are newly introduced to SCRUM and would be implementing the same in the near future, this is a good opportunity for them…. so don’t miss this opportunity and make the most of it.
 ");
            // great use case in case of url or path 

            Console.WriteLine(@"C:\Users\surajpor\Desktop\DotNet_Course\Notes");

            // with these even valid escape char wont work

            Console.WriteLine(@" Bye \n All");
            Console.WriteLine(" Bye \n All");
            Console.ReadLine();
        }

        /// <summary>
        /// Demo for Parsing Datatypes     
        /// </summary>
        /// <param name="args"></param>
        static void Main4(string[] args)
        {
            string myString = "16";

            string mySecondString = "16";

            int num1 = Int32.Parse(myString);
            

            Int32.TryParse(mySecondString, out int num2);

            int intResult = num1 + num2; 

            Console.WriteLine($"{num1} + {num2} = {intResult}");

            Console.ReadLine();

        }

        /// <summary>
        /// Implicit and Explicit Conversion 
        /// </summary>
        /// <param name="args"></param>
        static void Main3(string[] args)
        {
            #region Explicit Conversion
            double myDouble = 15.55;

            int myInt;

            // cast Double  to int 

            myInt = (int)myDouble;

            Console.WriteLine($"double {myDouble} -> int {myInt}");
            #endregion

            #region Implicit Conversion
            int intNumber = 1242234;
            long longNumber = intNumber;

            Console.WriteLine($"int {intNumber} -> long {longNumber}");


            float floatNumber = 2424.45f;
            Double doubleNumber = floatNumber;

            Console.WriteLine($"float {floatNumber} -> double {doubleNumber}");
            #endregion

            #region TypeConversion
            string doubleString = doubleNumber.ToString();

            string floatString = floatNumber.ToString();

            Console.WriteLine($"double to string {doubleString} \n float to string {floatString}");

            bool sunIsShining = false;

           string myBoolString = sunIsShining.ToString();

            Console.WriteLine("bool for sun is shining = {0}", myBoolString);
            #endregion
            Console.ReadLine();
        }

        /// <summary>
        /// Demo of Console Methods 
        /// </summary>
        /// <param name="args"></param>
        static void Main2(string[] args)
        {
            Console.Title = "Hello ";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            

           

            int width = Console.WindowWidth;

            int height = Console.WindowHeight;

           

            Console.SetWindowSize(width - 30, height - 10);
            // it clear default setting and let the new setting apply throughout console 
            Console.Clear();

            Console.WriteLine($"{width} : {height}");
            Console.Write("Hello ");

            Console.WriteLine("User");


            Console.Write("Enter Name");

            string input = Console.ReadLine();

            Console.WriteLine("Hello {0}", input);

            Console.WriteLine("Enter a char ");
            int asciiValue = Console.Read();

            Console.WriteLine("ASCII value is {0}", asciiValue);


          ConsoleKeyInfo key =  Console.ReadKey();

            Console.WriteLine("key pressed " + key.Key);


            Console.Beep();
            Console.ReadLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Demo on Data Type string 
        /// </summary>
        /// <param name="args"></param>
        static void Main1(string[] args)
        {
            string myname = "Suraj";


            Console.WriteLine( "my name is " + myname);

           

            string upper = myname.ToUpper();

            Console.WriteLine(upper);

            string lower = upper.ToLower();

            Console.WriteLine(lower);
       

            Console.Read();
        }
    }
}
