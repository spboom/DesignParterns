using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class LevelFactory
    {
        static Dictionary<float, Level> Levels = new Dictionary<float, Level>();

        public static bool init()
        {
            try
            {
                int min = 5000;
                int max = 10000;
                for (int i = 0; i <= 100; i++)
                {
                    if (min - i * 100 > 0)
                    {
                        min -= i * 100;
                    }
                    if (max > min)
                    {
                        max -= i * 50;
                    }
                    if (max < min)
                    {
                        max = min + 1;
                    }
                    Level level = new Level(Program.WIDTH, Program.HEIGHT, Program.Game, i + 1);
                    level.chickenSpawner = new TimedSpawner<Chicken>(level, min, max);

                    Levels.Add(i, level);
                }
                Levels[100].Id = -1;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Level nextLevel(float id)
        {
            if (Levels.ContainsKey(id))
            {
                return Levels[id];
            }
            return null;
        }
    }
}
