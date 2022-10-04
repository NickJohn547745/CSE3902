using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;

namespace sprint0.Controllers; 

public class KeyboardController : IController {

    private Dictionary<Keys, ICommand> keyMappings;

    private KeyboardState currentState;
    private KeyboardState previousState;

    public KeyboardController() {
        keyMappings = new Dictionary<Keys, ICommand>();
    }
    
    public void BindCommand(Keys key, ICommand command) {
        keyMappings.Add(key, command);
    }

    public void Update(Game1 game) {
        previousState = currentState;
        currentState = Keyboard.GetState();

        Keys[] pressedKeys = currentState.GetPressedKeys();
        
        foreach (Keys key in pressedKeys) {
            if (keyMappings.ContainsKey(key)) {
                IController.KeyState keyState = GetKeyState(key);
                keyMappings[key].CommandData = new Commands.CommandData(keyState);

                keyMappings[key].Execute(game);
            }
        } 
    }

    private IController.KeyState GetKeyState(Keys key)
    {
        IController.KeyState result;

        if (currentState.IsKeyDown(key))
        {
            result = IController.KeyState.KeyDown;
            if (previousState.IsKeyUp(key))
                result = IController.KeyState.Pressed;
        } else
        {
            result = IController.KeyState.KeyUp;
            if (previousState.IsKeyDown(key))
                result = IController.KeyState.Released;
        }
        return result;
    }
}