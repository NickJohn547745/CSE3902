using sprint0.Interfaces;

namespace sprint0.Commands; 

public class PreviousEnemyCommand : ICommand {
    public void Execute(Game1 game)
    {
        game.PreviousEnemy();
    }
}