using sprint0.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using sprint0.RoomClasses;
using sprint0.Factories;
using System.Reflection.Metadata;
using sprint0.Configs;
using Microsoft.Xna.Framework;
using sprint0.Interfaces;

namespace sprint0.ProceduralGeneration
{
    public class RoomVertex
    {
        private const int StartCost = 1000;

        public int X { get; set; }
        public int Y { get; set; }

        public int Id { get; private set; }

        public int Cost { get; set; }
        public RoomVertex Predecessor { get; set; }
        public Dictionary<int, Direction> AdjacentRoomIds { get; set; }

        public RoomVertex(int x, int y)
        {
            X = x;
            Y = y;
            Cost = StartCost;
            Predecessor = null;
            Id = X + Y * RoomLayoutGenerator.GridDim;
            AdjacentRoomIds = new Dictionary<int, Direction>();
            InitializeRoomIds();
        }

        private void InitializeRoomIds()
        {
            if (Y > 0) AdjacentRoomIds[Id - RoomLayoutGenerator.GridDim] = Direction.Up;

            if (X < RoomLayoutGenerator.GridDim - 1) AdjacentRoomIds[Id + 1] = Direction.Right;

            if (Y < RoomLayoutGenerator.GridDim - 1) AdjacentRoomIds[Id + RoomLayoutGenerator.GridDim] = Direction.Down;

            if (X > 0) AdjacentRoomIds[Id - 1] = Direction.Left;
        }
    }
}
