using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Player
    {
        public Physics physics;
        public Image sprite;

        public Player()
        {
            //sprite = Properties.Resources.man;
            physics = new Physics(new PointF(100, 350), new Size(40, 40));
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
