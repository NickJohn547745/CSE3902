using sprint0.Interfaces;

namespace sprint0.Commands; 

public class NextEnemyCommand : ICommand 
{
    public void Execute(Game1 game)
    {
        game.NextEnemy();
    }
}