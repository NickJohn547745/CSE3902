﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class BottomRightWall : Wall
    {
        public BottomRightWall()
        {

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(720, 589, 560, 135);
        }
    }
}
