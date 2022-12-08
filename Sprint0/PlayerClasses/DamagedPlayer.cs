using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses;

public class DamagedPlayer : IPlayer {

    private const int DamageHalfDone = 5;
    private const int DamageDone = 10;

    public Vector2 Position { get; set; }
    private Player decoratedPlayer;
    private Game1 Game;
    private int timer = 120;
    private int frameCountdown = 0;
    public Vector2 Velocity { get; set; }
    private Vector2 InitVelocity;
    public Vector2 PreviousPosition { get; set; }
    public ICollidable.ObjectType Type { get; set; }

    public PlayerWeapons PrimaryWeapon
    {
        get => decoratedPlayer.PrimaryWeapon; 
        set => decoratedPlayer.PrimaryWeapon = value;
    }

    public int Damage {
        get => decoratedPlayer.Damage;
        set => decoratedPlayer.Damage = value;
    }

    public DamagedPlayer(Player decoratedPlayer, Game1 game, Vector2 velocity) {
        this.decoratedPlayer = decoratedPlayer;
        InitVelocity = velocity;
        Velocity = velocity;
        Game = game;
        Type = ICollidable.ObjectType.Player;
    }

    public int GetHealth()
    {
        return decoratedPlayer.Health;
    }

    public void SetHealth(int hp)
    {
        decoratedPlayer.SetHealth(hp);
    }

    void RemoveDecorator() {
        Game.Player = decoratedPlayer;
        CollisionManager.Collidables.Add(Game.Player);
        CollisionManager.Collidables.Remove(this);
    }

    public void Draw(SpriteBatch spriteBatch) {
        if(frameCountdown > DamageHalfDone)
            decoratedPlayer.PlayerState.Draw(spriteBatch, Color.Red);
        else {
            decoratedPlayer.PlayerState.Draw(spriteBatch, Color.Tan);
        }
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge) {
        if (obj.Type == ICollidable.ObjectType.Wall || obj.Type == ICollidable.ObjectType.Tile)
        {
            Velocity = Vector2.Zero;
            decoratedPlayer.Collide(obj, edge);
        }
    }

    public Vector2 GetVelocity()
    {
        return decoratedPlayer.Velocity + Velocity;
    }

    public Rectangle GetHitBox() {
        return decoratedPlayer.GetHitBox();
    }

    public void Update(GameTime gameTime) {
        timer--;
        frameCountdown++;
        PreviousPosition = decoratedPlayer.Position; 
        
        if (Math.Abs(Velocity.X) > DamageHalfDone || Math.Abs(Velocity.Y) > DamageHalfDone)
        {
            decoratedPlayer.Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity -= InitVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (frameCountdown > DamageDone)
            frameCountdown = 0;
        if (timer == 0) {
            Velocity = Vector2.Zero;
            RemoveDecorator();
        }
        decoratedPlayer.Update(gameTime);
    }

    public void Reset()
    {
        RemoveDecorator();
        decoratedPlayer.Reset();
    }

    public void TakeDamage(int damage, ICollidable.Edge collideSide) {
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
    
    public void PrimaryAttack() {
        decoratedPlayer.PrimaryAttack();
    }

    public void UseAbility() {
        decoratedPlayer.UseAbility();
    }

    public PlayerInventory GetInventory()
    {
        return decoratedPlayer.GetInventory();
    }

}