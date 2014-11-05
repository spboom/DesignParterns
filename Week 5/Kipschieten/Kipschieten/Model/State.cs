using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public abstract class State
    {
        public State()
        { }

        public virtual void paint(Graphics graphics)
        { }

        public virtual void update(double dt)
        { }

        public virtual void render()
        { }
    }
}
