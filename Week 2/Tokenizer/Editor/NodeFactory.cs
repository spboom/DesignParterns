using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class NodeFactory
    {
        public static Node createIf(List<Token> condition, List<Token> statement)
        {
            Node conditionNode = new Node(condition);
            Node statementNode = new Node(statement);

            ConditionalJump ifNode = new ConditionalJump();

            conditionNode.Next = ifNode;

            return null;
        }

        public static Node createElseIf()
        {

            return null;
        }

        public static Node createWhile()
        {

            return null;
        }

        public static Node createElse()
        {

            return null;
        }

        public static Node createDoWhile()
        {

            return null;
        }

        public static Node createFor()
        {

            return null;
        }

    }
}
