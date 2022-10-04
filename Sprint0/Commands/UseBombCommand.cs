using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.Commands; 

public class UseBombCommand : ICommand
{
    public CommandData CommandData { get; set; }
    public void Execute(Game1 game)
    {
        if (CommandData.KeyState == IController.KeyState.Pressed)
        {
            game.Player.UseAbility(AbilityTypes.Bomb);
        }
    }
}