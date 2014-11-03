using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class Tree : GameObject
    {

        public Tree(Level level, int size)
            : base(level, size)
        {
            setDataStructures(new List<HashSet<GameObject>>() { level.DrawList, level.CollidableList });
        }

        public Tree(Level level, int size, int xPos, int yPos)
            : base(level, size, xPos, yPos, false, true)
        {
            setDataStructures(new List<HashSet<GameObject>>() { level.DrawList, level.CollidableList });
        }

        public override System.Drawing.Brush Color
        {
            get
            {
                return System.Drawing.Brushes.LawnGreen;
            }
        }


        public override int MAXSIZE
        {
            get { return 70; }
        }

        public override int MINSIZE
        {
            get { return 50; }
        }

        public override int MAXYSPEED
        {
            get { return 0; }
        }

        public override int MINYSPEED
        {
            get { return 0; }
        }

        public override int MAXXSPEED
        {
            get { return 0; }
        }

        public override int MINXSPEED
        {
            get { return 0; }
        }
    }
}
