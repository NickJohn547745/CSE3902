using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.Managers;
using sprint0.PlayerClasses.Abilities;
using sprint0.Sound;

namespace sprint0.PlayerClasses;

public class Player : IPlayer {

    private const int MoveBack = 300;
    private const int TileOffset = 1;

    private Vector2 initPosition;

    public PlayerInventory PlayerInventory;
    public ICollidable.ObjectType Type { get; set; }
    public Vector2 Position { get; set; }
    public int Health { get; private set; }
    public int ScaleFactor { get; set; }
    public Game1 Game { get; set; }
    public bool IsMultiSprite { get; set; }
    public IPlayerState PlayerState { get; set; }
    public PlayerAbilityManager AbilityManager { get; protected set; }
    public int Damage { get; set; }
    public Vector2 Velocity { get; set; }
    public bool CanMove { get; set; }

    public PlayerWeapons PrimaryWeapon { get; set; }
    
    public Player(Game1 game) {
        Game = game;
        Position = new Vector2(175, 175);
        initPosition = Position;
        Velocity = Vector2.Zero;
        PrimaryWeapon = PlayerWeapons.Wand;

        Reset();
    }

    public int GetHealth()
    {
        return Health;
    }

    public void SetHealth(int hp)
    {
        Health = hp;
    }

    public Vector2 GetVelocity()
    {
        return Velocity;
    }

    public Rectangle GetHitBox()
    {
        return PlayerState.GetHitBox();
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        if (obj.Type == ICollidable.ObjectType.Wall || obj.Type == ICollidable.ObjectType.Tile || obj.Type == ICollidable.ObjectType.Door)
        {
            CanMove = false;
            Rectangle objBounds = obj.GetHitBox();
            Rectangle playerBounds = GetHitBox();
            switch (edge)
            {
                case ICollidable.Edge.Top:
                    Position = new Vector2(playerBounds.X, objBounds.Top - playerBounds.Height - TileOffset);
                    break;
                case ICollidable.Edge.Right:
                    Position = new Vector2(objBounds.X - playerBounds.Width - TileOffset, playerBounds.Y);
                    break;
                case ICollidable.Edge.Left:
                    Position = new Vector2(objBounds.Right + TileOffset, playerBounds.Y);
                    break;
                case ICollidable.Edge.Bottom:
                    Position = new Vector2(playerBounds.X, objBounds.Bottom + TileOffset);
                    break;
            }
        }
        PlayerState.Collide(obj, edge);
    }

    public void Draw(SpriteBatch spriteBatch) { 
        PlayerState.Draw(spriteBatch, Color.White);
    }

    public void Update(GameTime gameTime) {       
        PlayerState.Update();
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
        Type = ICollidable.ObjectType.Player;
        Velocity = Vector2.Zero;
    }

    private Vector2 KnockBack(ICollidable.Edge collideSide)
    {
        Vector2 initVelocity = Vector2.Zero;
        switch (collideSide)
        {
            case ICollidable.Edge.Bottom:
                initVelocity = new Vector2(0, MoveBack);
                break;
            case ICollidable.Edge.Right:
                initVelocity = new Vector2(-MoveBack, 0);
                break;
            case ICollidable.Edge.Left:
                initVelocity = new Vector2(MoveBack, 0);
                break;
            case ICollidable.Edge.Top:
                initVelocity = new Vector2(0, -MoveBack);
                break;
        }

        return initVelocity;
    }
    
    public void TakeDamage(int damage, ICollidable.Edge collideSide) {
        Health -= damage;
      
        Game.Player = new DamagedPlayer(this, Game, KnockBack(collideSide));
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

    public void PrimaryAttack() {
        PlayerState.PrimaryAttack();
    }

    public virtual void UseAbility() {
        if(AbilityManager.ActiveAbility == null && PlayerInventory.CurrentAbility != AbilityTypes.None)
            PlayerState.UseAbility(PlayerInventory.CurrentAbility);
    }

    public PlayerInventory GetInventory()
    {
        return this.PlayerInventory;
    }

}