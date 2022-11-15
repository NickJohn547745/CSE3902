using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;
using sprint0.Interfaces;
using System.Collections.Generic;
using sprint0.DoorClasses;
using sprint0.ItemClasses;
using sprint0.ItemClasses.Pickups;

namespace sprint0.Factories
{
    public class ItemObjectFactory
    {
        private static ItemObjectFactory instance = new ItemObjectFactory();

        public static ItemObjectFactory Instance
        {
            get { return instance; }
        }

        private ItemObjectFactory()
        {
        }

        public Item CreateArrowPickupObject(int xCoord, int yCoord)
        {
            return new ArrowPickup(xCoord, yCoord);
        }

        public Item CreateBombPickupObject(int xCoord, int yCoord)
        {
            return new BombPickup(xCoord, yCoord);
        }

        public Item CreateBoomerangPickupObject(int xCoord, int yCoord)
        {
            return new BoomerangPickup(xCoord, yCoord);
        }

        public Item CreateBowPickupObject(int xCoord, int yCoord)
        {
            return new BowPickup(xCoord, yCoord);
        }

        public Item CreateClockPickupObject(int xCoord, int yCoord)
        {
            return new ClockPickup(xCoord, yCoord);
        }

        public Item CreateCompassPickupObject(int xCoord, int yCoord)
        {
            return new CompassPickup(xCoord, yCoord);
        }

        public Item CreateHeartPickupObject(int xCoord, int yCoord)
        {
            return new HeartPickup(xCoord, yCoord);
        }

        public Item CreateHeartContainerPickupObject(int xCoord, int yCoord)
        {
            return new HeartContainerPickup(xCoord, yCoord);
        }

        public Item CreateKeyPickupObject(int xCoord, int yCoord)
        {
            return new KeyPickup(xCoord, yCoord);
        }

        public Item CreateMapPickupObject(int xCoord, int yCoord)
        {
            return new MapPickup(xCoord, yCoord);
        }

        public Item CreateRupeePickupObject(int xCoord, int yCoord)
        {
            return new RupeePickup(xCoord, yCoord);
        }

        public Item CreateTriforcePickupObject(int xCoord, int yCoord)
        {
            return new TriforcePickup(xCoord, yCoord);
        }

        public Item CreateItemById(int id, int xCoord, int yCoord)
        {
            Item returnValue = null;
            switch (id)
            {
                case 0:
                    returnValue = CreateArrowPickupObject(xCoord, yCoord);
                    break;
                case 1:
                    returnValue = CreateBombPickupObject(xCoord, yCoord);
                    break;
                case 2:
                    returnValue = CreateBoomerangPickupObject(xCoord, yCoord);
                    break;
                case 3:
                    returnValue = CreateBowPickupObject(xCoord, yCoord);
                    break;
                case 4:
                    returnValue = CreateClockPickupObject(xCoord, yCoord);
                    break;
                case 5:
                    returnValue = CreateCompassPickupObject(xCoord, yCoord);
                    break;
                case 6:
                    returnValue = CreateHeartPickupObject(xCoord, yCoord);
                    break;
                case 7:
                    returnValue = CreateHeartContainerPickupObject(xCoord, yCoord);
                    break;
                case 8:
                    returnValue = CreateKeyPickupObject(xCoord, yCoord);
                    break;
                case 9:
                    returnValue = CreateMapPickupObject(xCoord, yCoord);
                    break;
                case 10:
                    returnValue = CreateRupeePickupObject(xCoord, yCoord);
                    break;
                case 11:
                    returnValue = CreateTriforcePickupObject(xCoord, yCoord);
                    break;
            }
            return returnValue;

        }
    }
}
