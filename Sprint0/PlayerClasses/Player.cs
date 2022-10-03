using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class Player : IPlayer {
    public int ScaleFactor;

    public Vector2 Position { get; set; }
    public int Health { get; set; }
    public IPlayerState PlayerState { get; set; }
    public PlayerAbilityManager AbilityManager { get; }

    public Player() {
        PlayerState = new PlayerFacingUpState(this);
        AbilityManager = new PlayerAbilityManager(this);
        Health = 6;
        ScaleFactor = 4;
        Position = new Vector2(150);
    }

    public void Draw(SpriteBatch spriteBatch) { 
        PlayerState.Draw(spriteBatch);
        AbilityManager.Draw(spriteBatch);
    }

    public void Update() {
        PlayerState.Update();
        AbilityManager.Update();
    }

    public void TakeDamage(Game1 game) {
        Health--;
        game.Player = new DamagedPlayer(this, game);
    }

    public void MoveUp() {
        PlayerState.MoveUp();
    }

    public void MoveDown() {
        PlayerState.MoveDown();
    }

    public void MoveLeft() {
        PlayerState.MoveLeft();
    }

    public void MoveRight() {
        PlayerState.MoveRight();
    }

    public void SwordAttack() {
        PlayerState.SwordAttack();
    }

    public void UseAbility(AbilityTypes abilityType) {
        PlayerState.UseAbility(abilityType);
    }

}