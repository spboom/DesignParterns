using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Chicken : GameModel
    {
        public override int MAXSIZE
        {
            get
            {
                return 60;
            }
        }
        public override int MINSIZE
        {
            get
            {
                return 40;
            }
        }

        public override int MAXXSPEED
        {
            get
            {
                return 5;
            }
        }

        public override int MAXYSPEED
        {
            get
            {
                return MAXXSPEED;
            }
        }

        public override int MINXSPEED
        {
            get
            {
                return 1;
            }
        }

        public override int MINYSPEED
        {
            get
            {
                return MINXSPEED;
            }
        }


        public int Score { get { return Math.Abs(XSpeed) + Math.Abs(YSpeed); } }

        public Chicken(Game game, int size)
            : base(game, size)
        {
            setDataStructures(new List<HashSet<GameModel>>() { game.ClickList, game.CollidableList, game.CollidesList, game.DrawList, game.MoveList });
        }

        public Chicken(Game game, int size, int xPos, int yPos, int xSpeed, int ySpeed) :
            base(game, size, xPos, yPos, true, true, xSpeed, ySpeed)
        {
            setDataStructures(new List<HashSet<GameModel>>() { game.ClickList, game.CollidableList, game.CollidesList, game.DrawList, game.MoveList });
        }

        public override System.Drawing.Brush Color
        {
            get
            {
                return System.Drawing.Brushes.Black;
            }
        }

        public override void kill()
        {
            Field.Game.Score += Score;
            base.kill();
        }
    }
}
