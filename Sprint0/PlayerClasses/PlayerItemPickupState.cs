using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.PlayerClasses.Abilities;

namespace sprint0.PlayerClasses;

public class PlayerItemPickupState : IPlayerState
{
    private Player Player;
    public ISprite sprite { get; set; }
    private int PickupType;

    private int frameCounter = 0;

    public PlayerItemPickupState(Player player, int pickupType)
    {
        Player = player;
        sprite = PlayerSpriteFactory.Instance.GetItemPickupSprite();
        PickupType = pickupType;
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
        sprite.Draw(spriteBatch, Player.Position, PickupType, SpriteEffects.None, color);
    }

    public void Update()
    {
        frameCounter++;

        if (frameCounter == 20)
        {
            Player.PlayerState = new PlayerFacingDownState(Player);
        }
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