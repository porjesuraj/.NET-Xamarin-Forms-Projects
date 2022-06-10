using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EventAndDelegate.MultiCastDelegate
{
    class RenderingEngine
    {
        public RenderingEngine()
        {
            GameEventManager.OnGameStart += StartGame;

            GameEventManager.OnGameOver += GameOver;
        }
        public void StartGame()
        {
            Console.WriteLine("Rendering Engine Started");
            Console.WriteLine("Drawing Visuals ..");

        }

        public void GameOver()
        {
            Console.WriteLine("Rendering Engine Stopped");
        }

    }
}
