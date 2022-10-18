using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class LeftTopWall : Wall
    {
        public LeftTopWall()
        {

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 135, 160, 164);
        }
    }
}
