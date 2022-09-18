using sprint0.Controllers;
using sprint0.Interfaces;

namespace sprint0.Commands; 

public class Command3 : ICommand {

    public void Execute(Game1 game) {
        game.CurrentSprite = new MovingStaticSprite(game.Spritesheet);
    }
}