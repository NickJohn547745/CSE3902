using sprint0.Interfaces;

namespace sprint0.Commands; 

public class EnemyCycleBackwardCommand : ICommand {

    public void Execute(Game1 game, IController.KeyState keyState) {
        if (keyState == IController.KeyState.Pressed)
        {
            game.CycleEnemyBackward();
        }
    }
}