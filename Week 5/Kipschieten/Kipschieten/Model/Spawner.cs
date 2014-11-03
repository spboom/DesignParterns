using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class Spawner<T> where T : GameObject
    {

        protected Level Level;

        public Spawner(Level game)
        {
            Level = game;
        }
        public virtual void spawn(T gameObject)
        {
            Random r = new Random();
            int x, y, xs, ys, size;
            size = r.Next(gameObject.MINSIZE, gameObject.MAXSIZE);
            x = r.Next(Level.Field.Width - size) + size / 2;
            y = r.Next(Level.Field.Height - size) + size / 2;
            xs = r.Next(gameObject.MINXSPEED, gameObject.MAXXSPEED) * (int)Math.Pow(-1, r.Next(2));
            ys = r.Next(gameObject.MINYSPEED, gameObject.MAXYSPEED) * (int)Math.Pow(-1, r.Next(2));

            gameObject.Size = size;
            gameObject.Center.X = x;
            gameObject.Center.Y = y;
            gameObject.XSpeed = xs;
            gameObject.YSpeed = ys;
        }
    }
}
