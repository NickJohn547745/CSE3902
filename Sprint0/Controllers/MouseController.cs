using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Interfaces;
using sprint0.ItemClasses;
using System.Collections.Generic;

namespace sprint0.Controllers; 

public class MouseController : IController {
    private Point mousePosition;

    MouseState previousState = new MouseState();
    MouseState currentState = new MouseState();

    public MouseController() {

    }
    public void BindCommand(Keys key, ICommand command, IController.KeyState keyState) {
        
    }

    public void BindCommand(Buttons button, ICommand command, IController.KeyState keyState) {
        
    }

    public void Update(Game1 game) {
        previousState = currentState;
        currentState = Mouse.GetState();

        mousePosition = new Point(currentState.X, currentState.Y);

        if (currentState.RightButton == ButtonState.Released && previousState.RightButton == ButtonState.Pressed) {
            game.PreviousLevel();
        }

        if (currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed) {
            game.NextLevel();
        }
    }
}