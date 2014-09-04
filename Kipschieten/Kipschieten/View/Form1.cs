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
    public partial class Form1 : Form, IObserver<Game>
    {
        private InputController Controller { get; set; }

        private IDisposable unsubscriber;
        private Label ScoreLabel;
        public Form1(int w, int h, InputController controller)
        {
            InitializeComponent();
            ClientSize = new Size(w, h);
            Controller = controller;
            ScoreLabel = new Label();
            ScoreLabel.Location = new Point(13, 13);
            Controls.Add(ScoreLabel);
            Controller.setView(this);
        }

        public void draw(Game game)
        {
            SolidBrush sb = new SolidBrush(Color.Black);
            Graphics grfx = CreateGraphics();
            grfx.Clear(Color.White);

            ScoreLabel.Text = "Score: " + game.Score;


            for (int i = 0; i < game.KipList.Count; i++)
            {
                Kip kip = game.KipList[i];

                Rectangle rect = new Rectangle((int)kip.Left, (int)kip.Top, (int)kip.Size, (int)kip.Size);
                grfx.FillEllipse(sb, rect);
            }
            grfx.Dispose();
            sb.Dispose();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //game.clickedOnPoint(e.X, e.Y);
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

        public void OnNext(Game value)
        {
            draw(value);
        }

        public virtual void Subscribe(IObservable<Game> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
