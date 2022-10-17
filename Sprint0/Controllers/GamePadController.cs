using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using sprint0.Interfaces;
using sprint0.Commands;

namespace sprint0.Controllers; 

public class GamePadController : IController {

    private Game1 myG;
    private int playerIndex = 1;

    public GamePadController(Game1 game) {
        myG = game;
    }
    
    public void BindCommand(Keys key, ICommand command, IController.KeyState keyState) {
        
    }

    public void Update(Game1 game) {
        GamePadState currState = GamePadController.GetState(playerIndex);

        if (currState.IsButtonDown(Buttons.A)) new PlayerSwordAttackCommand(myG);
        if (currState.IsButtonDown(Buttons.B)) new NextItemCommand(myG);
        if (currState.IsButtonDown(Buttons.X)) new PreviousItemCommand(myG);
        if (currState.IsButtonDown(Buttons.Y)) new PlayerSwordAttackCommand(myG); 
        if (currState.IsButtonDown(Buttons.RightTrigger)) new NextItemCommand(myG);
        if (currState.IsButtonDown(Buttons.LeftTrigger)) new PreviousItemCommand(myG);
        if (currState.IsButtonDown(Buttons.Start)) new ResetGameCommand(myG);
        if (currState.IsButtonDown(Buttons.Back)) new QuitCommand(myG);
        if (currState.IsButtonDown(Buttons.DpadLeft) || currState.ThumbSticks.Left.X < -0.7f) new MoveLeftCommand(myG);
        if (currState.IsButtonDown(Buttons.DpadRight) || currState.ThumbSticks.Left.X > 0.7f) new MoveRightCommand(myG);
        if (currState.IsButtonDown(Buttons.DpadUp) || currState.ThumbSticks.Left.Y > 0.7f) new MoveUpCommand(myG);
        if (currState.IsButtonDown(Buttons.DpadDown) || currState.ThumbSticks.Left.Y < -0.7f) new MoveDownCommand(myG);

        //change next/previous commands when we implement primary/secondary commands
    }
}