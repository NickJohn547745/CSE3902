using Microsoft.Xna.Framework;
using sprint0.Interfaces;

namespace sprint0.RoomClasses
{
    public class BottomRightWall : Wall
    {
        public BottomRightWall()
        {
            Type = ICollidable.ObjectType.Wall;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(720, 720, 560, 160);
        }
    }
}
