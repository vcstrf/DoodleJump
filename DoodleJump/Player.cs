﻿using System;
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
        private string _projectFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();

        public Player()
        {
            string playerSpritePath = Path.Combine(_projectFolderPath, $"Sprites\\floppa.png");
            sprite = Image.FromFile(playerSpritePath);
            physics = new Physics(new PointF(100, 100), new Size(150, 150));
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}


