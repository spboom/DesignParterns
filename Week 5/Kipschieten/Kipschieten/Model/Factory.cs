using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class Factory
    {
        public static GameObject createGameObject(String Class, Game game)
        {
            String Namespace = typeof(Factory).Namespace;
            Type type = Type.GetType(Namespace + "." + Class);
            GameObject gameObject = (GameObject)Activator.CreateInstance(type, game, 0);
            return gameObject;
        }
    }
}
