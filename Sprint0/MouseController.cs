using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    public class MouseController : IController
    {
        public bool IsKeyboardController { get; set; }
        public Dictionary<string, int> ControllerContents { get; set; }
        
        public MouseController()
        {
            IsKeyboardController = false;

            ControllerContents = new Dictionary<string, int>();
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            ControllerContents["RightMB"] = (state.RightButton == ButtonState.Pressed ? 1 : 0);
            ControllerContents["LeftMB"] = (state.LeftButton == ButtonState.Pressed ? 1 : 0);

            ControllerContents["PosX"] = state.Position.X;
            ControllerContents["PosY"] = state.Position.Y;
        }
    }
}