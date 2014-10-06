using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public  class Node
    {
        public Token Value { get; set; }
        // TODO: string[]

        private Node next;
        public Node Next
        {
            get { return next; }
            set
            {
                next = value;
                if (value != null && value.Previous != this)
                {
                    value.Previous = this;
                }
            }
        }

        public Node previous;
        public Node Previous
        {
            get { return previous; }
            set
            {
                previous = value;
                if (value != null && value.Next != this)
                {
                    value.Next = this;
                }
            }
        }


        public Node(Token value)
        {
            Value = value;
        }

        public void insertBefore(Node value)//TODO koppel next
        {
            Previous = value;
        }

        public void insertAfter(Node value)
        {
            Next = value;
        }
    }
}
