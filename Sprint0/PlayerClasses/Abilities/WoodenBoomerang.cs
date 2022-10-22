using Microsoft.Xna.Framework;
using sprint0.Factories;

namespace sprint0.PlayerClasses.Abilities;

public class WoodenBoomerang : Ability {
    private int frameCounter;
    
    private Vector2 Acceleration;

    private Vector2 initialPosition;

    public WoodenBoomerang(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        sprite = PlayerSpriteFactory.Instance.GetWoodenBoomerangSprite();
        animationFrame = 0;
        if (Velocity.X != 0) {
            Position = Vector2.Add(position, new Vector2(sprite.GetWidth() * (Velocity.X - 1)/2, -sprite.GetHeight()/2));
        }
        else {
            Position = Vector2.Add(position, new Vector2(-sprite.GetWidth()/2, sprite.GetHeight() * (Velocity.Y - 1)/2));
        }
        initialPosition = Position;
        Velocity = Vector2.Multiply(velocity, new Vector2((float)6.5));
        Acceleration = Vector2.Multiply(Vector2.Normalize(Velocity), new Vector2((float)-0.08));
    }
    
    public override void Update(GameTime gameTime, Game1 game) {
        frameCounter++;
        if (frameCounter % 5 == 0) {
            animationFrame++;
        }

        Velocity = Vector2.Add(Velocity, Acceleration);

        Position = Vector2.Add(Position, Velocity);

        if(Vector2.Distance(initialPosition, Position) < 5 && frameCounter > 20) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}