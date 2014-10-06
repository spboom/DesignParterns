using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Level
    {
        public Field Field { get; private set; }

        public int levelScore;

        public HashSet<GameObject> ClickList = new HashSet<GameObject>();
        public HashSet<GameObject> DrawList = new HashSet<GameObject>();
        public HashSet<GameObject> CollidesList = new HashSet<GameObject>();
        public HashSet<GameObject> CollidableList = new HashSet<GameObject>();
        public HashSet<GameObject> MoveList = new HashSet<GameObject>();

        public TimedSpawner<Chicken> chickenSpawner;

        public Level(Field field, int score)
        {
            Field = field;
            levelScore = score;
        }

        public void update(double dt)
        {
            GameInput input = GameController.inputContainer.get();
            if (input != null)
            {
                foreach (Coordinate coord in input.Input)
                {
                    clickedOnPoint(coord);
                }
            }
            if (ClickList.Count == 0)
            {
                chickenSpawner.spawn();
            }

            foreach (GameObject gameObject in MoveList.ToArray())
            {
                gameObject.step(dt);
            }

            foreach (GameObject collidesGameObject in CollidesList.ToArray())
            {
                foreach (GameObject collidableGameObject in CollidableList.ToArray())
                {
                    if (collidesGameObject != collidableGameObject && GameObject.isColliding(collidesGameObject, collidableGameObject))
                    {
                        collidesGameObject.XSpeed *= -1;
                        collidesGameObject.YSpeed *= -1;
                    }
                }
            }
        }
        public void clickedOnPoint(Coordinate coordinate)
        {
            foreach (GameObject gameObject in ClickList.ToArray())
            {
                if (GameObject.isHit(coordinate, gameObject))
                {
                    gameObject.kill();
                    break;
                }
            }
        }
    }
}
