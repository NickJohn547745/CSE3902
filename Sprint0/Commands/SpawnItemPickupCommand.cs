using sprint0.Interfaces;
using sprint0.ItemClasses.Pickups;

namespace sprint0.Commands;

public class SpawnItemPickupCommand : ICommand
{
    public void Execute(Game1 game)
    {
        game.CollidablesToAdd.Add(new ArrowPickup());
    }
}