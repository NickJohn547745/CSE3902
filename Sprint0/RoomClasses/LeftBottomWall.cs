using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class LeftBottomWall : Wall
    {
        public LeftBottomWall()
        {

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 425, 160, 164);
        }
    }
}
