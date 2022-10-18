using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class RightTopWall : Wall
    {
        public RightTopWall()
        {

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(1125, 135, 160, 164);
        }
    }
}
