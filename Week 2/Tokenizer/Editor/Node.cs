using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class Node<T>
    {
        public T Value { get; set; }


        private Node<T> next;
        public Node<T> Next
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

        public Node<T> previous;
        public Node<T> Previous
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


        public Node(T value)
        {
            Value = value;
        }

        public void insertBefore(Node<T> value)
        {
            Previous = value;
        }

        public void insertAfter(Node<T> value)
        {
            Next = value;
        }
    }
}
