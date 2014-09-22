using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class Tree : GameObject
    {

        public Tree(Game game, int size)
            : base(game, size)
        {
            setDataStructures(new List<List<GameObject>>() { game.DrawList, game.CollidableList });
        }

        public Tree(Game game, int size, int xPos, int yPos)
            : base(game, size, xPos, yPos, false, true)
        {
            setDataStructures(new List<List<GameObject>>() { game.DrawList, game.CollidableList });
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
