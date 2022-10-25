using Microsoft.Xna.Framework;
using sprint0.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.RoomClasses
{
    public class RightBottomWall : Wall
    {
        public RightBottomWall()
        {
            type = ICollidable.objectType.Wall;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(1120, 520, 160, 200);
        }
    }
}
