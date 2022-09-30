using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;

namespace sprint0.Controllers; 

public class KeyboardController : IController {

    private Dictionary<Keys, ICommand> keyMappings;

    public KeyboardController() {
        keyMappings = new Dictionary<Keys, ICommand>();
    }
    
    public void BindCommand(Keys key, ICommand command) {
        keyMappings.Add(key, command);
    }

    public void Update(Game1 game) {
        Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
		
        foreach (Keys key in pressedKeys){
            keyMappings[key].Execute(game);
        }
    }
}