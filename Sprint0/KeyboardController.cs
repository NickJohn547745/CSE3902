using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    public class KeyboardController : IController
    {
        public bool IsKeyboardController { get; set; }
        public Dictionary<string, int> ControllerContents { get; set; }

        public KeyboardController()
        {
            IsKeyboardController = true;

            ControllerContents = new Dictionary<string, int>();

            ControllerContents.Add("D0", 0);
            ControllerContents.Add("D1", 0);
            ControllerContents.Add("D2", 0);
            ControllerContents.Add("D3", 0);
            ControllerContents.Add("D4", 0);
            ControllerContents.Add("Esc", 0);
        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            ControllerContents["D0"] = state.IsKeyDown(Keys.D0) ? 1 : 0;
            ControllerContents["D1"] = state.IsKeyDown(Keys.D1) ? 1 : 0;
            ControllerContents["D2"] = state.IsKeyDown(Keys.D2) ? 1 : 0;
            ControllerContents["D3"] = state.IsKeyDown(Keys.D3) ? 1 : 0;
            ControllerContents["D4"] = state.IsKeyDown(Keys.D4) ? 1 : 0;
            ControllerContents["Esc"] = state.IsKeyDown(Keys.Escape) ? 1 : 0;
        }
    }
}