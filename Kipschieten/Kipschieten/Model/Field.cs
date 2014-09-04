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

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
