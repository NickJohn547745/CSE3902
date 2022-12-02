using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using System;
using sprint0.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.RoomClasses;

namespace sprint0.DoorClasses
{
    public class RightDoor : Door
    {
        public RightDoor(int id)
        {
            Type = ICollidable.ObjectType.Door;

            Id = id;
            HasCollided = false;
            TransitionDirection = Direction.Right;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(1120, 360, 5 * 32, 5 * 32);
        }
        public override Type GetObjectType()
        {
            return typeof(RightDoor);
        }
    }
}
