using Microsoft.Xna.Framework;
using sprint0.Interfaces;

namespace sprint0.RoomClasses
{
    public class LeftTopWall : Wall
    {
        public LeftTopWall()
        {
            Type = ICollidable.ObjectType.Wall;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 160, 160, 200);
        }
    }
}
