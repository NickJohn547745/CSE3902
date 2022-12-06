using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Managers;

namespace sprint0.PlayerClasses.Abilities;

public class Arrow : Ability {

    private int spriteVersion;
    private int hitFrame;
    public Arrow(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        if (player.PlayerInventory.Abilities[AbilityTypes.Arrow] == 1)
        {
            if (velocity.X == 0) {
                spriteVersion = 0;
                sprite = PlayerSpriteFactory.Instance.GetWoodenArrowVerticalSprite();
                Position = Vector2.Add(position, new Vector2(-sprite.GetWidth()/2, sprite.GetHeight() * (velocity.Y - 1)/2));
            }
            else {
                spriteVersion = 1;
                sprite = PlayerSpriteFactory.Instance.GetWoodenArrowHorizontalSprite();
                Position = Vector2.Add(position, new Vector2(sprite.GetWidth() * (velocity.X - 1)/2, -sprite.GetHeight()/2));
            }
        }
        else if (player.PlayerInventory.Abilities[AbilityTypes.Arrow] == 2)
        {
            if (velocity.X == 0) {
                spriteVersion = 0;
                sprite = PlayerSpriteFactory.Instance.GetSilverArrowVerticalSprite();
                Position = Vector2.Add(position, new Vector2(-sprite.GetWidth()/2, sprite.GetHeight() * (velocity.Y - 1)/2));
            }
            else {
                spriteVersion = 1;
                sprite = PlayerSpriteFactory.Instance.GetSilverArrowHorizontalSprite();
                Position = Vector2.Add(position, new Vector2(sprite.GetWidth() * (velocity.X - 1)/2, -sprite.GetHeight()/2));
            }
        }
        Velocity = Vector2.Multiply(velocity, new Vector2(5));
        Type = ICollidable.ObjectType.Ability;
        Damage = 2;
    }

    public override void Draw(SpriteBatch spriteBatch) {
        SpriteEffects effects = SpriteEffects.None;
        if (spriteVersion == 0 && Velocity.Y > 0) {
            effects = SpriteEffects.FlipVertically;
        }
        else if (spriteVersion == 1 && Velocity.X < 0) {
            effects = SpriteEffects.FlipHorizontally;
        }

        sprite.Draw(spriteBatch, Position, effects, Color.White);
    }
    
    public override void Update(GameTime gameTime) {
        Position = Vector2.Add(Position, Velocity);

        if (hitFrame > 0)
            hitFrame++;

        if (hitFrame == 5) {
            CollisionManager.Collidables.Remove(this);
            player.AbilityManager.ActiveAbility = null;
        }
    }
    
    public override void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        switch (obj.Type) {
            case ICollidable.ObjectType.Wall:
            case ICollidable.ObjectType.Tile:
            case ICollidable.ObjectType.Enemy:
            case ICollidable.ObjectType.Door:

                    Velocity = Vector2.Zero;
                sprite = PlayerSpriteFactory.Instance.GetArrowHitSprite();
                if (hitFrame == 0)
                    hitFrame = 1;
                break;
        }
    }
}