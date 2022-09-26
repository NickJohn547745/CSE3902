using sprint0.Controllers;
using sprint0.Interfaces;

namespace sprint0.Commands; 

public class MoveRightCommand  : ICommand{
    public void Execute(Game1 game) {
        game.CurrentSprite.MoveRight();
    }
}