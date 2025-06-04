using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Bonus
    {
        public Physics physics;
        public Image sprite;
        public int type;
        private string _projectFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();

        public Bonus(PointF pos, int type)
        {
            switch(type)
            {
                case 1:
                    string spritePath = Path.Combine(_projectFolderPath, $"Sprites\\spring.png");
                    sprite = Image.FromFile(spritePath);
                    physics = new Physics(pos, new Size(50, 50));
                    break;
                case 2:
                    spritePath = Path.Combine(_projectFolderPath, $"Sprites\\jetpack.png");
                    sprite = Image.FromFile(spritePath);
                    physics = new Physics(pos, new Size(100, 100));
                    break;
            }
            this.type = type;
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
