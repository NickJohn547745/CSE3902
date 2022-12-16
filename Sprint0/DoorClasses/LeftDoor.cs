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
    public class LeftDoor : Door
    {
        public LeftDoor(int id)
        {
            Type = ICollidable.ObjectType.Door;

            Id = id;
            HasCollided = false;
            TransitionDirection = Direction.Left;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(0, 360, 160, 160);
        }
        public override Type GetObjectType()
        {
            return typeof(LeftDoor);
        }
    }
}
