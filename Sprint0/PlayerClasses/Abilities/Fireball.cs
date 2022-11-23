using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.RoomClasses;

namespace sprint0.PlayerClasses.Abilities;

public class Fireball : Ability {
    private Vector2 finalPosition;
    private int waitFrames;

    public Fireball(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Velocity = Vector2.Multiply(velocity, new Vector2(4));
        sprite = PlayerSpriteFactory.Instance.GetFireballSprite();
        if (velocity.X != 0) {
            Position = Vector2.Add(position, new Vector2(sprite.GetWidth() * (velocity.X - 1)/2, -sprite.GetHeight()/2));
        }
        else {
            Position = Vector2.Add(position, new Vector2(-sprite.GetWidth()/2, sprite.GetHeight() * (velocity.Y - 1)/2));
        }
        finalPosition = Vector2.Add(Position, Vector2.Multiply(velocity, new Vector2(128)));
        type = ICollidable.ObjectType.Ability;
    }

    //Vector2 normalizedVelocity = Vector2.Normalize(velocity);
    public override void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, Position, SpriteEffects.None, Color.White);
    }

    public override void Update(GameTime gameTime) {
        if (Vector2.Distance(Position, finalPosition) < 5) {
            waitFrames++;
        }
        else {
            Position = Vector2.Add(Position, Velocity);
        }

        if (waitFrames == 20) {
            CollisionManager.Collidables.Remove(this);
            player.AbilityManager.RemoveCurrentAbility(AbilityTypes.Fireball);
        }
    }
    
    public override void Collide(ICollidable obj, ICollidable.Edge edge)
    {
        if (obj.type == ICollidable.ObjectType.Wall) {
            Velocity = Vector2.Zero;
            finalPosition = Position;
        }

    }
}