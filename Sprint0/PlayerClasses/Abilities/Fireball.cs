using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;

namespace sprint0.PlayerClasses.Abilities;

public class Fireball : Ability {
    private Vector2 finalPosition;
    private int waitFrames;
    private int frameCount;

    public Fireball(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        Velocity = Vector2.Multiply(velocity, new Vector2(4));
        finalPosition = Vector2.Add(position, Vector2.Multiply(velocity, new Vector2(128)));
        sprite = PlayerSpriteFactory.Instance.GetFireballSprite();
    }

    //Vector2 normalizedVelocity = Vector2.Normalize(velocity);
    public override void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch, Position, SpriteEffects.None);
    }

    public override void Update(GameTime gameTime, Game1 game) {
        frameCount++;
        if (Vector2.Distance(Position, finalPosition) < 5) {
            waitFrames++;
        }
        else {
            Position = Vector2.Add(Position, Velocity);
        }

        if (waitFrames == 20) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}