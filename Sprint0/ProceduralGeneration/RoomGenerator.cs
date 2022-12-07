using sprint0.Commands;
using System;
using System.Collections.Generic;
using sprint0.Configs;
using sprint0.Interfaces;
using sprint0.FileReaderClasses;

namespace sprint0.ProceduralGeneration
{
    public class RoomGenerator
    {
        private const int TilesHeight = 7;
        private const int TilesWidth = 12;
        private const int NoDoor = -1;

        private const string TilePath = "./Content/Data/Tile";
        private const string Xml = ".xml";

        private readonly Random random;
        private readonly int levelOffset;

        private int tileLayout;

        public RoomGenerator(Random rand, int offset)
        {
            random = rand;
            levelOffset = offset;
            tileLayout = 0;
        }

        private void InitializeConfigs(List<LevelConfig> roomConfigs, int size)
        {
            LevelConfig level = new LevelConfig();

            for (int j = 0; j < size; j++)
            {

                for (int i = 0; i < RoomLayoutGenerator.MaxDoors; i++)
                {
                    level.Destinations.Add(NoDoor);
                    level.DoorIds.Add(0);
                }

                roomConfigs.Add(level);

                level = new LevelConfig();
            }
        }

        private void GenerateTiles(LevelConfig cfg)
        {
            LevelFileReader levelReader = new LevelFileReader(cfg);

            // select which preset tile config
            switch (random.Next(18))
            {
                case 0 or 1 or 2:
                    tileLayout = 1;
                    break;
                case 4 or 5 or 6:
                    tileLayout = 2;
                    break;
                case 7 or 8:
                    tileLayout = 3;
                    break;
                case 9 or 10:
                    tileLayout = 4;
                    break;
                case 11 or 12:
                    tileLayout = 5;
                    break;
                case 13 or 14 or 15:
                    tileLayout = 6;
                    break;
                default:
                    tileLayout = 0;
                    break;
            }

            levelReader.LoadFile(TilePath + tileLayout.ToString() + Xml);
        }

        private void LinkDestinations(RoomVertex current, List<LevelConfig> RoomConfigs)
        {
            // link to main dungeon for start room
            if (current.Id == RoomLayoutGenerator.Instance.StartRoomId)
            {
                RoomConfigs[current.Id].Destinations[(int)Direction.Up] = 0;
                RoomConfigs[current.Id].DoorIds[(int)Direction.Up] = 1;
            }
            else
            {
                int predId = current.Predecessor.Id;
                RoomConfigs[current.Id].Destinations[(int)current.AdjacentRoomIds[predId]] = predId + levelOffset;

                // set doorId
                RoomConfigs[current.Id].DoorIds[(int)current.AdjacentRoomIds[predId]] = 1;

                int predDir = (int) current.Predecessor.AdjacentRoomIds[current.Id];

                RoomConfigs[current.Predecessor.Id].Destinations[predDir] = current.Id + levelOffset;
                RoomConfigs[current.Predecessor.Id].DoorIds[predDir] = 1;
            }
        }

        private void GenerateDoorIds(LevelConfig cfg)
        {
            // select type of door if we implement...
        }

        private void GenerateEnemies(LevelConfig cfg)
        {

        }

        public List<LevelConfig> GenerateRooms(List<RoomVertex> roomGraph)
        {
            List<LevelConfig> RoomConfigs = new List<LevelConfig>();
            LevelConfig level;

            InitializeConfigs(RoomConfigs, roomGraph.Count);

            for (int i = 0; i < roomGraph.Count; i++)
            {
                level = RoomConfigs[i]; 
                
                level.Id = levelOffset + roomGraph[i].Id;

                GenerateTiles(level);

                LinkDestinations(roomGraph[i], RoomConfigs) ;

                // GenerateDoorIds(level);

                GenerateEnemies(level);
            }

            return RoomConfigs;
        }
    }
}
