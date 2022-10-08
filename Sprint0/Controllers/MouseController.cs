using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Interfaces;

namespace sprint0.Controllers; 

public class MouseController : IController {
    private Point mousePosition;

    public MouseController() {
    }
    public void BindCommand(Keys key, ICommand command, IController.KeyState keyState) {
        
    }

    public void Update(Game1 game) {
        MouseState mouseInfo = Mouse.GetState();
        mousePosition = new Point(mouseInfo.X, mouseInfo.Y);
        
        if (mouseInfo.RightButton == ButtonState.Pressed) {
            game.Exit();
        }

        if (mouseInfo.LeftButton == ButtonState.Pressed) {
          
        }

    }
}