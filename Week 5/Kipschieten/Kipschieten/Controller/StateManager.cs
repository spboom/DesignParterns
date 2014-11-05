using Kipschieten.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Controller
{
    public class StateManager
    {
        List<GameState> gameStates = new List<GameState>();
        int lastIndex;

        public StateManager() { lastIndex = gameStates.Count - 1; }

        public void addState(GameState state)
        {
            gameStates.Add(state);
            gameStates.ElementAt(lastIndex).onEnter();
        }

        public void deleteState()
        {
            if(gameStates.Count != 0)
            {
                if(gameStates.ElementAt(lastIndex).onExit())
                {
                    gameStates.RemoveAt(lastIndex);
                }
            }
        }

        public void changeState(GameState state)
        {
            if(gameStates.Count != 0)
            {
                if(gameStates.ElementAt(lastIndex).getStateID() == state.getStateID())
                {
                    return;
                }
                else if (gameStates.ElementAt(lastIndex).onExit())
                {
                    gameStates.RemoveAt(lastIndex);
                }
            }

            // Voeg state toe
            gameStates.Add(state);

            // Initialiseer state
            gameStates.ElementAt(lastIndex).onEnter();
        }

        public void update(int dt)
        {
            if (gameStates.Count != 0)
            {
                gameStates.ElementAt(lastIndex).update(dt);
            }
        }

        public void render()
        {
            if (gameStates.Count != 0)
            {
                gameStates.ElementAt(lastIndex).render();
            }
        }
    }
}
