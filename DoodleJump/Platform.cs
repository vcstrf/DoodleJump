using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DoodleJump
{
    public class Platform
    {
        Image sprite;
        public Transform transform;
        public int sizeX;
        public int sizeY;
        public bool isTouched;
        private string _projectFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();

        public Platform(PointF pos)
        {
            string platformSpritePath = Path.Combine(_projectFolderPath, $"Sprites\\platform.png");
            sprite = Image.FromFile(platformSpritePath);
            sizeX = 150;
            sizeY = 50;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouched = false;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
