using sprint0.Interfaces;

namespace sprint0.Commands; 

public class TogglePauseCommand : ICommand {
    public void Execute(Game1 game)
    {
        game.state.TogglePause();
    }
}