using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Kip
    {

        public static int DEFAULTSIZE { get { return 50; } }
        public static int DEFAULTMAXSPEED { get { return 5; } }
        private Field Field { get; set; }

        public int Score { get; private set; }

        public bool hitKip { get; set; }


        public Coordinate Center { get; set; }

        public int XSpeed { get; set; }

        public int YSpeed { get; set; }

        public double Size { get; set; }

        public double Left { get { return Center.X - Size / 2; } }
        public double Right { get { return Center.X + Size / 2; } }

        public double Top { get { return Center.Y - Size / 2; } }
        public double Bottom { get { return Center.Y + Size / 2; } }

        public Kip(int xpos, int ypos, int xspeed, int yspeed, int size, Field field)
        {
            Field = field;
            Center = new Coordinate(xpos, ypos);
            XSpeed = xspeed;
            YSpeed = yspeed;
            Size = size;
            Score = (int)(Math.Abs(XSpeed) + Math.Abs(YSpeed));
        }

        public void step()
        {
            if (Top <= 0 && YSpeed < 0 || Bottom >= Field.Height && YSpeed > 0)
            {
                YSpeed *= -1;
            }

            else if (Left <= 0 && XSpeed < 0 || Right >= Field.Width && XSpeed > 0)
            {
                XSpeed *= -1;
            }

            Center.X += XSpeed;
            Center.Y += YSpeed;

            bool hit = false;
            foreach (Kip kip in Field.Game.KipList)
            {
                if (kip != this && Kip.KipHitKip(this, kip))
                {
                    hit = true;
                    break;
                }
            }
            hitKip = hit;
        }

        public static bool isHit(Coordinate point, Kip kip)
        {
            return Coordinate.distanceBetween(point, kip.Center) <= kip.Size / 2;
        }

        public static bool KipHitKip(Kip kip1, Kip kip2)
        {
            return Coordinate.distanceBetween(kip1.Center, kip2.Center) <= kip1.Size / 2 + kip2.Size / 2;
        }
    }
}
