using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DecisionMaking
{
    class Program
    {
        #region Assignment 3 : Ternary Operator

        static void Main(string[] args)
        {
            int temperature = 0;
            string message = string.Empty;
            try
            {
              Console.WriteLine("Enter the temparature value ");

                string temp = Console.ReadLine();

                if (int.TryParse(temp, out temperature))
                {
                    message = temperature <= 15 ? "it is too cold here" :
                        (temperature >= 16 && temperature <= 28) ? "it is ok" :
                        temperature > 28 ? "it is hot here" : "no result";

                    Console.WriteLine("temparature is {0} and {1}",temperature,message);


                }else
                    Console.WriteLine("Not a valid Temperature");

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

        #region Enhanced if Statement

        static void Main8(string[] args)
        {
            int temperature = -5;

            string stateOfMatter;

            if (temperature < 0)
                stateOfMatter = "solid";
            else
                stateOfMatter = "liquid";

            Console.WriteLine("When Temparature is {0}, State of Matter is {1}",temperature ,stateOfMatter);

            // in short
            temperature += 30;
            stateOfMatter = temperature < 0 ? "solid" : "liquid";

            Console.WriteLine("When Temparature is {0}, State of Matter is {1}", temperature, stateOfMatter);


            temperature += 100;

            // it is eveluated as   a ? b : (c ? d : e); 
            stateOfMatter = temperature < 0 ? "solid" : temperature > 100 ? "gaseous" : "liquid";

            Console.WriteLine("When Temparature is {0}, State of Matter is {1}", temperature, stateOfMatter);

            Console.ReadLine();


        }
        #endregion

        #region Assignment 2 : Check HighScore

        static int  highScore = 200;
        static string highScorePlayer = "Allo Arjun";
        static void Main7(string[] args)
        {
            string playerName;
            int playerScore;
            Console.WriteLine("please enter player Name");

            try
            {
                playerName = Console.ReadLine();

                Console.WriteLine("Please Enter Player Score");

                int.TryParse(Console.ReadLine(), out playerScore);

                if(playerScore > 0)
                {
                    CheckHighScore(playerName, playerScore);

                }
                CheckHighScore(playerName, playerScore);

            }
            catch (Exception ex) 
            {

                Console.WriteLine("Error message : " + ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }

        }

        private static void CheckHighScore(string playerName, int playerScore)
        {
           if (playerScore > highScore)
            {
                highScore = playerScore;
                highScorePlayer = playerName;
                Console.WriteLine("New High Score is " + highScore);
                Console.WriteLine("New High Score holder is " + playerName);

            }else
            {
                Console.WriteLine("the old highscore of " + highScore + " count not be broken and is still held by  " + highScorePlayer );
               

            }
        }
        #endregion
        #region Switch Case I
        static void Main6(string[] args)
        {
            Console.WriteLine("please enter Age");
            try
            {
                int age = int.Parse(Console.ReadLine());



                if (age > 0)
                {
                    switch (age)
                    {
                        case 18:
                            Console.WriteLine("too young to party");
                            break;
                        case 25:
                            Console.WriteLine("too old to party");
                            break;
                        default:
                            Console.WriteLine("no  party at any age");

                            break;
                    }

                    Console.WriteLine("Enter  User name ");
                    string name = Console.ReadLine();

                    switch (name)
                    {
                        case "suraj":
                            Console.WriteLine("user name is " + name );
                            break;
                        default:
                            Console.WriteLine("please try again with username");
                            break;
                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message : " + ex.Message + " " + ex.HelpLink);


            }
            finally
            {
                Console.ReadLine();
            }

        }

        #endregion

        #region Assignment register and Login page


        static string email, password;

        static void  Main5(string[] args)
        {
          
            bool isRegistered;

            try
            {
                Register();

                Login();
               

             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error message : " + ex.Message);

              
            }finally
            {
                Console.ReadLine();
            }

        }

        private static void Login()
        {
            Console.WriteLine("Please Enter your Email");

          if(email == Console.ReadLine())
            {
                Console.WriteLine("Please enter your Password");
                if (password == Console.ReadLine())
                {
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.WriteLine("Login Failed ,incorrent user details");
                }
            }
           
        }

        private static void Register()
        {
            Console.WriteLine("Please Enter your Email");

            email = Console.ReadLine();

            Console.WriteLine("Please enter your Password");
            password = Console.ReadLine();
            bool isEmail = ValideEmail(email);

            if (isEmail && !String.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Welcome User , Registered Successful");
                Console.WriteLine("---------------------------------------");
            }else
            {
                Console.WriteLine("Register Failed, as user detail not entered ");
            }
        }

        private static bool ValideEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            
            return match.Success;
        }
        #endregion

        #region Nested If Statement
        static void Main4(string[] args)
        {
            bool isAdmin = false;
            bool isRegistered = true;
            string userName = "";

            Console.WriteLine("Please Enter your User Name ");

            userName = Console.ReadLine();


            try
            {

                if (isRegistered && userName != "" && userName.Equals("admin"))
                {
                    Console.WriteLine(" Hi there, registered User");

                  
                        Console.WriteLine("Hi there , " + userName);

                        
                            Console.WriteLine("Hi there, Admin ");

                        
                    
                }


                if(isAdmin || isRegistered)
                {
                    Console.WriteLine("You are logged  in");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("error message : " + ex.Message);
            }finally
            {
                Console.ReadLine();

            }
        }

        #endregion

        #region If-else And Try parse

        static void Main3(string[] args)
        {
            Console.WriteLine("Enter the temparature ");
            try
            {
                string temp =Console.ReadLine();

                int temparature,number;

                if (int.TryParse(temp,out number))
                {
                    temparature = number; 
                }else
                {
                    temparature = 0;
                    Console.WriteLine("value enter was non numeric , temp set to 0");
                }

                if (temparature < 10)
                {
                    Console.WriteLine("Take the coat");
                }
                else if (temparature == 10)
                {
                    Console.WriteLine("its 10 degree C*");



                }
                else
                {
                    Console.WriteLine("Cozy and Warm");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("message : " + ex.Message);

            }
            finally
            {
                Console.ReadLine();
            }


        }
        #endregion

        #region TryParse Demo

        static void Main2(string[] args)
        {
            Console.WriteLine("Enter Number to parse ");
            try
            {

                string enterNumber = Console.ReadLine();
                bool success = int.TryParse(enterNumber, out int parsedValue);
                if (success)
                {
                    Console.WriteLine("is parse successful =  {0} , \n number is {1}", success,parsedValue);

                }else
                {
                    Console.WriteLine("parsing {0} failed",enterNumber);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("message : " + ex.Message);
            }finally
            {
                Console.ReadLine();
            }
           

        }
        #endregion

        #region if-else loop
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter the temparature ");
            try
            {
                int temparature = int.Parse(Console.ReadLine());

                if (temparature < 10)
                {
                    Console.WriteLine("Take the coat");
                }
                else if (temparature == 10)
                {
                    Console.WriteLine("its 10 degree C*");



                }
                else
                {
                    Console.WriteLine("Cozy and Warm");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("message : " + ex.Message);

            }
            finally
            {
                Console.ReadLine();
            }


        }
        #endregion

    }
}
