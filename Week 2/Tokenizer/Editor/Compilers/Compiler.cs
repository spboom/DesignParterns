using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Compiler
    {
        protected static Node First;
        protected static Node Last;

        public virtual static Node Compile(List<Token> tokenList)
        {
            return null;
        }

        public static Token getLastToken()
        {
            return null;
        }
    }
}
