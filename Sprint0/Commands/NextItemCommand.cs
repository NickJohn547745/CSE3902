using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.Commands; 

public class NextItemCommand : ICommand {

    public void Execute(Game1 game, IController.KeyState keyState)
    {
        if (keyState == IController.KeyState.Pressed)
            game.NextItem();
    }
}