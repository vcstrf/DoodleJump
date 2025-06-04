using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public static class PlatformController
    {
        public static List<Platform> platforms;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Bonus> bonuses = new List<Bonus>();
        public static int startPlatformPosY = 400;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void CreateBullet(PointF pos)
        {
            var bullet = new Bullet(pos);
            bullets.Add(bullet);
        }

        public static void GenerateStartSequence()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = r.Next(100, 500);
                int y = r.Next(120, 160);
                startPlatformPosY -= y;
                PointF position = new PointF(x, startPlatformPosY);
                Platform platform = new Platform(position);
                platforms.Add(platform);
            }
        }

        public static void GenerateRandomPlaform()
        {
            Clear();
            Random r = new Random();
            int x = r.Next(100, 500);
            int y = r.Next(120, 160);
            PointF position = new PointF(x, startPlatformPosY);
            Platform platform = new Platform(position);
            platforms.Add(platform);

            var c = r.Next(1, 3);

            switch (c)
            {
                case 1:
                    c = r.Next(1, 5);
                    if (c == 1)
                    {
                        CreateEnemy(platform);
                    }
                    break;
                case 2:
                    c = r.Next(1, 6);
                    if (c == 1)
                    {
                        CreateBonus(platform);

                    }
                    break;
            }
        }

        public static void CreateBonus(Platform platform)
        {
            Random r = new Random();
            var bonusType = r.Next(1, 3);
            switch(bonusType)
            {
                case 1:
                    var bonus = new Bonus(new PointF(platform.transform.position.X + 50, platform.transform.position.Y - 35), bonusType);
                    bonuses.Add(bonus);
                    break;
                case 2:
                    bonus = new Bonus(new PointF(platform.transform.position.X + 20, platform.transform.position.Y - 75), bonusType);
                    bonuses.Add(bonus);
                    break;
            }
        }

        public static void CreateEnemy(Platform platform)
        {
            Random r = new Random();
            var enemyType = r.Next(1, 3);
            switch(enemyType)
            {
                case 1:
                    var enemy = new Enemy(new PointF(platform.transform.position.X + 18, platform.transform.position.Y - 125), enemyType);
                    enemies.Add(enemy);
                    break;
                case 2:
                    enemy = new Enemy(new PointF(platform.transform.position.X, platform.transform.position.Y - 135), enemyType);
                    enemies.Add(enemy);
                    break;
            }
        }

        public static void RemoveEnemy(int i)
        {
            enemies.RemoveAt(i);
        }

        public static void RemoveBullet(int i)
        {
            bullets.RemoveAt(i);
        }

        public static void Clear()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y >= 1200)
                {
                    platforms.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].physics.transform.position.Y >= 1200)
                {
                    enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i].physics.transform.position.Y >= 1200)
                {
                    bonuses.RemoveAt(i);
                }
            }
        }
    }
}
