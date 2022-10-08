using sprint0.Interfaces;

namespace sprint0.Commands; 

public class ResetGameCommand : ICommand
{ 
    public void Execute(Game1 game)
    {
            game.reset();
    }
}