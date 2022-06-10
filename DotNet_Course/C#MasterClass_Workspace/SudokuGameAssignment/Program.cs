using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGameAssignment
{
    class Program
    {
        static string[,] matrix = new string[3, 3]
            {
                {"1","2","3" },
                {"4","5","6" },
                {"7","8","9" }
            };

        static string[] playerOneIndex = new string[5];
        static string[] playerTwoIndex = new string[5];
        static int counter = 0;
        static void Main1(string[] args)
        {
           
            int startGame = 1;
            int playerOneChoice;
            int playerTwoChoice;
            string player; 
            bool isChoiceInt;
            Console.WriteLine("To start the game, press any number");
            bool isStart =  int.TryParse(Console.ReadLine(), out startGame);

            do
            {
                CreateMatrix();
                player = "player1";
                Console.WriteLine("{0}: Choose your field",player);
                string choice = Console.ReadLine();
              isChoiceInt =  int.TryParse(choice, out playerOneChoice);

                if(!isChoiceInt)
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }else
                {
                    SetPlayerChoice(player,choice);
                   if( CheckForWinner(player))
                    {
                        CreateMatrix();
                        Console.WriteLine("{0} Wins",player);
                        break;
                    }
                }

                Console.Clear();

                CreateMatrix();

                player = "player2";
                Console.WriteLine("{0}: Choose your field",player);
                 choice = Console.ReadLine();
                isChoiceInt = int.TryParse(choice, out playerOneChoice);

                if (!isChoiceInt)
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }
                else
                {
                    SetPlayerChoice(player,choice);
                    if (CheckForWinner(player))
                    {
                        CreateMatrix();
                        Console.WriteLine("{0} Wins", player);
                        break;
                    }
                }

                counter++;
            } while (startGame != 0);


          
           

            Console.ReadLine();
            
        }

        private static bool CheckForWinner(string player)
        {
            int Xcounter = 0;
            int Ocounter = 0;

            // check if rows have all X or O
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   bool isX =  matrix[i, j].Contains("X");
                   bool isO =  matrix[i, j].Contains("O");
                    if (isX)
                    {
                        Xcounter++;
                    }else if (isO)
                    {
                        Ocounter++;
                    }
                }

                if(Xcounter == 3)
                   return true;
                else if(Ocounter == 3)
                      return true;
                  
            }
            Xcounter = 0;
            Ocounter = 0;
            // check if all Column has O or X
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    bool isX = matrix[i, j].Contains("X");
                    bool isO = matrix[i, j].Contains("O");
                    if (isX)
                    {
                        Xcounter++;
                    }
                    else if (isO)
                    {
                        Ocounter++;
                    }
                }

                if (Xcounter == 3)
                    return true;
                else if (Ocounter == 3)
                    return true;

            }
            Xcounter = 0;
            Ocounter = 0;
            // check if diagonal contains all X or O 

            for (int i = 0,j=0; i < matrix.GetLength(0); i++,j++)
            {
                        bool isX = matrix[i, j].Contains("X");
                        bool isO = matrix[i, j].Contains("O");
                        if (isX)
                        {
                            Xcounter++;
                        }
                        else if (isO)
                        {
                            Ocounter++;
                        }
                if (Xcounter == 3)
                    return true;
                else if (Ocounter == 3)
                    return true;

            }
            Xcounter = 0;
            Ocounter = 0;
            // check if diagonal from right to left contains all X or O
            for (int i = 0,j= 2; i < matrix.GetLength(0); i++,j--)
            {
                
                        bool isX = matrix[i, j].Contains("X");
                        bool isO = matrix[i, j].Contains("O");
                        if (isX)
                        {
                            Xcounter++;
                        }
                        else if (isO)
                        {
                            Ocounter++;
                        }
                

                if (Xcounter == 3)
                    return true;
                else if (Ocounter == 3)
                    return true;

            }
           

            return false;
        }

        private static bool SetPlayerChoice(string player ,string choice)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                  if(matrix[i,j] == choice && !playerOneIndex.Contains(choice) && !playerOneIndex.Contains(choice))
                    {
                        if (player == "player1")
                        {
                            matrix[i, j] = "O";
                            playerOneIndex[counter] = choice;

                        }

                        else
                        {
                            matrix[i, j] = "X";
                            playerTwoIndex[counter] = choice;
                        }
                           

                        return true;
                    }else
                    {

                        return false;
                    }

                    


                }

              
            }
            return false;
        }

        private static void CreateMatrix()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
          
            Console.Clear();

            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", matrix[0, 0], matrix[0,1],matrix[0,2]);
            Console.WriteLine("    ___|____|____  ");
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", matrix[1, 0], matrix[1, 1], matrix[1, 2]);
            Console.WriteLine("    ___|____|____   ");
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", matrix[2, 0], matrix[2, 1], matrix[2, 2]);
            Console.WriteLine("       |    |        ");


          /*  for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    Console.Write(" " + matrix[i, j] + " ");

                    if (j < matrix.GetLength(1) - 1)
                        Console.Write("|");


                }
                Console.WriteLine();
                if(i < matrix.GetLength(0) - 1)
                  Console.WriteLine("___ ___ ___ ");
            }*/
        }
    }
}

