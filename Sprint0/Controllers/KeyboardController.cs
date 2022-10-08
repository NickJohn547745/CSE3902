using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;

namespace sprint0.Controllers; 

public class KeyboardController : IController {

    private Dictionary<Keys, (ICommand, IController.KeyState)> keyMappings;

    private KeyboardState currentState;
    private KeyboardState previousState;

    public KeyboardController() {
        keyMappings = new Dictionary<Keys, (ICommand, IController.KeyState)>();
    }
    
    public void BindCommand(Keys key, ICommand command, IController.KeyState keyState) {
        keyMappings.Add(key, (command, keyState));
    }

    private IController.KeyState GetKeyState(Keys key)
    {
        IController.KeyState result;

        if (currentState.IsKeyDown(key))
        {
            result = IController.KeyState.KeyDown;
            if (previousState.IsKeyUp(key))
                result = IController.KeyState.Pressed;
        }
        else
        {
            result = IController.KeyState.KeyUp;
            if (previousState.IsKeyDown(key))
                result = IController.KeyState.Released;
        }
        return result;
    }

    public void Update(Game1 game) {
        previousState = currentState;
        currentState = Keyboard.GetState();

        Keys[] pressedKeys = currentState.GetPressedKeys();
        
        foreach (Keys key in pressedKeys) {
            if (keyMappings.ContainsKey(key) && GetKeyState(key) == keyMappings[key].Item2) {
                keyMappings[key].Item1.Execute(game);
            }
        } 
    }
}