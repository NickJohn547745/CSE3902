using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;
using sprint0.Interfaces;
using System.Collections.Generic;
using sprint0.DoorClasses;
using sprint0.Enemies;

namespace sprint0.Factories
{
    public class EnemyObjectFactory
    {
        private static EnemyObjectFactory instance = new EnemyObjectFactory();

        public static EnemyObjectFactory Instance
        {
            get { return instance; }
        }

        private EnemyObjectFactory()
        {
        }

        public Enemy CreateAquamentusBossObject(int xCoord, int yCoord, float speed)
        {
            Vector2 position = new Vector2(xCoord, yCoord);
            return new AquamentusBoss(position, speed);
        }
        public Enemy CreateGoriyaEnemyObject(int xCoord, int yCoord, float speed)
        {
            Vector2 position = new Vector2(xCoord, yCoord);
            return new GoriyaEnemy(position, speed);
        }
        public Enemy CreateKeeseEnemyObject(int xCoord, int yCoord, float speed)
        {
            Vector2 position = new Vector2(xCoord, yCoord);
            return new KeeseEnemy(position, speed);
        }
        public Enemy CreateOldManNPCObject(int xCoord, int yCoord, float speed)
        {
            Vector2 position = new Vector2(xCoord, yCoord);
            return new OldManNPC(position);
        }
        public Enemy CreateStalfosEnemyObject(int xCoord, int yCoord, float speed)
        {
            Vector2 position = new Vector2(xCoord, yCoord);
            return new StalfosEnemy(position, speed);
        }
        public Enemy CreateZolEnemyObject(int xCoord, int yCoord, float speed)
        {
            Vector2 position = new Vector2(xCoord, yCoord);
            return new ZolEnemy(position, speed);
        }

        public Enemy CreateEnemyById(int id, int xCoord, int yCoord, float speed)
        {
            Enemy returnValue = null;

            Vector2 location = new Vector2(xCoord, yCoord);
            switch (id)
            {
                case 0:
                    returnValue = CreateAquamentusBossObject(xCoord, yCoord, speed);
                    break;
                case 1:
                    returnValue = CreateGoriyaEnemyObject(xCoord, yCoord, speed);
                    break;
                case 2:
                    returnValue = CreateKeeseEnemyObject(xCoord, yCoord, speed);
                    break;
                case 3:
                    returnValue = CreateOldManNPCObject(xCoord, yCoord, speed);
                    break;
                case 4:
                    returnValue = CreateStalfosEnemyObject(xCoord, yCoord, speed);
                    break;
                case 5:
                    returnValue = CreateZolEnemyObject(xCoord, yCoord, speed);
                    break;
            }
            return returnValue;

        }
    }
}
