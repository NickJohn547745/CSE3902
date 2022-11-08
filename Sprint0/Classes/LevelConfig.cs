using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Classes
{
    public class LevelConfig
    {
        public int Id { get; set; }
        public List<List<int>> TileIds { get; set; }
        public List<int> DoorIds { get; set; }
        public List<int> Destinations { get; set; }
        public Dictionary<int, Tuple<Point, int>> Enemies { get; set; }

        public LevelConfig()
        {
            Id = 0;
            TileIds = new List<List<int>>();
            DoorIds = new List<int>();
            Destinations = new List<int>();
            Enemies = new Dictionary<int, Tuple<Point, int>>();
        }
    }
}
