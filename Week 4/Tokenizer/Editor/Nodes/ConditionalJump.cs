using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class ConditionalJump : Node
    {
        LinkedListNode<Node> jump_true;
        LinkedListNode<Node> jump_false;

        public LinkedListNode<Node> Jump_true { set { jump_true = value; }}

        public LinkedListNode<Node> Jump_false { set { jump_false = value; }}

        public ConditionalJump() {}

        public LinkedListNode<Node> jump(Boolean result)
        {
            if(result)
            {
                return jump_true;
            }
            else
            {
                return jump_false;
            }
        }
    }
}
