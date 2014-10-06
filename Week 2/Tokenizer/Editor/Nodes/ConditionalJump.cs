using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class ConditionalJump : Node
    {
        public Node AlternateNext { get; set; }



        public ConditionalJump()
            : base(null)
        {

        }
    }
}
