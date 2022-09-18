using sprint0.Interfaces;

namespace sprint0.Commands; 

public class Command0 : ICommand {

    public void Execute(Game1 game) {
        game.Exit();
    }
}