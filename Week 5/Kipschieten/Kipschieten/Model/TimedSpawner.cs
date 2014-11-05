using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Kipschieten.Model
{
    public class TimedSpawner<T> : Spawner<T> where T : GameObject
    {

        private static Random random = new Random();
        public int maxSpawnTime { get; set; }
        public int minSpawnTime { get; set; }

        private System.Timers.Timer timer;

        public TimedSpawner(Level game, int minInterval, int maxInterval)
            : base(game)
        {
            minSpawnTime = minInterval;
            maxSpawnTime = maxInterval;
            timer = new System.Timers.Timer();
            timer.Elapsed += timer_Elapsed;
            setSpawnTime();
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            spawn((T)Factory.createGameObject(typeof(T).Name, Level));
        }

        private void setSpawnTime()
        {
            timer.Interval = random.Next(minSpawnTime, maxSpawnTime);
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
