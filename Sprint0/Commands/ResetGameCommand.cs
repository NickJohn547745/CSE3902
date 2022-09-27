using sprint0.Interfaces;

namespace sprint0.Commands; 

public class ResetGameCommand : ICommand {

    private Game1 myG;

    public void ResetGame(Game1 game) {
        myG = game;
    }

    public void Execute(Game1 game)
    {
        game.reset();
    }
}