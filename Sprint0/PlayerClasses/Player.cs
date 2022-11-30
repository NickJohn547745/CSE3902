using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.PlayerClasses.Abilities;

using sprint0.RoomClasses;
using sprint0.Sound;
using System;

namespace sprint0.PlayerClasses;

public class Player : IPlayer {

    private const int MoveBack = 300;
    
    private Vector2 initPosition;

    public PlayerInventory PlayerInventory;
    public ICollidable.ObjectType type { get; set; }
    public Vector2 Position { get; set; }
    public int Health { get; private set; }
    public int ScaleFactor { get; set; }
    public Game1 Game { get; set; }
    public bool IsMultiSprite { get; set; }
    public IPlayerState PlayerState { get; set; }
    public PlayerAbilityManager AbilityManager { get; protected set; }
    public int Damage { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 InitVelocity { get; set; }
    public Vector2 PreviousPosition { get; set; }
    public bool CanMove { get; set; }
    
    public Player(Game1 game) {
        Game = game;
        Position = new Vector2(175, 175);
        initPosition = Position;
        PreviousPosition = Position;

        Reset();
    }
    
    public int GetHealth()
    {
        return Health;
    }
    
    public Rectangle GetHitBox()
    {
        return PlayerState.GetHitBox();
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        if (obj.type == ICollidable.ObjectType.Wall || obj.type == ICollidable.ObjectType.Tile || obj.type == ICollidable.ObjectType.Door)
        {
            CanMove = false;
        }
        PlayerState.Collide(obj, edge);
    }

    public void Draw(SpriteBatch spriteBatch) { 
        PlayerState.Draw(spriteBatch, Color.White);
    }

    public void Update(GameTime gameTime) {
        PlayerState.Update();
        AbilityManager.Update(gameTime);
        CanMove = true;
    }

    public void Reset()
    {
        Position = initPosition;
        PlayerState = new PlayerFacingUpState(this);
        AbilityManager = new PlayerAbilityManager(this);
        PlayerInventory = new PlayerInventory();
        CanMove = true;

        Health = 6;
        ScaleFactor = 4;
        Damage = 0;
        type = ICollidable.ObjectType.Player;
        Velocity = Vector2.Zero;
    }

    private void KnockBack(ICollidable.Edge collideSide)
    {
        switch (collideSide)
        {
            case ICollidable.Edge.Bottom:
                InitVelocity = new Vector2(0, MoveBack);
                break;
            case ICollidable.Edge.Right:
                InitVelocity = new Vector2(-MoveBack, 0);
                break;
            case ICollidable.Edge.Left:
                InitVelocity = new Vector2(MoveBack, 0);
                break;
            case ICollidable.Edge.Top:
                InitVelocity = new Vector2(0, -MoveBack);
                break;
        }

        Velocity = InitVelocity;
    }
    
    public void TakeDamage(int damage, ICollidable.Edge collideSide) {
        Health -= damage;
        KnockBack(collideSide);
        Game.Player = new DamagedPlayer(this, Game);
        CollisionManager.Collidables.Add(Game.Player);
        CollisionManager.Collidables.Remove(this);
        SoundManager.Manager.linkDamageSound().Play();
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

    public virtual void UseAbility(AbilityTypes abilityType) {
        if (PlayerInventory.AbilityCounts[abilityType] > 0) {
            if (abilityType == AbilityTypes.Bomb) {
                PlayerInventory.AbilityCounts[AbilityTypes.Bomb] -= 1;
            }

            PlayerState.UseAbility(abilityType);
        }
    }

    public PlayerInventory GetInventory()
    {
        return this.PlayerInventory;
    }

}