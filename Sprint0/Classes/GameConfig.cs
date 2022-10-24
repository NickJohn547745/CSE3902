using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Classes
{
    public class GameConfig
    {
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }
        public int StartLevelId { get; set; }
        public Dictionary<int, string> LevelData { get; set; }

        public Dictionary<int, LevelConfig> LevelConfigs { get; set; }

        public GameConfig()
        {
            ResolutionWidth = 0;
            ResolutionHeight = 0;

            StartLevelId = 0;

            LevelData = new Dictionary<int, string>();
            LevelConfigs = new Dictionary<int, LevelConfig>();
        }
    }
}
