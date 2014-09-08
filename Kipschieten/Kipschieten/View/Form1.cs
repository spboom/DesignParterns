using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kipschieten.Controller;
using Kipschieten.Model;

namespace Kipschieten.View
{
    public partial class Form1 : Form
    {
        public Form1(int w, int h)
        {
            InitializeComponent();
            ClientSize = new Size(w, h);
            BackColor = Color.White;
            DoubleBuffered = true;
        }

        public void draw(Game game, Graphics grfx)
        {
            if (game != null)
            {
                grfx.Clear(Color.White);
                grfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Text = "Kipschieten - Score: " + game.Score;

                for (int i = 0; i < game.KipList.Count; i++)
                {
                    Kip kip = game.KipList[i];

                    Rectangle rect = new Rectangle((int)kip.Left, (int)kip.Top, (int)kip.Size, (int)kip.Size);
                    Brush fill;
                    if (kip.hitKip)
                    {
                        fill = Brushes.Gray;
                    }
                    else
                    {
                        fill = Brushes.Black;
                    }

                    grfx.FillEllipse(fill, rect);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                GameController.gameController.clickedOnPoint(new Coordinate(e.X, e.Y));
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            draw(Program.blockingqeueu.get(), e.Graphics);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.endGame();
        }
    }
}
