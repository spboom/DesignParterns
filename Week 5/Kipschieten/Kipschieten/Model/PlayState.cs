using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class PlayState : State, IObserver<String>
    {
        private Level level;
        public Level Level
        {
            get { return level; }
            set
            {
                level = value;
                if (Level != null)
                {
                    Level.Subscribe(this);
                }
            }
        }

        Game Game { get; set; }

        public PlayState(Game game)
        {
            Game = game;
            Level = LevelFactory.nextLevel(0);
        }

        public override void update(double dt)
        {
            Level.update(dt);
        }

        public override void paint(Graphics graphics)
        {
            //grfx.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            foreach (GameObject gameObject in Level.DrawList.ToArray())
            {
                Rectangle rect = new Rectangle((int)gameObject.Left, (int)gameObject.Top, (int)gameObject.Size, (int)gameObject.Size);

                graphics.FillEllipse(gameObject.Color, rect);
            }
        }


        public override void render()
        {
            Program.blockingqeueu.set(Game);
        }

        public void OnCompleted()
        { }

        public void OnError(Exception error)
        { }

        public void OnNext(string value)
        {
            int id;
            int.TryParse(value, out id);
            if (id > 0)
            {
                Level = LevelFactory.nextLevel(id);
                return;

                Game game = new Game(Game.Controller, Program.WIDTH, Program.HEIGHT);
                Game.State = new PlayState(game);
            }
            else
            {
                Game.Controller.ShowDialog("You Lost, you're final score is: " + Game.Score);
                Environment.Exit(1);
            }
        }
    }
}
