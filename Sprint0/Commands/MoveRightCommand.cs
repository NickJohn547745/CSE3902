using sprint0.Interfaces;

namespace sprint0.Commands; 

public class MoveRightCommand : ICommand {
    public void Execute(Game1 game, IController.KeyState keyState)
    {
        if (keyState == IController.KeyState.KeyDown)
            game.Player.MoveRight();
    }
}