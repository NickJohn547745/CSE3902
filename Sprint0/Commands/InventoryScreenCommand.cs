using sprint0.GameStateClasses;
using sprint0.Interfaces;

namespace sprint0.Commands; 

public class InventoryScreenCommand : ICommand {
    public void Execute(Game1 game)
    {
        game.gameState.TransitionState(GameStates.Inventory);
    }
}