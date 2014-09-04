using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kipschieten.Model;
using Kipschieten.View;

namespace Kipschieten.Controller
{
    public class GameController : IObserver<MouseEventArgs>
    {
        private Form1 view;
        private static int Width = 300, Height = 301;

        public GameController()
        {
            Game game = new Game(this, Width, Height);
            InputController inputController = new InputController(game);
            view = new Form1(Width, Height, inputController);
            view.Subscribe(game);

            new Thread(() => { Application.Run(view); }).Start();
            new Thread(() => { game.start(); }).Start();
        }

        public void paint(Game game)
        {
            view.draw(game);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(MouseEventArgs value)
        {

        }
    }
}
