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

        public Item CreateArrowPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new ArrowPickup(xCoord, yCoord, player);
        }

        public Item CreateBombPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new BombPickup(xCoord, yCoord, player);
        }

        public Item CreateBoomerangPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new BoomerangPickup(xCoord, yCoord, player);
        }

        public Item CreateBowPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new BowPickup(xCoord, yCoord, player);
        }

        public Item CreateClockPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new ClockPickup(xCoord, yCoord);
        }

        public Item CreateCompassPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new CompassPickup(xCoord, yCoord, player);
        }

        public Item CreateHeartPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new HeartPickup(xCoord, yCoord);
        }

        public Item CreateHeartContainerPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new HeartContainerPickup(xCoord, yCoord);
        }

        public Item CreateKeyPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new KeyPickup(xCoord, yCoord, player);
        }

        public Item CreateMapPickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new MapPickup(xCoord, yCoord, player);
        }

        public Item CreateRupeePickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new RupeePickup(xCoord, yCoord, player);
        }

        public Item CreateTriforcePickupObject(int xCoord, int yCoord, IPlayer player)
        {
            return new TriforcePickup(xCoord, yCoord);
        }

        public Item CreateItemById(int id, int xCoord, int yCoord, IPlayer player)
        {
            Item returnValue = null;
            switch (id)
            {
                case 0:
                    returnValue = CreateArrowPickupObject(xCoord, yCoord, player);
                    break;
                case 1:
                    returnValue = CreateBombPickupObject(xCoord, yCoord, player);
                    break;
                case 2:
                    returnValue = CreateBoomerangPickupObject(xCoord, yCoord, player);
                    break;
                case 3:
                    returnValue = CreateBowPickupObject(xCoord, yCoord, player);
                    break;
                case 4:
                    returnValue = CreateClockPickupObject(xCoord, yCoord, player);
                    break;
                case 5:
                    returnValue = CreateCompassPickupObject(xCoord, yCoord, player);
                    break;
                case 6:
                    returnValue = CreateHeartPickupObject(xCoord, yCoord, player);
                    break;
                case 7:
                    returnValue = CreateHeartContainerPickupObject(xCoord, yCoord, player);
                    break;
                case 8:
                    returnValue = CreateKeyPickupObject(xCoord, yCoord, player);
                    break;
                case 9:
                    returnValue = CreateMapPickupObject(xCoord, yCoord, player);
                    break;
                case 10:
                    returnValue = CreateRupeePickupObject(xCoord, yCoord, player);
                    break;
                case 11:
                    returnValue = CreateTriforcePickupObject(xCoord, yCoord, player);
                    break;
            }
            return returnValue;

        }
    }
}
