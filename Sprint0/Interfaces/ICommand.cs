using Microsoft.Xna.Framework.Input;
using sprint0.Commands;

namespace sprint0.Interfaces; 

public interface ICommand {
    public void Execute(Game1 game);

}