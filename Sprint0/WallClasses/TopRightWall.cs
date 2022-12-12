using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.Interfaces;

namespace sprint0.RoomClasses
{
    public class TopRightWall : Wall
    {
        public TopRightWall()
        {
            Type = ICollidable.ObjectType.Wall;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(720, 0, 560, 160);
        }
    }
}
