using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
using sprint0.Utility;

namespace sprint0.Controllers; 

public class KeyboardController : IController {
    private const int KeySwitchDelay = 4;


    private Dictionary<Keys, (ICommand command, IController.KeyState keyState)> keyMappings;

    private KeyboardState currentState;
    private KeyboardState previousState;
    private (Keys key, ICommand command) previousCommand;
    private Timer keySwitchTracker;

    public KeyboardController() {
        keyMappings = new Dictionary<Keys, (ICommand command, IController.KeyState keyState)>();
        keySwitchTracker = new Timer(KeySwitchDelay);
    }
     
    public void BindCommand(Keys key, ICommand command, IController.KeyState keyState) {
        keyMappings.Add(key, (command, keyState));
        previousCommand = (key, command);
    }

    public void BindCommand(Buttons button, ICommand command, IController.KeyState keyState) {
        
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

    private bool DoubleCommand(Keys currentKey, ICommand currentCommand)
    {
        bool doubleCommand = (previousCommand.key != currentKey) && (previousCommand.command.GetType() == currentCommand.GetType());
        return doubleCommand && !keySwitchTracker.Status();
    }

    public void Update(Game1 game) {
        previousState = currentState;
        currentState = Keyboard.GetState();
        
        Keys[] pressedKeys = currentState.GetPressedKeys();

        // add timer to allow for switching between controls
        if (pressedKeys.Length == 0)
        {
            keySwitchTracker.ConditionalUpdate();
        }
        else
        {
            foreach (Keys key in pressedKeys)
            {
                if (keyMappings.ContainsKey(key) && GetKeyState(key) == keyMappings[key].keyState && !DoubleCommand(key, keyMappings[key].command))
                {
                    previousCommand = (key, keyMappings[key].command);

                    keyMappings[key].command.Execute(game);

                    keySwitchTracker.Start();
                }
            }
        }
    }
}