using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class Player : IPlayer {
    public IPlayerState playerState;

    public PlayerAbilityManager AbilityManager;

    public int PlayerHealth;

    public int ScaleFactor;
    

    public int xPos { get; set; }
    public int yPos { get; set; }

    public Player() {
        playerState = new PlayerFacingUpState(this);
        AbilityManager = new PlayerAbilityManager(this);
        PlayerHealth = 6;
        ScaleFactor = 4;
        this.xPos = 150;
        this.yPos = 150;
    }

    public void Draw(SpriteBatch spriteBatch) {
        playerState.Draw(spriteBatch);
        AbilityManager.Draw(spriteBatch);
    }

    public void Update() {
        playerState.Update();
        AbilityManager.Update();
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

    public void SwordAttack() {
        playerState.SwordAttack();
    }

    public void UseAbility(AbilityTypes abilityType) {
        playerState.UseAbility(abilityType);
    }

}