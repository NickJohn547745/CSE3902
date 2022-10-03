using sprint0.Interfaces;
using sprint0.PlayerClasses;
namespace sprint0.Commands; 

public class PreviousItemCommand : ICommand {
    public CommandData CommandData { get; set; }
    public void Execute(Game1 game)
    {
        if (CommandData.KeyState == IController.KeyState.Pressed)
            game.PreviousItem();
    }
}