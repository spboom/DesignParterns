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

        public HashSet<GameModel> ClickList = new HashSet<GameModel>();
        public HashSet<GameModel> DrawList = new HashSet<GameModel>();
        public HashSet<GameModel> CollidesList = new HashSet<GameModel>();
        public HashSet<GameModel> CollidableList = new HashSet<GameModel>();
        public HashSet<GameModel> MoveList = new HashSet<GameModel>();
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

            Spawner<GameModel> spawner = new Spawner<GameModel>(this);

            spawner.spawn(ObjectFactory.createGameObject("Tree", this));
            spawner.spawn(ObjectFactory.createGameObject("Tree", this));

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
            GameInputController input = GameController.inputContainer.get();
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

            foreach (GameModel gameObject in MoveList.ToArray())
            {
                gameObject.step(dt);
            }

            foreach (GameModel collidesGameObject in CollidesList.ToArray())
            {
                foreach (GameModel collidableGameObject in CollidableList.ToArray())
                {
                    if (collidesGameObject != collidableGameObject && GameModel.isColliding(collidesGameObject, collidableGameObject))
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
            foreach (GameModel gameObject in ClickList.ToArray())
            {
                if (GameModel.isHit(coordinate, gameObject))
                {
                    gameObject.kill();
                    break;
                }
            }
        }
    }
}
