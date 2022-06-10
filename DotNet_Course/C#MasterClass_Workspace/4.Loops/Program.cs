using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Loops
{
    class Program
    {
        /* #region For loop
         static void Main(string[] args)
         {
         }
         #endregion*/

        #region Assignment Loops 
        static void Main(string[] args)
        {
            double averageScore = 0;
            int studentScore = 0;
            int loopCounter = 0;
            int sum = 0;
            try
            {
                while (studentScore != -1)
                {
                    Console.WriteLine("Please enter Student Score, or -1 to Exit");

                    if( int.TryParse(Console.ReadLine(),out studentScore) && studentScore >= 0 && studentScore <= 20)
                    {
                        
                       
                        sum += studentScore;
                        
                        

                    }else
                    {
                        if (studentScore == -1)
                            break;

                        Console.WriteLine("enter score in range of 0 to 20");
                        continue;
                    }

                    Console.WriteLine("Student Score is {0},", studentScore);
                    if(studentScore != -1)
                       loopCounter++;
                }

                averageScore = (double)(sum / loopCounter);
              
                Console.WriteLine("Average marks scored by student are {0} / {1} = {2}",sum,loopCounter, averageScore);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message : " + ex.Message);

                
            }
            finally
            {
                Console.ReadLine();
            }
        }
        #endregion

        #region Break and Continue 
        static void Main5(string[] args)
        {

            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine(counter);

                if(counter == 3)
                {
                    Console.WriteLine("At 3 we stop !");
                    break;
                }

            }

            Console.WriteLine("For continue ");
            for (int counter = 0; counter < 10; counter++)
            {
               

                if (counter %2 == 0)
                {
                    Console.WriteLine("We skip even number");
                    continue;
                }
                Console.WriteLine(counter);
            }

            Console.ReadLine();
        }
        #endregion

        #region While loop
        static void Main4(string[] args)
        {
            int counter = 1;

            string people = string.Empty;

            while (string.IsNullOrEmpty(people))
            {
                Console.WriteLine("Please press enter to increase people count");
                Console.WriteLine("Count increased to " + counter++);
                people = Console.ReadLine();

             

                
            }
            Console.WriteLine("People Count is {0},press enter to end the program",counter);

            Console.ReadLine();
            
        }
        #endregion

        #region Do While Loop
        static void Main3(string[] args)
        {
            int counter = 0;

            int lengthOfText = 0;

            do
            {
                Console.WriteLine("Please enter the name of a friend");
                string nameOfAFriend = Console.ReadLine();
                int currentLength = nameOfAFriend.Length;
                lengthOfText += currentLength;

                Console.WriteLine(counter + 1);
                counter++;

            } while (lengthOfText < 20);

            Console.WriteLine("Thanks ");
            Console.ReadLine();
           
                }
        #endregion

        #region For loop for odd no 0 to 100
        static void Main2(string[] args)
        {
            Console.WriteLine("please enter the lower side for odd numbers");
            int lower = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the upper side for odd numbers");
            int upper = int.Parse(Console.ReadLine());

            Console.WriteLine("Odd no are ");
            for (int i = lower; i <= upper; i++)
            {
                if(i % 2 != 0)
                    Console.Write("{0},",i);


            }

            Console.WriteLine("using second approach");
            for (int i = 1; i <= upper; i+= 2)
            {
               
                    Console.Write("{0},", i);


            }

            Console.ReadLine();
        }
        #endregion

        #region For loop
        static void Main1(string[] args)
        {

            for (int i = 0; i < 50; i+=5)
            {
                Console.WriteLine("for loop has run {0} times",i + 5 );
            }

            Console.ReadLine();
        }
        #endregion

    }
}
                      