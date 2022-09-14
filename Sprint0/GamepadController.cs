using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Sprint0
{
    public class GamepadController : IController
    {
        public bool IsKeyboardController { get; set; }
        public bool IsMouseController { get; set; }
        public bool IsGamepadController { get; set; }
        public Dictionary<string, int> ControllerContents { get; set; }

        private Game game;

        public GamepadController(Game1 game)
        {
            if (game == null)
            {

            }
            this.game = game;

            IsKeyboardController = false;
            IsMouseController = false;
            IsGamepadController = true;

            ControllerContents = new Dictionary<string, int>();
        }

        public void Update()
        {

        }
    }
}