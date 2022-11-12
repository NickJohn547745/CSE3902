using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.Commands; 

public class PauseGameCommand : ICommand {
    public void Execute(Game1 game)
    {
        game.gameState.PauseGame();
    }
}