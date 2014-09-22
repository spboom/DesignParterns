using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public abstract class GameObject
    {
        protected Field Field { get; set; }
        public Coordinate Center { get; set; }
        public double Size { get; set; }

        public List<List<GameObject>> DataStructures { get; private set; }

        public static Spawner<GameObject> spawner;

        public abstract int MAXSIZE { get; }
        public abstract int MINSIZE { get; }
        public abstract int MAXYSPEED { get; }
        public abstract int MINYSPEED { get; }
        public abstract int MAXXSPEED { get; }
        public abstract int MINXSPEED { get; }



        public double Left { get { return Center.X - Size / 2; } }
        public double Right { get { return Center.X + Size / 2; } }
        public double Top { get { return Center.Y - Size / 2; } }
        public double Bottom { get { return Center.Y + Size / 2; } }

        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        public bool Collides { get; set; }
        public bool Collidable { get; set; }

        public GameObject(Game game, int size)
        {
            DataStructures = new List<List<GameObject>>();
            Field = game.field; ;
            Size = size;
            Center = new Coordinate(0, 0);
        }

        public GameObject(Game game, int size, int xPos, int yPos, bool collides, bool colidable, int xSpeed = 0, int ySpeed = 0)
            : this(game, size)
        {
            Center = new Coordinate(xPos, yPos);
            XSpeed = xSpeed;
            YSpeed = ySpeed;
            Collides = collides;
            Collidable = colidable;
        }

        public void step(double dt)
        {
            if (Top <= 0 && YSpeed < 0 || Bottom >= Field.Height && YSpeed > 0)
            {
                YSpeed *= -1;
            }

            else if (Left <= 0 && XSpeed < 0 || Right >= Field.Width && XSpeed > 0)
            {
                XSpeed *= -1;
            }

            Center.X += (int)(XSpeed * (dt / Game.MilisecondsSleep));
            Center.Y += (int)(YSpeed * (dt / Game.MilisecondsSleep));
        }


        public void collide()
        {
            foreach (Chicken kip in Field.Game.ClickList)
            {
                //if (kip != this && Kip.KipHitKip(this, kip)) //TODO!!
                {
                    break;
                }
            }
        }

        public static bool isColliding(GameObject object1, GameObject object2)
        {
            return Coordinate.distanceBetween(object1.Center, object2.Center) <= (object1.Size + object2.Size) / 2;
        }

        public virtual void kill()
        {
            removeDataStructures();
        }

        private void removeDataStructures()
        {
            for (int i = 0; i < DataStructures.Count; i++)
            {
                DataStructures[i].Remove(this);
            }
        }

        public void setDataStructures(List<List<GameObject>> dataStructures)
        {
            removeDataStructures();
            
            DataStructures = dataStructures;

            for (int i = 0; i < DataStructures.Count; i++)
            {
                DataStructures[i].Add(this);
            }
        }


        public virtual System.Drawing.Brush Color { get { return System.Drawing.Brushes.Transparent; } }

        public static bool isHit(Coordinate coordinate, GameObject gameObject)
        {
            return Coordinate.distanceBetween(coordinate, gameObject.Center) <= gameObject.Size / 2;
        }
    }
}
