using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Game : IObservable<Game>
    {
        private GameController Controller { get; set; }

        private List<IObserver<Game>> observers;

        public int Score { get; set; }

        public List<Kip> KipList = new List<Kip>();
        public Field field { get; set; }

        static int fps = 60;
        static double MilisecondsSleep { get { return 1000 / fps; } }

        public Game(GameController controller, int width, int height)
        {
            Controller = controller;
            field = new Field(width, height);
            observers = new List<IObserver<Game>>();
        }

        public void start()
        {
            Stopwatch time = Stopwatch.StartNew();
            Kip kip = new Kip(0, 0, 1, 1, 50, field);
            KipList.Add(kip);
            bool running = true;
            while (running)
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
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNext(this);
            }

        }

        private void render()
        {

        }

        private void update()
        {
            for (int i = 0; i < KipList.Count; i++)
            {
                KipList[i].step();
            }
        }

        public bool running { get; set; }

        public void clickedOnPoint(int x, int y)
        {
            for (int i = 0; i < KipList.Count; i++)
            {
                if (Kip.isHit(x, y, KipList[i]))
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
