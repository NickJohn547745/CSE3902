using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Interfaces;

namespace sprint0.Controllers; 

public class MouseController : IController {
    private Point mousePosition;

    private Tuple<Rectangle, ICommand>[] regions = new Tuple<Rectangle, ICommand>[0];
    //private Dictionary<Rectangle, ICommand> regions = new Dictionary<Rectangle, ICommand>();

    public MouseController() {
    }
    public void BindCommand(Keys key, ICommand command) {
        
    }

    public void Update(Game1 game) {
        MouseState mouseInfo = Mouse.GetState();
        mousePosition = new Point(mouseInfo.X, mouseInfo.Y);
        
        if (mouseInfo.RightButton == ButtonState.Pressed) {
            game.Exit();
        }

        if (mouseInfo.LeftButton == ButtonState.Pressed) {
            foreach (var (region, command) in regions) {
                if (region.Contains(mousePosition)) {
                    command.Execute(game);
                }
            }
        }

    }
}