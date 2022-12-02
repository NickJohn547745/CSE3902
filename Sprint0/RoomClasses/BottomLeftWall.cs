using Microsoft.Xna.Framework;
using sprint0.Interfaces;
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
            Type = ICollidable.ObjectType.Wall;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 720, 560, 160);
        }
    }
}
