using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Physics
    {
        public Transform transform;
        float gravity;
        float velocity;
        public float dx;
        bool usedBonus = false;


        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            velocity = 0.7f;
            dx = 0;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        public void CalculatePhysics()
        {
            if (dx != 0)
            {
                transform.position.X += dx;
            }

            if (transform.position.Y < 700)
            {
                transform.position.Y += gravity;
                gravity += velocity;

                if (gravity > -20 && usedBonus)
                {
                    PlatformController.GenerateRandomPlaform();
                    PlatformController.startPlatformPosY = 500;
                    PlatformController.GenerateStartSequence();
                    PlatformController.startPlatformPosY = 0;
                    usedBonus = false;
                }
            }

            Collide();
        }

        public bool StandartCollidePlayerWithObjects(bool forMonsters, bool forBonuses)
        {
            if (forMonsters)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    var enemy = PlatformController.enemies[i];
                    PointF delta = new PointF();
                    delta.X = (transform.position.X + transform.size.Width / 2) - (enemy.physics.transform.position.X + enemy.physics.transform.size.Width / 2);
                    delta.Y = (transform.position.Y + transform.size.Height / 2) - (enemy.physics.transform.position.Y + enemy.physics.transform.size.Height / 2);
                    if (Math.Abs(delta.X) <= transform.size.Width / 2 + enemy.physics.transform.size.Width / 2)
                    {
                        if (Math.Abs(delta.Y) <= transform.size.Height / 2 + enemy.physics.transform.size.Height / 2)
                        {
                            if (!usedBonus)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            if (forBonuses)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    var bonus = PlatformController.bonuses[i];
                    PointF delta = new PointF();
                    delta.X = (transform.position.X + transform.size.Width / 2) - (bonus.physics.transform.position.X + bonus.physics.transform.size.Width / 2);
                    delta.Y = (transform.position.Y + transform.size.Height / 2) - (bonus.physics.transform.position.Y + bonus.physics.transform.size.Height / 2);
                    if (Math.Abs(delta.X) <= transform.size.Width / 2 + bonus.physics.transform.size.Width / 2)
                    {
                        if (Math.Abs(delta.Y) <= transform.size.Height / 2 + bonus.physics.transform.size.Height / 2)
                        {
                            if (bonus.type == 1 && !usedBonus)
                            {
                                usedBonus = true;
                                AddForce(-40);
                            }
                            if (bonus.type == 2 && !usedBonus) 
                            {
                                usedBonus = true;
                                AddForce(-40);
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool StandartCollide()
        {
            for (int i = 0; i < PlatformController.bullets.Count; i++)
            {
                var bullet = PlatformController.bullets[i];
                PointF delta = new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) - (bullet.physics.transform.position.X + bullet.physics.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) - (bullet.physics.transform.position.Y + bullet.physics.transform.size.Height / 2);
                if (Math.Abs(delta.X) <= transform.size.Width / 2 + bullet.physics.transform.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= transform.size.Height / 2 + bullet.physics.transform.size.Height / 2)
                    {
                        PlatformController.RemoveBullet(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public void Collide()
        {
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                if (transform.position.X + transform.size.Width / 2 >= platform.transform.position.X && 
                    transform.position.X + transform.size.Width / 2 <= platform.transform.position.X + platform.transform.size.Width)
                {
                    if (transform.position.Y + transform.size.Height >= platform.transform.position.Y && 
                        transform.position.Y + transform.size.Height <= platform.transform.position.Y + platform.transform.size.Height)
                    {
                        if (gravity > 0)
                        {
                            AddForce();
                            if (!platform.isTouched)
                            {
                                PlatformController.score += 20;
                                PlatformController.GenerateRandomPlaform();
                                platform.isTouched = true;
                            }
                        }
                    }
                }
            }

        }

        public void AddForce(int force = -20)
        {
            gravity = force;
        }
    }
}
