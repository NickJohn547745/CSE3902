using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sound;

namespace sprint0.Commands; 

public class UseSilverArrowCommand : ICommand
{
    public void Execute(Game1 game)
    {
        if (!game.Paused)
        {
            game.Player.UseAbility(AbilityTypes.SilverArrow);
            SoundManager.Manager.arrowBoomerangSound().Play();
        }
    }
}