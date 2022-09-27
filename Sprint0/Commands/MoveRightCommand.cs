using sprint0.Interfaces;

namespace sprint0.Commands; 

public class MoveRightCommand : ICommand {
    public void Execute(Game1 game) {
        game.Player.MoveRight();
    }
}