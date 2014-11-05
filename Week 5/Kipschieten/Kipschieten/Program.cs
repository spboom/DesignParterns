using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kipschieten.Controller;
using Kipschieten.Model;
using Kipschieten.View;

namespace Kipschieten
{
    static class Program
    {
        public static bool running;
        public static BlockingContainer<Game> blockingqeueu = new BlockingContainer<Game>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            running = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int Width = 300, Height = 301;
            Form1 view = new Form1(Width, Height);
            GameController gameController = new GameController(view);
            Game game = new Game(gameController, Width, Height);
            new Thread(() => { gameController.start(); }).Start();
            new Thread(() =>
            {
                Application.Run(view);
            }).Start();
            game.start();

        }

        public static void endGame()
        {
            running = false;
        }


    }
}
