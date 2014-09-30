using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Token
    {
        public int Line;
        public int LinePos;
        public String Value;
        public Type EnumType;
        public int EnumValue;
        public int Level;
        private Token partner;

        public Token Partner
        {
            get { return partner; }
            set
            {
                partner = value;
                if (value != null && value.Partner != this)
                {
                    value.Partner = this;
                }
            }
        }

        public Token(int lineNr, int level)
        {
            Line = lineNr;
            Level = level;
        }
    }
}
