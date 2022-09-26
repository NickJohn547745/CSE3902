using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses; 

public class Player : IPlayer {
    public IPlayerState playerState;

    public int xPos { get; set; }
    public int yPos { get; set; }

    public Player() {
        playerState = new PlayerFacingUpState(this);
        this.xPos = 150;
        this.yPos = 150;
    }

    public void Draw(SpriteBatch spriteBatch) {
        playerState.Draw(spriteBatch);
    }

    public void Update() {
        throw new System.NotImplementedException();
    }

    public void TakeDamage() {
        
    }

    public void MoveUp() {
        playerState.MoveUp();
    }

    public void MoveDown() {
        playerState.MoveDown();
    }

    public void MoveLeft() {
        playerState.MoveLeft();
    }

    public void MoveRight() {
        playerState.MoveRight();
    }
}