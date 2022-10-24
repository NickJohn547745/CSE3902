using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;

namespace sprint0.Controllers; 

public class GamePadController : IController {

    private Dictionary<Buttons, (ICommand, IController.KeyState)> buttonMappings;

    private GamePadState currentState;
    private GamePadState previousState;
    private int playerIndex = 1;

    public GamepadController()
    {
        buttonMappings = new Dictionary<Buttons, (ICommand, IController.KeyState)>();
    }

    public void BindCommand(Keys key, ICommand command, IController.KeyState keyState)
    {

    }

    public void BindCommand(Buttons button, ICommand command, IController.KeyState keyState)
    {
        buttonMappings.Add(button, (command, keyState));
    }

    private IController.KeyState GetButtonState(Buttons button)
    {
        IController.KeyState result;

        if (currentState.IsButtonDown(button))
        {
            result = IController.KeyState.KeyDown;
            if (previousState.IsButtonUp(button))
                result = IController.KeyState.Pressed;
        }
        else
        {
            result = IController.KeyState.KeyUp;
            if (previousState.IsButtonDown(button))
                result = IController.KeyState.Released;
        }
        return result;
    }

    public void Update(Game1 game)
    {
        previousState = currentState;
        currentState = GamePad.GetState(playerIndex);

        Buttons[] pressedButtons = currentState.Buttons;

        foreach (Buttons button in pressedButtons)
        {
            if (buttonMappings.ContainsKey(button) && GetButtonState(button) == buttonMappings[button].Item2)
            {
                buttonMappings[button].Item1.Execute(game);
            }
        }
    }
}