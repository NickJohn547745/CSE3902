using sprint0.Interfaces;

namespace sprint0.Commands; 

public class PlayerTakeDamageCommand : ICommand
{
    public CommandData CommandData { get; set; }
    public void Execute(Game1 game)
    {
        if (CommandData.KeyState == IController.KeyState.Pressed)
        {
            game.Player.TakeDamage(game);
        }
    }
}