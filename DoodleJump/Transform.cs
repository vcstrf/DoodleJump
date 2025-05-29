﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Transform
    {
        public PointF position;
        public Size size;

        public Transform(PointF position, Size size)
        {
            this.position = position;
            this.size = size;
        }
    }
}
