using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Game
    {
        private GameController Controller { get; set; }
        public int Score { get; set; }


        public Level Level { get; set; }

        static int fps = 60;
        public static double MilisecondsSleep { get { return 1000 / fps; } }




        public Game(GameController controller, int width, int height)
        {
            Level = new Level(new Field(width, height, this),1);
            Level.chickenSpawner = new TimedSpawner<Chicken>(this);
            Controller = controller;
        }

        public void start()
        {
            Stopwatch time = Stopwatch.StartNew();

            Spawner<GameObject> spawner = new Spawner<GameObject>(this);

            spawner.spawn(Factory.createGameObject("Tree", this));
            spawner.spawn(Factory.createGameObject("Tree", this));


            while (Program.running)
            {
                try
                {
                    long dt = time.ElapsedMilliseconds;
                    time.Restart();
                    update(dt);
                    render();
                    paint();

                    Thread.Sleep(TimeSpan.FromMilliseconds(MilisecondsSleep - dt > 0 ? MilisecondsSleep - dt : 0));
                }
                catch { }
            }
        }

        private void paint()
        {
            Controller.paint();
        }

        private void render()
        {
            Program.blockingqeueu.set(this);
        }

        private void update(double dt)
        {
            Level.update(dt);
        }

        public bool running { get; set; }

       
    }
}
