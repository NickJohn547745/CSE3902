using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses;

public class PlayerItemPickupState : IPlayerState
{
    private Player Player;
    public ISprite sprite { get; set; }

    public PlayerItemPickupState(Player player)
    {
        Player = player;
    }
    public Rectangle GetHitBox()
    {
        return new Rectangle((int)Player.Position.X, (int)Player.Position.Y, sprite.GetWidth(), sprite.GetHeight());
    }

    public void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        // No collisions when in pickup state
    }

    public void Draw(SpriteBatch spriteBatch, Color color)
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void MoveUp()
    {
        // Can't move while in pickup state
    }

    public void MoveDown()
    {
        // Can't move while in pickup state
    }

    public void MoveLeft()
    {
        // Can't move while in pickup state
    }

    public void MoveRight()
    {
        // Can't move while in pickup state
    }

    public void SwordAttack()
    {
        // Can't attack while in pickup state
    }

    public void UseAbility(AbilityTypes abilityType)
    {
        // Can't use abilities while in pickup state
    }
}