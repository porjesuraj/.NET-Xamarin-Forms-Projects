using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGameAssignment
{
    class SecondApproach
    {
      public  static char[,] board = new char[3, 3]
         {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
         };
        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;
            SetField();
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO('O',input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO('X',input);
                }
                SetField();
                #region Check Winning Condition
                char[] playerChars = { 'X', 'O' };
                foreach (char  playerChar in playerChars)
                {
                    if(    ((board[0,0] == playerChar) && (board[0, 1] == playerChar) && (board[0, 3] == playerChar))
                        || ((board[1, 0] == playerChar) && (board[1, 1] == playerChar) && (board[1, 3] == playerChar))
                        || ((board[2, 0] == playerChar) && (board[2, 1] == playerChar) && (board[2, 3] == playerChar))
                        || ((board[0, 0] == playerChar) && (board[1, 0] == playerChar) && (board[2, 0] == playerChar))
                        || ((board[0, 1] == playerChar) && (board[1, 1] == playerChar) && (board[2, 1] == playerChar))
                        || ((board[0, 2] == playerChar) && (board[1, 2] == playerChar) && (board[2, 2] == playerChar))
                        || ((board[0, 0] == playerChar) && (board[1, 1] == playerChar) && (board[2, 2] == playerChar))
                        || ((board[0, 2] == playerChar) && (board[1, 1] == playerChar) && (board[2, 0] == playerChar))
                        )
                    {
                        if(playerChar == 'X')
                          Console.WriteLine("\n player 2 has won!");
                        else
                         Console.WriteLine("\n player 1 has won!");
                        
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();

                        // TO DO RESET Field
                        ResetField();
                        break;
                    }else if(turns == 10)
                    {
                        Console.WriteLine("Please press any key to reset the game ");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                   
                }
                #endregion

                #region Test if filed is already taken
                do
                {
                    try
                    {
                        Console.WriteLine("\n Player {0} : Choose your field! ", player);
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) { Console.WriteLine("Enter a Number");}

                    if ((input == 1) && (board[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (board[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (board[0, 2] == '3'))
                        inputCorrect = true;

                    else if ((input == 4) && (board[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (board[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (board[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (board[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 9) && (board[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (board[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input ! please use another field");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion
            } while (true);
            Console.ReadLine();
        }

        private static void EnterXorO(char playerSign,int input)
        {
            switch (input)
            {
                case 1: board[0, 0] = playerSign; break;
                case 2: board[0, 1] = playerSign; break;
                case 3: board[0, 2] = playerSign; break;
                case 4: board[1, 0] = playerSign; break;
                case 5: board[1, 1] = playerSign; break;
                case 6: board[1, 2] = playerSign; break;
                case 7: board[2, 0] = playerSign; break;
                case 8: board[2, 1] = playerSign; break;
                case 9: board[2, 2] = playerSign; break;
                default:
                    break;
            }
        }

        static void SetField()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("    ___|____|____  ");
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("    ___|____|____   ");
            Console.WriteLine("       |    |        ");
            Console.WriteLine("     {0} |  {1} | {2}    ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("       |    |        ");
            turns++;
        }

        public static void ResetField()
        {
              char[,] initialBoard = new char[3, 3]
        {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' }
        };
        board = initialBoard;
            SetField();
            turns++;
        }
    }
    }
