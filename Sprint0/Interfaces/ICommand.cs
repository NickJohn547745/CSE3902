using Microsoft.Xna.Framework.Input;
using sprint0.Commands;

namespace sprint0.Interfaces; 

public interface ICommand {
    public CommandData CommandData { get; set; }
    public void Execute(Game1 game);

}