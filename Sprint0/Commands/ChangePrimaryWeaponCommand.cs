using sprint0.Interfaces;
using sprint0.PlayerClasses;
using sprint0.Sound;

namespace sprint0.Commands; 

public class ChangePrimaryWeaponCommand : ICommand {
    public void Execute(Game1 game)
    {
        if (!game.Paused)
        {
            if (game.Player.PrimaryWeapon == PlayerWeapons.Sword)
            {
                game.Player.PrimaryWeapon = PlayerWeapons.Wand;
            }
            else
            {
                game.Player.PrimaryWeapon = PlayerWeapons.Sword;
            }

        }
    }
}