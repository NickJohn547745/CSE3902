using sprint0.GameStateClasses;
using sprint0.Interfaces;
using sprint0.MenuItems.Inventory;

namespace sprint0.Commands; 

public class CycleAbilityCommand : ICommand {
    public void Execute(Game1 game)
    {
        if(game.state.currentState.GetType() == typeof(InventoryState))
            AbilitySelect.Instance.CycleAbility();
    }
}