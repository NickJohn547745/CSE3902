using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sprites;
using System;

namespace sprint0.PlayerClasses; 

public class Player : ICollidable {
    public int ScaleFactor;

    private Vector2 initPosition;
    public Vector2 Position { get; set; }
    public int Health { get; set; }
    public IPlayerState PlayerState { get; set; }
    public PlayerAbilityManager AbilityManager { get; protected set; }

    public Player() {
        PlayerState = new PlayerFacingUpState(this);
        AbilityManager = new PlayerAbilityManager(this);
        Health = 6;
        ScaleFactor = 4;
        Position = new Vector2(150);
        initPosition = Position;
    }

    public Type GetObjectType()
    {
        return this.GetType();
    }
    public Rectangle GetHitBox()
    {
        return new Rectangle((int)Position.X, (int)Position.Y, PlayerState.sprite.GetWidth(), PlayerState.sprite.GetHeight());
    }

    public void Collide(Type type, ICollidable.Edge edge)
    {
        PlayerState.Collide(type, edge);
    }

    public virtual void Draw(SpriteBatch spriteBatch) { 
        PlayerState.Draw(spriteBatch);
        AbilityManager.Draw(spriteBatch);
    }

    public virtual void Update(GameTime gameTime, Game1 game) {
        PlayerState.Update();
        AbilityManager.Update(gameTime, game);
    }

    public virtual void Reset()
    {
        Position = initPosition;
        PlayerState = new PlayerFacingUpState(this);
    }

    public virtual void TakeDamage(Game1 game) {
        Health--;
        game.Player = new DamagedPlayer(this, game);
    }

    public virtual void MoveUp() {
        PlayerState.MoveUp();
    }

    public virtual void MoveDown() {
        PlayerState.MoveDown();
    }

    public virtual void MoveLeft() {
        PlayerState.MoveLeft();
    }

    public virtual void MoveRight() {
        PlayerState.MoveRight();
    }

    public virtual void SwordAttack() {
        PlayerState.SwordAttack();
    }

    public virtual void UseAbility(AbilityTypes abilityType) {
        PlayerState.UseAbility(abilityType);
    }

}