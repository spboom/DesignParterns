using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Jump : Node
    {
        private LinkedListNode<Node> jump_location;

        public LinkedListNode<Node> Jump_location { set { jump_location = value; }}

        public Jump() {}

        public LinkedListNode<Node> jump()
        {
            return jump_location;
        }
    }
}
