using System;
using System.Collections.Generic;
using System.Linq;
using sprint0.Configs;
using sprint0.RoomClasses;

namespace sprint0.ProceduralGeneration
{
    public class RoomLayoutGenerator
    {
        private const int GridMin = 3;
        private const int GridMax = 8;
        
        public const int MaxDoors = 4;

        private readonly Random rand = new();

        public int GridHeight { get; private set; }
        public int GridWidth { get; private set; }

        private List<RoomVertex> RoomGraph;
        
        public List<LevelConfig> ProceduralRooms { get; private set; }

        private static RoomLayoutGenerator instance = new RoomLayoutGenerator();
        public static RoomLayoutGenerator Instance
        {
            get { return instance; }
        }

        private RoomLayoutGenerator() 
        {
            GridHeight = rand.Next(GridMin, GridMax);
            GridWidth = rand.Next(GridMin, GridMax);
        }     


        // split room generation into different class?
        private void InitializeRoomGraph()
        {
            RoomGraph = new List<RoomVertex>();

            for (int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    RoomGraph.Add(new RoomVertex(j, i));
                }
            }
        }

        private void InitializeOut(PriorityQueue<RoomVertex, int> Out)
        {
            foreach (RoomVertex vertex in RoomGraph)
            {
                Out.Enqueue(vertex, vertex.Cost);
            }
        }

        private void UpdateOut(PriorityQueue<RoomVertex, int> Out, RoomVertex vertex)
        {
            List<RoomVertex> temp = new List<RoomVertex>();
            while (Out.Count > 0)
            {
                temp.Add(Out.Dequeue());
            }

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Id != vertex.Id) Out.Enqueue(temp[i], temp[i].Cost);
            }

            Out.Enqueue(vertex, vertex.Cost);
        }

        private void GenerateLayout()
        {
            InitializeRoomGraph();
            
            // uses modified Prim's MST algorithm
            RoomGraph[0].Cost = 0;

            PriorityQueue<RoomVertex, int> Out = new PriorityQueue<RoomVertex, int>();

            InitializeOut(Out);

            for (int i = 0; i < RoomGraph.Count; i++)
            {
                RoomVertex current = Out.Dequeue();
                
                foreach (int adjId in current.AdjacentRoomIds.Keys)
                {
                    RoomVertex adjacent = RoomGraph[adjId];
                    int edgeWeight = rand.Next(MaxDoors);
                    bool outContains = Out.UnorderedItems.Contains((adjacent, adjacent.Cost));
                    if (outContains && edgeWeight < adjacent.Cost && adjacent != current.Predecessor)
                    {
                        adjacent.Cost = edgeWeight;
                        adjacent.Predecessor = current;

                        // not the most efficient, but the max N is small enough where it should still be fast
                        UpdateOut(Out, adjacent);
                    }
                }
            }           
        }

        public void SetRooms(Game1 game, int levelOffset)
        {
            GenerateLayout();

            RoomGenerator roomGen = new RoomGenerator(rand, levelOffset);
            ProceduralRooms = roomGen.GenerateRooms(RoomGraph);
        }
    }
}
