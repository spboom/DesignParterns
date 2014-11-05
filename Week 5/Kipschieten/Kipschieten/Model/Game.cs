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
        public GameController Controller { get; private set; }
        public int Score { get; set; }


        public State State { get; set; }

        static int fps = 60;
        public static double MilisecondsSleep { get { return 1000 / fps; } }




        public Game(GameController controller, int width, int height)
        {
            Controller = controller;
        }

        public void start()
        {
            Stopwatch time = Stopwatch.StartNew();


            while (Program.running)
            {
                try
                {
                    long dt = time.ElapsedMilliseconds;
                    time.Restart();
                    State.update(dt);
                    State.render();
                    Controller.paint();

                    Thread.Sleep(TimeSpan.FromMilliseconds(MilisecondsSleep - dt > 0 ? MilisecondsSleep - dt : 0));
                }
                catch { }
            }
        }

        public bool running { get; set; }


    }
}
