using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.State
{
    public class GameState
    {
        public GameState()
        {

        }

        public void update(int dt);
	    public void render();
	    public bool onEnter();
	    public bool onExit();
	    public string getStateID();
    }
}
