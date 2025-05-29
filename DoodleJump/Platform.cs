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

        public Platform(PointF pos)
        {
            //sprite = Properties.Resources.Platform;
            sizeX = 60;
            sizeY = 12;
            transform = new Transform(pos, new Size(sizeX, sizeY));
            isTouched = true;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }
}
