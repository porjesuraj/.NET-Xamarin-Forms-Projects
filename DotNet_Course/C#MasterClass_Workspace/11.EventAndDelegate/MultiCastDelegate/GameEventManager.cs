using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EventAndDelegate.MultiCastDelegate
{
    class GameEventManager
    {

        // create a new delegate 
        public delegate void GameEvent();

        // create two event variable of delegate
      public static event  GameEvent OnGameStart, OnGameOver;

     // a static method to trigger OnGameStart

        public static void TriggerGameStart()
        {
            // check if the OnGameStart event is not empty, meaning the other methods already subscribed
            if(OnGameStart != null)
            {
                Console.WriteLine("the game has started...");

                // call the OnGameStart that will trigger all the methods subscribed to this event
                OnGameStart();
            }
        }

        public static void TriggerGameOver()
        {
            if(OnGameOver != null)
            {
                Console.WriteLine("the game is over");
                OnGameOver();

            }
        }
    }
}
