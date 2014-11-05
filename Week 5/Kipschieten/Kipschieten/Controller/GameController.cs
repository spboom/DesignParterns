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

        Form1 view;

        public static GameController gameController;

        public static BlockingContainer<GameInput> inputContainer = new BlockingContainer<GameInput>();

        private Game game;

        public GameController(Form1 view)
        {
            gameController = this;
            this.view = view;
        }

        public void setGame(Game game)
        {
            this.game = game;
        }

        public void paint()
        {
            view.Invalidate();
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

        public void start()
        {
            while (Program.running)
            {
                Thread.Sleep(1000);
            }
        }

        public void clickedOnPoint(Coordinate coordinate)
        {
            GameInput input = inputContainer.get();
            if (input == null)
            {
                input = new GameInput();
            }
            input.Game = game;
            input.Input.Enqueue(coordinate);

            inputContainer.set(input);
        }

        public void ShowDialog(string message)
        {
            Form form = new Form();
            form.Width = 500;
            form.Height = 150;
            form.StartPosition = FormStartPosition.CenterParent;

            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = message };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(confirmation);
            form.Controls.Add(textLabel);
            form.AcceptButton = confirmation;
            form.ShowDialog();

        }
    }
}
