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
        public GameController()
        {
        }

        public void paint(Game game)
        {
            throw new NotImplementedException();
            //view.draw(game);
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
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
