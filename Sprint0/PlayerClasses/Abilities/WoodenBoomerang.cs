using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Utils;

namespace sprint0.PlayerClasses.Abilities; 

public class WoodenBoomerang : IAbility {
    private Player player;

    private int frameCounter;
    private int animationFrame;
    
    private Vector2 Velocity;
    private Vector2 Acceleration;
    public Vector2 Position { get; set; }

    private Vector2 initialPosition;

    public WoodenBoomerang(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        initialPosition = Position;
        Velocity = Vector2.Multiply(velocity, new Vector2((float)6.5));
        Acceleration = Vector2.Multiply(Vector2.Normalize(Velocity), new Vector2((float)-0.08));
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetWoodenBoomerangSprite(animationFrame);
        spriteBatch.Draw(sprite, Position, texturePos, Color.White, 0, new Vector2((float)texturePos.Width/2,(float)texturePos.Height/2), player.ScaleFactor, SpriteEffects.None, 0);
    }
    
    public void Update() {
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