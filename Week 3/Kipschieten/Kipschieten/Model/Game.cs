using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Kipschieten.Controller;

namespace Kipschieten.Model
{
    public class Game
    {
        private GameController Controller { get; set; }

        public int Score { get; set; }

        public HashSet<GameObject> ClickList = new HashSet<GameObject>();
        public HashSet<GameObject> DrawList = new HashSet<GameObject>();
        public HashSet<GameObject> CollidesList = new HashSet<GameObject>();
        public HashSet<GameObject> CollidableList = new HashSet<GameObject>();
        public HashSet<GameObject> MoveList = new HashSet<GameObject>();
        public Field field { get; set; }

        static int fps = 60;
        public static double MilisecondsSleep { get { return 1000 / fps; } }

        private TimedSpawner<Chicken> chickenSpawner;



        public Game(GameController controller, int width, int height)
        {
            chickenSpawner = new TimedSpawner<Chicken>(this);
            Controller = controller;
            field = new Field(width, height, this);
        }

        public void start()
        {
            Stopwatch time = Stopwatch.StartNew();

            Spawner<GameObject> spawner = new Spawner<GameObject>(this);

            spawner.spawn(Factory.createGameObject("Tree", this));
            spawner.spawn(Factory.createGameObject("Tree", this));

            chickenSpawner.spawn();

            while (Program.running)
            {
                try
                {
                    long dt = time.ElapsedMilliseconds;
                    time.Restart();
                    update(dt);
                    render();
                    paint();

                    Thread.Sleep(TimeSpan.FromMilliseconds(MilisecondsSleep - dt > 0 ? MilisecondsSleep - dt : 0));
                }
                catch { }
            }
        }

        private void paint()
        {
            Controller.paint();
        }

        private void render()
        {
            Program.blockingqeueu.set(this);
        }

        private void update(double dt)
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

        public bool running { get; set; }

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
