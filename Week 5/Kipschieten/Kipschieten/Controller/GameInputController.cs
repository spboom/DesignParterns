using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class GameInputController
    {
        public Game Game { get; set; }
        public Queue<Coordinate> Input { get; set; }

        public GameInputController()
        {
            Input = new Queue<Coordinate>();
        }
    }
}
