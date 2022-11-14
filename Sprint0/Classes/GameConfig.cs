using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
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
        public List<Tuple<Keys, ICommand, IController.KeyState>> MouseBinds { get; set; }
        public List<Tuple<Keys, ICommand, IController.KeyState>> KeyboardBinds { get; set; }
        public List<Tuple<Buttons, ICommand, IController.KeyState>> GamePadBinds { get; set; }

        public Dictionary<int, string> LevelData { get; set; }

        public Dictionary<int, LevelConfig> LevelConfigs { get; set; }

        public GameConfig()
        {
            ResolutionWidth = 0;
            ResolutionHeight = 0;

            StartLevelId = 0;

            MouseBinds = new List<Tuple<Keys, ICommand, IController.KeyState>>();
            KeyboardBinds = new List<Tuple<Keys, ICommand, IController.KeyState>>();
            GamePadBinds = new List<Tuple<Buttons, ICommand, IController.KeyState>>();

            LevelData = new Dictionary<int, string>();
            LevelConfigs = new Dictionary<int, LevelConfig>();
        }
    }
}
