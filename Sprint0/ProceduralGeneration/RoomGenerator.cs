using sprint0.Commands;
using System;
using System.Collections.Generic;
using sprint0.Configs;
using sprint0.Interfaces;

namespace sprint0.ProceduralGeneration
{
    public class RoomGenerator
    {
        private const int TilesHeight = 7;
        private const int TilesWidth = 12;

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
                    level.Destinations.Add(-1);
                    level.DoorIds.Add(0);
                }

                roomConfigs.Add(level);

                level = new LevelConfig();
            }
        }

        private void InitializeTiles(LevelConfig cfg)
        {
            List<List<int>> tiles = new List<List<int>>();
            for (int i = 0; i < TilesHeight; i++)
            {
                tiles.Add(new List<int>());
                for (int j = 0; j < TilesWidth; j++)
                {
                    tiles[i].Add(0);
                }
            }
            cfg.TileIds = tiles;
        }

        private void GenerateTiles(LevelConfig cfg)
        {
            InitializeTiles(cfg);


        }

        private void LinkDestinations(RoomVertex current, List<LevelConfig> RoomConfigs)
        {
            // link to main dungeon for start room
            if (current.Id == 0)
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

                // set predecessor's corresponding destination
                // int dirFlip = ((int)current.AdjacentRoomIds[predId] + FlipOffset) % RoomLayoutGenerator.MaxDoors;
                int predDir = (int) current.Predecessor.AdjacentRoomIds[current.Id];

                RoomConfigs[current.Predecessor.Id].Destinations[predDir] = current.Id + levelOffset;
                RoomConfigs[current.Predecessor.Id].DoorIds[predDir] = 1;
            }
        }

        private void GenerateDoorIds(LevelConfig cfg)
        {
            for (int i = 0; i < RoomLayoutGenerator.MaxDoors; i++)
            {
                // change when multiple door types are added...
                int Id = 0;
                
                if (cfg.Destinations[i] != -1) Id = 1;
                
                cfg.DoorIds.Add(Id);
            }
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
