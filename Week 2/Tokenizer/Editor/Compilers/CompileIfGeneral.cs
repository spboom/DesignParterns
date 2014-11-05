using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class CompileIfGeneral : Compiler
    {
        public CompileIfGeneral()
        { }

        public static override Node Compile(List<Token> tokenList)
        {
            int i = 1;
            Token close = tokenList[i].Partner;
            i++;

            Node FirstConditionNode = null;
            Node LastConditionNode = null;
            while (tokenList[i] != close)
            {
                Node node = new Node(tokenList[i]);
                LastConditionNode.Next = node;
                LastConditionNode = node;
                if (FirstConditionNode == null)
                {
                    FirstConditionNode = LastConditionNode;
                }
                i++;
            }
            Node FirstStatementNode = null;
            Node LastStatementNode = null;
            i++;
            close = tokenList[i].Partner;
            while (tokenList[i] != close)
            {
                Node node = new Node(tokenList[i]);
                LastStatementNode.Next = node;
                LastStatementNode = node;
                if (FirstConditionNode == null)
                {
                    FirstStatementNode = LastStatementNode;
                }
                i++;
            }

            return null;
        }
    }
}