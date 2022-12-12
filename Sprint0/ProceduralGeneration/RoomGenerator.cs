using System;
using System.Collections.Generic;
using sprint0.Configs;
using sprint0.Interfaces;

namespace sprint0.ProceduralGeneration
{
    public class RoomGenerator
    {
        private const int NoDoor = -1;

        private readonly Random random;
        private readonly int levelOffset;

        public RoomGenerator(Random rand, int offset)
        {
            random = rand;
            levelOffset = offset;
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
            // move to separate doorGenerator class?
        }

        public List<LevelConfig> GenerateRooms(List<RoomVertex> roomGraph)
        {
            TileGenerator tiles = new TileGenerator(random);
            EnemyGenerator enemies = new EnemyGenerator(random);

            int tilePreset = 0;

            List<LevelConfig> RoomConfigs = new List<LevelConfig>();
            LevelConfig level;

            InitializeConfigs(RoomConfigs, roomGraph.Count);

            for (int i = 0; i < roomGraph.Count; i++)
            {
                level = RoomConfigs[i]; 
                
                level.Id = levelOffset + roomGraph[i].Id;

                tilePreset = tiles.Generate(level);

                LinkDestinations(roomGraph[i], RoomConfigs) ;

                enemies.Generate(level, tilePreset);
            }

            return RoomConfigs;
        }
    }
}
