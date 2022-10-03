using sprint0.Interfaces;

namespace sprint0.Commands; 

public class MoveLeftCommand : ICommand {
    public CommandData CommandData { get; set; }
    public void Execute(Game1 game)
    {
        if (CommandData.KeyState == IController.KeyState.KeyDown)
            game.Player.MoveLeft();
    }
}