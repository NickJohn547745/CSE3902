using sprint0.Interfaces;

namespace sprint0.Commands; 

public class MoveUpCommand : ICommand 
{
    public void Execute(Game1 game)
    {
        if (!game.Paused) game.Player.MoveUp();
    }
}