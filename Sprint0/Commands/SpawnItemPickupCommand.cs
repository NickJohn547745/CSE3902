using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.ItemClasses.Pickups;
using sprint0.Managers;

namespace sprint0.Commands;

public class SpawnItemPickupCommand : ICommand
{
    public void Execute(Game1 game)
    {
        if (!game.Paused) CollisionManager.Collidables.Add(ItemObjectFactory.Instance.CreateBowPickupObject(500, 500, game.Player));
    }
}