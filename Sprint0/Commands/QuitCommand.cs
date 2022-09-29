using sprint0.Interfaces;

namespace sprint0.Commands; 

public class QuitCommand : ICommand {

    public void Execute(Game1 game, IController.KeyState keyState)
    {
        if (keyState == IController.KeyState.Pressed)
            game.Exit();
    }
}