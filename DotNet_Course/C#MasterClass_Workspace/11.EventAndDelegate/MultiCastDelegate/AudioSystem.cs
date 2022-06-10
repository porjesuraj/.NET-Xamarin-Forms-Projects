using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EventAndDelegate.MultiCastDelegate
{
    class AudioSystem
    {
        public AudioSystem()
        {
            // subscribe to the OnGameStart and OnGameOver events
            GameEventManager.OnGameStart += StartGame;

            GameEventManager.OnGameOver += GameOver;

        }
        public void StartGame()
        {
            Console.WriteLine("Audio system Started");
            Console.WriteLine("Playing Audio ..");

        }

        public void GameOver()
        {
            Console.WriteLine("Audio system Stopped");
        }
    }
}
