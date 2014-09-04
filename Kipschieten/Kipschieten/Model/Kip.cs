using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Kip : IObservable<Kip>
    {
        private Field Field { get; set; }

        public int Score { get; private set; }

        public double XPos { get; set; }

        public double YPos { get; set; }

        public double XSpeed { get; set; }

        public double YSpeed { get; set; }

        public double Size { get; set; }

        public double Left { get { return XPos - Size / 2; } }
        public double Right { get { return XPos + Size / 2; } }

        public double Top { get { return YPos - Size / 2; } }
        public double Bottom { get { return YPos + Size / 2; } }

        private IObserver<Kip> observer;

        public Kip(double xpos, double ypos, double xspeed, double yspeed, double size, Field field)
        {
            Field = field;
            XPos = xpos;
            YPos = ypos;
            XSpeed = xspeed;
            YSpeed = yspeed;
            Size = size;
            Score = (int)(XSpeed + YSpeed);
            step();
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

            XPos += XSpeed;
            YPos += YSpeed;

            if (observer != null)
            {
                observer.OnNext(this);
            }
        }

        public static bool isHit(double xpos, double ypos, Kip kip)
        {
            if (xpos >= kip.Left && xpos <= kip.Right && ypos >= kip.Top && ypos <= kip.Bottom)
            {
                return true; //TODO: calculate area circle
            }
            return false;
        }

        public IDisposable Subscribe(IObserver<Kip> observer)
        {
            this.observer = observer;
            return null;
        }
    }
}
