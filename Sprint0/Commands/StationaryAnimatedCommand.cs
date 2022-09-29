using sprint0.Controllers;
using sprint0.Interfaces;

namespace sprint0.Commands; 

public class StationaryAnimatedCommand : ICommand {

    public void Execute(Game1 game, IController.KeyState keyState)
    {
        if (keyState == IController.KeyState.Pressed)
            game.CurrentSprite = new StationaryAnimatedSprite(game.Spritesheet);
    }
}