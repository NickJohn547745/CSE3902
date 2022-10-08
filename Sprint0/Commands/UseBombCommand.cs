using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.Commands; 

public class UseBombCommand : ICommand
{
    public void Execute(Game1 game)
    {
        game.Player.UseAbility(AbilityTypes.Bomb);
    }
}