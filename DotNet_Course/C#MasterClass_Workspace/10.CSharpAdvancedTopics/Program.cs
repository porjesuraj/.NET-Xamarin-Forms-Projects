using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.CSharpAdvancedTopics
{

   
    class Program
    {
        /*#region Advanced Topic 1: 
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
        #endregion*/

        #region Advanced Topic 1: Access Modifier
        class A
        {
            protected int no1;
            private int no2;
            public int no3;
        }

        class B : A
        {
            public B()
            {
                //private variable ,cant access
                //  no2 = 110;
                no1 = 110;
            }

        }
        static void Main1(string[] args)
            
        {
            A check = new A();
        // cant access due to protection level
            //  check.no1 = 22;
           // check.no2 = 22;
            check.no3 = 22;
            B hello = new B();
         // cant access 
            //  hello.no1 = 10;
           // hello.no2 = 10;
            hello.no3 = 10;
            Console.ReadLine();
        }
        #endregion
       
        #region Advanced Topic 2: Structs 

        struct Game
        {
            public string name;
            public string developer;
            public double rating;

            public Game(string name, string developer, double rating)
            {
                this.name = name;
                this.developer = developer;
                this.rating = rating;
            }

            public override string ToString()
            {
                return $" name is {name} ,developer is  {developer} ,rating is {rating}";
            }
            public string Display()
            {
                return $" name is {name} ,developer is  {developer} ,rating is {rating}";

            }
        }

        static void Main2(string[] args)
        {
            Game game1;
            game1.name = "COD";
            game1.developer = "Activision";
          
            game1.rating = 4.5;

            Console.WriteLine("Game " + game1.ToString());
            Console.WriteLine(game1.Display());

            Console.ReadLine();
        }
        #endregion

        #region Advanced Topic 3: Enums 

        enum Day { Mo,TU,We,TH,Fr,Sa,Su};
        enum Month { JAN = 1,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC};
        static void Main3(string[] args)
        {
            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;

            Console.WriteLine(fr == a);
            Console.WriteLine(Day.Fr);
            Console.WriteLine((int)Day.Fr);

            Console.WriteLine("------------------------------------");

            var enums = Enum.GetValues(typeof(Month)).Cast<Month>().ToList();

            foreach (var e in enums)
            {
            Console.Write((int) e + ".");
                Console.Write( e);
                Console.WriteLine();
            }
     
            Console.ReadLine();
        }
        #endregion

        #region Advanced Topic 4: Math 
        static void Main4(string[] args)
        {
            Console.WriteLine("Ceiling 15.6 : " + Math.Ceiling(15.6));
            Console.WriteLine("Floor 15.6 : " + Math.Floor(15.6));

            int num1 = 13;
            int num2 = 9;

            Console.WriteLine($"lower of {num1} and {num2} is {Math.Min(num1,num2)}");
            Console.WriteLine($"higher of {num1} and {num2} is {Math.Max(num1,num2)}");

            Console.WriteLine("3 to the power 5 is {0}",Math.Pow(3,5));

            Console.WriteLine("PI is : {0:0.0000}",Math.PI);

            Console.WriteLine("Square root of 25 is {0}",Math.Sqrt(25));
            Console.WriteLine("Always positive is {0}",Math.Abs(-123));

            Console.WriteLine("cos of 1 : {0}",Math.Cos(1));

            Console.ReadLine();
        }
        #endregion
        #region Advanced Topic 5: Random
        enum RandomValues {Yes, No,Maybe};
        static void Main5(string[] args)
        {
            Random dice = new Random();

            int numEyes;

            for (int i = 0; i < 10; i++)
            {
                numEyes = dice.Next(1, 7);
                Console.WriteLine(numEyes);


            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("3 random values");
           
            Random values = new Random();
            int num;
            for (int i = 0; i < 10; i++)
            {
                num = values.Next(0, 3);

                Console.WriteLine(Enum.GetName(typeof(RandomValues),num));

            }

            Console.ReadLine();
        }
        #endregion
        
        #region Advanced Topic 6: Regular Expression
        static void Main6(string[] args)
        {
            string pattern = @"\d{7}";
            Regex regex = new Regex(pattern);

            string text = "Hi , my number is 1321424";
            MatchCollection matchCollection = regex.Matches(text);
            Console.WriteLine("{0} hits found : {1}",matchCollection.Count,text);

            foreach (Match match in matchCollection)
            {
                GroupCollection group = match.Groups;


                Console.WriteLine($"{group[0].Value} found at {group[0].Index} ");


            }

            Console.ReadLine();
        }
        #endregion

        #region Advanced Topic 7: DateTime 
        static void Main7(string[] args)
        {
            DateTime dateTime = new DateTime(1994, 1, 1);
           

            Console.WriteLine("My birthday is {0}",dateTime);

            // todays date
            Console.WriteLine(DateTime.Today);
            // todays time
            Console.WriteLine(DateTime.Now);

            DateTime tommorrow = GetTommorrow();
            Console.WriteLine("Tommorow will be  "+ tommorrow);

            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
            Console.WriteLine("today is {0} ",dayOfWeek);
            Console.WriteLine("first day of year 1994 is {0}",FirstDayOfAYear(1994).DayOfWeek);


            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine("Days in Feb,2000 are {0}",days);
            days = DateTime.DaysInMonth(2001, 2);
            Console.WriteLine("Days in Feb,2001 are {0}", days);

            DateTime now = DateTime.Now;
            Console.WriteLine("Minutes : {0}",now.Minute);

            // display time in x o'clock and y minutes and z seconds 


            Console.WriteLine($"{now.Hour} o'clock and {now.Minute} minutes and {now.Second} seconds");

            // time between two dates
            Console.WriteLine("Enter your BirthDate  in this format: yyyy-mm-dd");
            string input = Console.ReadLine();

            if(DateTime.TryParse(input,out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = DateTime.Now.Subtract(dateTime);
                Console.WriteLine("Days passed Since : {0}",daysPassed.Days);
            }else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadLine();
        }

        static DateTime GetTommorrow()
        {
            return DateTime.Today.AddDays(1);
                
        }

        static DateTime FirstDayOfAYear(int year)
        {
            return new DateTime(year, 1, 1);
        }
        #endregion
        #region Advanced Topic 8: Nullable
        static void Main8(string[] args)
        {

            int? num1 = null;
            // error as value type cant store null
            //  int num2 = null;

            double? num3 = new double?();
            double? num4 = 3.14;
            bool? boolval = new bool?();
            int num5;
            Console.WriteLine($"our nullable numbers are {num1},{num3},{num4}, bool value: {boolval}");

            bool? isMale = null;

            if(isMale == true)
            {
                Console.WriteLine("User is male");

            }else if(isMale == false)
            {
                Console.WriteLine("user is female");
            }else
            {
                Console.WriteLine("No gender choosen");
            }

            //convert nullable to non -nullable

            double? num6 = 13.1;
            double? num7 = null;

            double num8;

            if (num6 == null)
            {

                num8 = 0.0;
            }else
            {
                num8 = (double)num6;

            }

            Console.WriteLine("value of num8 is : {0}",num8);
            
            // from null to non-nullable type 
            // null coleasing operator ??
            num8 = num6 ?? 8.53;
            Console.WriteLine("value of num8 is : {0}", num8);
            num8 = num7 ?? 10;
            Console.WriteLine("value of num8 is : {0}", num8);

            Console.WriteLine(" hi \n hello ");
            Console.WriteLine(@" hi \n hello ");

            Console.ReadLine();
        }
        #endregion

        #region Advanced Topic 9: Garbage Collection 

        class Demo
        {
            public Demo()
            {

                Console.WriteLine("Object created");
            }

            ~Demo()
            {
                Console.WriteLine(" in finalizer , object destroyed");
            }
        }
        static void Main9(string[] args)
        {

            CreateDemo();

            Console.ReadLine();
        }

        private static void CreateDemo()
        {
            Demo demo = new Demo();
            GC.Collect();
        }
        #endregion

        #region Advanced Topic 10: Main Args 
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("no args passed to program,pass Help to get detail");
            }else
            {
                Console.WriteLine("Hello {0}", args[0]);

            }

            if(args[0].ToLower() == "help")
            {
                Console.WriteLine("*************Instructions: ");
                Console.WriteLine("use one of the following commands followed by 2 numbers");
                Console.WriteLine("* 'add': to add 2 numbers");
                Console.WriteLine("* 'sub': to substract 2 numbers");
                Console.WriteLine("***************");
            }

            if(args.Length != 3)
            {
                Console.WriteLine("Invalid arguments , please use help");

                Console.ReadKey();

                // quit the app
                return;
            }
            bool isNum1Parsed = float.TryParse(args[1], out float num1);
            bool isNum2Parsed = float.TryParse(args[2], out float num2);

            float result = 0;
            if(isNum1Parsed && isNum2Parsed)
            {
                switch (args[0])
                {
                    case "add":
                        result = num1 + num2;
                        break;
                    case "sub":
                        result =  num1 - num2;
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"the {args[0]} of {num1} and {num2} = {result}");



            }
            else
            {
                Console.WriteLine("Invlaid Arguments");
            }
           
            Console.ReadLine();
        }
        #endregion
    }
}                          