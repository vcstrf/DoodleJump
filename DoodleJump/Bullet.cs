using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Bullet
    {
        public Physics physics;
        public Image sprite;
        private string _projectFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();

        public Bullet(PointF pos)
        {
            string playerSpritePath = Path.Combine(_projectFolderPath, $"Sprites\\bullet.png");
            sprite = Image.FromFile(playerSpritePath);
            physics = new Physics(pos, new Size(50, 50));
        }

        public void MoveUp()
        {
            physics.transform.position.Y -= 15;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
