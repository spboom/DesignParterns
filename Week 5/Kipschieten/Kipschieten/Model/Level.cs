using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Level : IObservable<String>
    {
        IObserver<String> observer;

        int amountToLoze = 10;
        int killsForNextLevel = 10;
        int kills;
        public Field Field { get; private set; }

        public int levelScore;

        public double spawnMax;
        public double spawnMin;

        public HashSet<GameObject> ClickList = new HashSet<GameObject>();
        public HashSet<GameObject> DrawList = new HashSet<GameObject>();
        public HashSet<GameObject> CollidesList = new HashSet<GameObject>();
        public HashSet<GameObject> CollidableList = new HashSet<GameObject>();
        public HashSet<GameObject> MoveList = new HashSet<GameObject>();

        public TimedSpawner<Chicken> chickenSpawner;
        public float Id { get; set; }

        public Level(int width, int height, Game game, float id)
        {
            Id = id;
            Field = new Field(width, height, game);
            levelScore = 0;
            kills = 0;
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

            if (MoveList.Count >= amountToLoze)
            {
                observer.OnNext("-1");
            }

            else if (kills >= killsForNextLevel)
            {
                observer.OnNext("" + Id);
            }
        }
        public void clickedOnPoint(Coordinate coordinate)
        {
            foreach (GameObject gameObject in ClickList.ToArray())
            {
                if (GameObject.isHit(coordinate, gameObject))
                {
                    gameObject.kill();
                    kills++;
                    break;
                }
            }
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            this.observer = observer;
            return null;
        }
    }
}
