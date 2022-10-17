using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class BottomLeftWall : Wall
    {
        public BottomLeftWall()
        {

        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 589, 560, 135);
        }
    }
}
