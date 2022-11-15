using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;
using sprint0.Interfaces;
using System.Collections.Generic;
using sprint0.DoorClasses;

namespace sprint0.Factories
{
    public class DoorObjectFactory
    {
        private static DoorObjectFactory instance = new DoorObjectFactory();

        public static DoorObjectFactory Instance
        {
            get { return instance; }
        }

        private DoorObjectFactory()
        {
        }

        public Door CreateTopDoorObject(int id)
        {
            return new TopDoor(id);
        }

        public Door CreateBottomDoorObject(int id)
        {
            return new BottomDoor(id);
        }

        public Door CreateRightDoorObject(int id)
        {
            return new RightDoor(id);
        }

        public Door CreateLeftDoorObject(int id)
        {
            return new LeftDoor(id);
        }

        public Door CreateDoorById(Direction direction, int id)
        {
            Door returnValue = null;
            switch ((int)direction)
            {
                case 0:
                    returnValue = CreateTopDoorObject(id);
                    break;
                case 1:
                    returnValue = CreateRightDoorObject(id);
                    break;
                case 2:
                    returnValue = CreateBottomDoorObject(id);
                    break;
                case 3:
                    returnValue = CreateLeftDoorObject(id);
                    break;
            }
            return returnValue;

        }
    }
}
