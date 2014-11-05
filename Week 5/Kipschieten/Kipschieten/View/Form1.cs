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


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                GameController.gameController.clickedOnPoint(new Coordinate(e.X, e.Y));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Program.Game.State.paint(e.Graphics);
            Text = "Kipschieten - Score: " + Program.Game.Score;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.endGame();
        }
    }
}
