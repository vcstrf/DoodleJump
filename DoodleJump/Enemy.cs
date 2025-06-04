using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Enemy : Player
    {
        private string _projectFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();
        public Enemy(PointF pos, int type)
        {
            switch(type)
            {
                case 1:
                    string enemySpritePath = Path.Combine(_projectFolderPath, $"Sprites\\ugly.png");
                    sprite = Image.FromFile(enemySpritePath);
                    physics = new Physics(pos, new Size(150, 150));
                    break;
                case 2:
                    enemySpritePath = Path.Combine(_projectFolderPath, $"Sprites\\white.png");
                    sprite = Image.FromFile(enemySpritePath);
                    physics = new Physics(pos, new Size(170, 170));
                    break;
            }
        }
    }
}
