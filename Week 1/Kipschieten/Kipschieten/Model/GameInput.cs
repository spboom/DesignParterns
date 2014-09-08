using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class GameInput
    {
        public Game Game { get; set; }
        public Queue<Coordinate> Input { get; set; }

        public GameInput()
        {
            Input = new Queue<Coordinate>();
        }


    }
}
