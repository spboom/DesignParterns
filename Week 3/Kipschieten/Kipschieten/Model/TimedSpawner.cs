using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Kipschieten.Model
{
    class TimedSpawner<T> : Spawner<T> where T : GameObject
    {
        private static int MAXSPAWNTIME { get { return 10; } }
        private static int MINSPAWNTIME { get { return 5; } }

        private System.Timers.Timer timer;

        public TimedSpawner(Game game)
            : base(game)
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += timer_Elapsed;
            setSpawnTime();
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            spawn((T)Factory.createGameObject(typeof(T).Name, Game));
        }

        private void setSpawnTime()
        {
            timer.Interval = TimeSpan.FromSeconds(new Random().Next(MINSPAWNTIME, MAXSPAWNTIME)).TotalMilliseconds;
        }

        public override void spawn(T gameObject)
        {
            base.spawn(gameObject);
            setSpawnTime();
        }

        public void spawn()
        {
            timer_Elapsed(null, null);
        }
    }
}
