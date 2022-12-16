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
    public class TopDoor : Door
    {
        public TopDoor(int id)
        {
            Type = ICollidable.ObjectType.Door;

            Id = id;
            HasCollided = false;
            TransitionDirection = Direction.Up;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle(560, 0, 160, 160);
        }
        public override Type GetObjectType()
        {
            return typeof(TopDoor);
        }
    }
}
