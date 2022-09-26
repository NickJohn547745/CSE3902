using sprint0.Interfaces;

namespace sprint0.Commands; 

public class MoveDownCommand : ICommand {
    public void Execute(Game1 game) {
        game.Player.MoveDown();
    }
}