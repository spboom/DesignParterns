using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class Token
    {
        public int Line;
        public int LinePos;
        public String Value;
        public Type EnumType;
        public int EnumValue;
        public int Level;
        public Token[] Partners;

        public Token(int lineNr, int level)
        {
            Line = lineNr;
            Level = level;
        }
    }
}
