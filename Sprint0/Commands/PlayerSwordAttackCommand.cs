using sprint0.Interfaces;
using sprint0.Sound;

namespace sprint0.Commands; 

public class PlayerSwordAttackCommand : ICommand {
    public void Execute(Game1 game)
    {
        if (!game.Paused)
        {
            game.Player.SwordAttack();
            SoundManager.Manager.swordSound().Play();

        }
    }
}