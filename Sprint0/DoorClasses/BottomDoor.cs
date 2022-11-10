﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.Interfaces;
using sprint0.RoomClasses;

namespace sprint0.DoorClasses
{
    public class BottomDoor : Door
    {
        public BottomDoor()
        {
            type = ICollidable.objectType.Door;

            HasCollided = false;
            TransitionDirection = Direction.DOWN;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(560, 720, 5 * 32, 5 * 32);
        }
        public override Type GetObjectType()
        {
            return typeof(BottomDoor);
        }
    }
}
