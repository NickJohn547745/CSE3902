using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sound;

namespace sprint0.Commands; 

public class UseWoodenBoomerangCommand : ICommand 
{
    public void Execute(Game1 game) 
    {
        if (!game.Paused)
        {
            game.Player.UseAbility(AbilityTypes.WoodenBoomerang);
            SoundManager.Manager.arrowBoomerangSound().Play();
        }
    }
}