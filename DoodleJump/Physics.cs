using System;
using System.Collections.Generic;
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

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            velocity = 0.4f;
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
            }

            Collide();
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

        public void AddForce()
        {
            gravity = -10;
        }
    }
}
