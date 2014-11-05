using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class ObjectFactory
    {
        public static GameModel createGameObject(String Class, Game game)
        {
            String Namespace = typeof(ObjectFactory).Namespace;
            Type type = Type.GetType(Namespace + "." + Class);
            GameModel gameObject = (GameModel)Activator.CreateInstance(type, game, 0);
            return gameObject;
        }

        public void NextLevel()
        {

        }
    }
}
