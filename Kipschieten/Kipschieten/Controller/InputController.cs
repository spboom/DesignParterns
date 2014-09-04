using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kipschieten.Model;
using Kipschieten.View;

namespace Kipschieten.Controller
{
    public class InputController
    {
        private Form1 view;
        private Game game;

        public InputController(Game game)
        {
            this.game = game;
        }

        public void setView(Form1 view)
        {
            this.view = view;
        }

        public void click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                game.clickedOnPoint(e.X, e.Y);
            }
        }
    }
}
