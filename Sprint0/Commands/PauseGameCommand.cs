using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.Commands; 

public class TogglePauseCommand : ICommand {
    public void Execute(Game1 game)
    {
        game.state.TogglePause();
    }
}