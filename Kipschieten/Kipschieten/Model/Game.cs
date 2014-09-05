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
    public class Game : IObservable<Game>
    {

        private static int MAXSPAWNTIME { get { return 10; } }
        private static int MINSPAWNTIME { get { return 5; } }
        private GameController Controller { get; set; }

        private List<IObserver<Game>> observers;

        public int Score { get; set; }

        public List<Kip> KipList = new List<Kip>();
        public Field field { get; set; }

        static int fps = 60;
        static double MilisecondsSleep { get { return 1000 / fps; } }

        private System.Timers.Timer timer;

        public Game(GameController controller, int width, int height)
        {
            Controller = controller;
            field = new Field(width, height);
            observers = new List<IObserver<Game>>();
            timer = new System.Timers.Timer();
            timer.Elapsed += timer_Elapsed;
            setSpawnTime();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Spawn();
        }

        private void setSpawnTime()
        {
            timer.Interval = TimeSpan.FromSeconds(new Random().Next(MINSPAWNTIME, MAXSPAWNTIME)).TotalMilliseconds;
        }

        public void start()
        {
            Stopwatch time = Stopwatch.StartNew();
            Spawn();
            timer.Start();
            while (Program.running)
            {
                try
                {
                    update();
                    render();
                    paint();

                    Thread.Sleep(TimeSpan.FromMilliseconds(MilisecondsSleep));
                    time.Restart();
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

        private void update()
        {
            GameInput input = GameController.inputContainer.get();
            if (input != null)
            {
                foreach (Coordinate coord in input.Input)
                {
                    clickedOnPoint(coord);
                }
            }
            if (KipList.Count == 0)
            {
                Spawn();
            }

            for (int i = 0; i < KipList.Count; i++)
            {
                KipList[i].step();
            }
        }

        private void Spawn()
        {
            Random r = new Random();
            int x, y, xs, ys, size;
            size = Kip.DEFAULTSIZE;
            x = r.Next(field.Width - size) + size / 2;
            y = r.Next(field.Height - size) + size / 2;
            xs = r.Next(1,Kip.DEFAULTMAXSPEED) * (int)Math.Pow(-1, r.Next(2));
            ys = r.Next(1,Kip.DEFAULTMAXSPEED) * (int)Math.Pow(-1, r.Next(2));
            KipList.Add(new Kip(x, y, xs, ys, size, field));
            setSpawnTime();
        }

        public bool running { get; set; }

        public void clickedOnPoint(Coordinate coordinate)
        {
            for (int i = 0; i < KipList.Count; i++)
            {
                if (Kip.isHit(coordinate.X, coordinate.Y, KipList[i]))
                {
                    Score += KipList[i].Score;
                    KipList.RemoveAt(i);
                    i--;
                }
            }
        }

        public IDisposable Subscribe(IObserver<Game> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber<Game>(observers, observer);
        }
    }
}
