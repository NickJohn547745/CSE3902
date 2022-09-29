using Microsoft.Xna.Framework.Input;

namespace sprint0.Interfaces; 

public interface ICommand {
    public void Execute(Game1 game, IController.KeyState keyState = IController.KeyState.KeyUp);

}