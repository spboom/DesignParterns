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
        public static Game Game;
        public static readonly int WIDTH = 300, HEIGHT = 301;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            running = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 view = new Form1(WIDTH, HEIGHT);
            GameController gameController = new GameController(view);
            Game = new Game(gameController, WIDTH, HEIGHT);
            LevelFactory.init();
            Game.State = new PlayState(Game);
            new Thread(() => { gameController.start(); }).Start();
            new Thread(() =>
            {
                Application.Run(view);
            }).Start();
            Game.start();

        }

        public static void endGame()
        {
            running = false;
        }


    }
}
