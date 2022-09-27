using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.Commands; 

public class ChooseItemCommand : ICommand {

    private Player myP;
    public ChooseItemCommand(Player player)
    {
        myP = player;
    }

    public void Execute(Game1 game)
    {

    }
}