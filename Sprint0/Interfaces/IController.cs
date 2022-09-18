using Microsoft.Xna.Framework.Input;

namespace sprint0.Interfaces; 

public interface IController {

    public void BindCommand(Keys key, ICommand command);

    public void Update(Game1 game);

}