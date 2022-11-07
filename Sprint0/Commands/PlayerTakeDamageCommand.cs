using sprint0.Interfaces;
using sprint0.Sound;

namespace sprint0.Commands; 

public class PlayerTakeDamageCommand : ICommand
{
    public void Execute(Game1 game)
    {
        game.Player.TakeDamage(1);
        SoundManager.Manager.linkDamageSound().Play();
    }
}