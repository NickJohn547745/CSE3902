using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses; 

public class DamagedPlayer : IPlayer {

    private Player decoratedPlayer;
    private Game1 Game;
    private int timer = 120;
    private int frameCountdown = 0;


    public int Damage {
        get => decoratedPlayer.Damage;
        set => decoratedPlayer.Damage = value;
    }

    public DamagedPlayer(Player decoratedPlayer, Game1 game) {
        this.decoratedPlayer = decoratedPlayer;
        Game = game;
        PlayerState = decoratedPlayer.PlayerState;
        Position = decoratedPlayer.Position;
        initPosition = Position;
        AbilityManager = this.decoratedPlayer.AbilityManager;
        sprite = PlayerSpriteFactory.Instance.GetDamagedSprite();
        type = ICollidable.objectType.Player;
    }

    void RemoveDecorator() {
        Game.Player = decoratedPlayer;
        Game.CollidablesToAdd.Add(Game.Player);
        Game.CollidablesToDelete.Add(this);
    }

    public void Draw(SpriteBatch spriteBatch) {
        if(frameCountdown > 5)
            decoratedPlayer.PlayerState.Draw(spriteBatch, Color.Red);
        else {
            decoratedPlayer.PlayerState.Draw(spriteBatch, Color.Tan);
        }
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge) {
        decoratedPlayer.Collide(obj, edge);
    }

    public Type GetObjectType() {
        return decoratedPlayer.GetObjectType();
    }

    public Rectangle GetHitBox() {
        return decoratedPlayer.GetHitBox();
    }

    public void Update(GameTime gameTime, Game1 game) {
        timer--;
        frameCountdown++;

        if (frameCountdown > 10)
            frameCountdown = 0;
        if (timer == 0) {
            RemoveDecorator();
        }
        decoratedPlayer.Update(gameTime, game);
    }

    public void Reset(Game1 game)
    {
        RemoveDecorator();
        decoratedPlayer.Reset(game);
    }

    public void TakeDamage(int damage) {
        // Do nothing since player just took damage
    }

    public void MoveUp() {
        decoratedPlayer.MoveUp();
    }

    public void MoveDown() {
        decoratedPlayer.MoveDown();
    }

    public void MoveLeft() {
        decoratedPlayer.MoveLeft();
    }

    public void MoveRight() {
        decoratedPlayer.MoveRight();
    }
    
    public void SwordAttack() {
        decoratedPlayer.SwordAttack();
    }

    public void UseAbility(AbilityTypes abilityType) {
        decoratedPlayer.UseAbility(abilityType);
    }
    
}