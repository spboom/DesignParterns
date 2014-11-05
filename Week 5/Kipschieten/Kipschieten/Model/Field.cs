using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Game Game { get; private set; }

        public Field(int width, int height, Game game)
        {
            Width = width;
            Height = height;
            Game = game;
        }
    }
}
