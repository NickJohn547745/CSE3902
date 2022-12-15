﻿using Microsoft.Xna.Framework;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.RoomClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.SaveLoadClasses
{
    public class SaveLoadManager
    {
        public Game1 Game { get; set; }

        public int EnemyCount;

        const int Aquamentus = 1;
        const int Goriya = 2;
        const int Keese = 3;
        const int OldMan = 4;
        const int Stalfos = 5;
        const int Trap = 6;
        const int WallMaster = 7;
        const int Zol = 8;

        public SaveLoadManager(Game1 game)
        {
            Game = game;
        }

        public void SaveGame()
        {
            List<ICollidable> collidableList = CollisionManager.Collidables;
            List<ICollidable> enemyList = new List<ICollidable>();

            foreach (ICollidable collidable in collidableList)
            {

                if (collidable.Type == ICollidable.ObjectType.Enemy)
                {
                    enemyList.Add(collidable);
                    EnemyCount++;
                }
            }
            using (FileStream fileStream = new FileStream("Save1.sav", FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    SavePlayer(writer);
                    SaveRoom(writer);
                    SaveEnemies(writer, enemyList);
                }
            }
        }

        public void SaveEnemies(BinaryWriter writer, List<ICollidable> enemyList)
        {
            foreach(ICollidable enemy in enemyList)
            {
                // save x position
                writer.Write(enemy.GetHitBox().X);
                // save y position
                writer.Write(enemy.GetHitBox().Y);
                // save speed
                Vector2 Velocity = enemy.GetVelocity();
                float speed = (float)Math.Sqrt(Math.Pow(Velocity.X, 2) + Math.Pow(Velocity.Y, 2));
                writer.Write(speed);

                // save enemy type
                if (enemy.GetType() == typeof(AquamentusBoss))
                {
                    // enemy type
                    writer.Write(Aquamentus);
                } else if (enemy.GetType() == typeof(GoriyaEnemy))
                {
                    // enemy type
                    writer.Write(Goriya);
                } else if (enemy.GetType() == typeof(KeeseEnemy))
                {
                    // enemy type
                    writer.Write(Keese);
                } else if (enemy.GetType() == typeof(OldManNPC))
                {
                    // enemy type
                    writer.Write(OldMan);
                } else if (enemy.GetType() == typeof(StalfosEnemy))
                {
                    // enemy type
                    writer.Write(Stalfos);
                } else if(enemy.GetType() == typeof(TrapEnemy))
                {
                    // enemy type
                    writer.Write(Trap);
                } else if (enemy.GetType() == typeof(WallMasterEnemy))
                {
                    // enemy type
                    writer.Write(WallMaster);
                } else if (enemy.GetType() == typeof(ZolEnemy))
                {
                    // enemy type
                    writer.Write(Zol);
                } else
                {
                    break;
                }
            }
        }

        public void SavePlayer(BinaryWriter writer)
        {
            writer.Write(Game.Player.GetHealth());
            writer.Write(Game.Player.Position.X);
            writer.Write(Game.Player.Position.Y);
        }
        
        public void SaveRoom(BinaryWriter writer)
        {
           writer.Write(Game.state.Room.levelConfig.Id);
        }

        public void LoadGame()
        {
            if (File.Exists("Save1.sav"))
            {
                using (FileStream fileStream = new FileStream("Save1.sav", FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        LoadPlayer(reader);
                        LoadRoom(reader);
                    }
                }
            }
        }

        public void LoadEnemies(BinaryReader reader)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                // get x and y position
                int x = reader.ReadInt32();
                int y = reader.ReadInt32();
                float speed = reader.ReadSingle();

                Vector2 enemyVector = new Vector2(x, y);

                switch (reader.ReadInt32())
                {            
                    case Aquamentus:
                        // spawn Aquamentus enemy, add to collidable list
                        CollisionManager.Collidables.Add(new AquamentusBoss(enemyVector, speed));
                        break;
                    case Goriya:
                        // spawn Goriya enemy, add to collidable list
                        CollisionManager.Collidables.Add(new GoriyaEnemy(enemyVector, speed));
                        break;
                    case Keese:
                        // spawn Keese enemy, add to collidable list
                        CollisionManager.Collidables.Add(new KeeseEnemy(enemyVector, speed));
                        break;
                    case OldMan:
                        // spawn OldMan enemy, add to collidable list
                        CollisionManager.Collidables.Add(new OldManNPC(enemyVector));
                        break;
                    case Stalfos:
                        // spawn Stalfos enemy, add to collidable list
                        CollisionManager.Collidables.Add(new StalfosEnemy(enemyVector, speed));
                        break;
                    case Trap:
                        // spawn Trap enemy, add to collidable list
                        CollisionManager.Collidables.Add(new TrapEnemy(enemyVector, speed, Game.Player));
                        break;
                    case WallMaster:
                        // spawn WallMaster enemy, add to collidable list
                        CollisionManager.Collidables.Add(new WallMasterEnemy(enemyVector, speed));
                        break;
                    case Zol:
                        // spawn Zol enemy, add to collidable list
                        CollisionManager.Collidables.Add(new ZolEnemy(enemyVector, speed));
                        break;
                    default:
                        break;
                }

            }
        }

        public void LoadPlayer(BinaryReader reader)
        {
            Game.Player.SetHealth(reader.ReadInt32());
            Game.Player.Position = new Microsoft.Xna.Framework.Vector2(reader.ReadSingle(), reader.ReadSingle());
        }
        public void LoadRoom(BinaryReader reader)
        {
           int LevelIndex = reader.ReadInt32();
           Game.state.Room = new Room(Game, Game.LevelList[LevelIndex]);
        }
    }
}
