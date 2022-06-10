using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EventAndDelegate.MultiCastDelegate
{
    class Player
    {
        public string PlayerName { get; set; }

        public Player(string playerName)
        {
            PlayerName = playerName;
            GameEventManager.OnGameStart += StartGame;

            GameEventManager.OnGameOver += GameOver;

          
        }

        public void StartGame()
        { 
            Console.WriteLine("Spawning Player with ID  : {0}",PlayerName);
            

        }

        public void GameOver()
        {
            Console.WriteLine("Removing  Player with ID  : {0}", PlayerName);

        }
    }
}
