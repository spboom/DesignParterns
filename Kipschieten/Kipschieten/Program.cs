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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int Width = 300, Height = 301;
            GameController gameController = new GameController();
            Game game = new Game(gameController, Width, Height);
            InputController inputController = new InputController(game);
            Form1 view = new Form1(Width, Height, inputController);
            view.Subscribe(game);
            new Thread(() => { gameController.start(); }).Start();
            view.Show();
            game.start();

        }
    }
}
