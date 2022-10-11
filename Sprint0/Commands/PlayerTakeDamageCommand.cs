using sprint0.Interfaces;

namespace sprint0.Commands; 

public class PlayerTakeDamageCommand : ICommand
{
    public void Execute(Game1 game)
    {
        game.Player.TakeDamage(game);
    }
}