using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class Spawner<T> where T : GameModel
    {

        protected Game Game;

        public Spawner(Game game)
        {
            Game = game;
        }
        public virtual void spawn(T gameObject)
        {
            Random r = new Random();
            int x, y, xs, ys, size;
            size = r.Next(gameObject.MINSIZE, gameObject.MAXSIZE);
            x = r.Next(Game.field.Width - size) + size / 2;
            y = r.Next(Game.field.Height - size) + size / 2;
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
