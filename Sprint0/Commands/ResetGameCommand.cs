using sprint0.Interfaces;

namespace sprint0.Commands; 

public class ResetGameCommand : ICommand {
    public CommandData CommandData { get; set; }

    private Game1 myG;
    public void ResetGame(Game1 game) {
        myG = game;
    }

    public void Execute(Game1 game)
    {
        if (CommandData.KeyState == IController.KeyState.Pressed)
            game.reset();
    }
}