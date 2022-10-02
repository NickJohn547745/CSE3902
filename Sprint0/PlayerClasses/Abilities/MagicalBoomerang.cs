using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace sprint0.PlayerClasses.Abilities; 

public class MagicalBoomerang : IAbility {
    private Player player;

    private int frameCounter = 0;
    private int animationFrame = 0;
    
    private Vector2 Velocity;
    private Vector2 Acceleration;
    
    public Vector2 Position { get; set; }
    private Vector2 initialPosition;

    public MagicalBoomerang(Player player, Vector2 position, Vector2 velocity) {
        this.player = player;
        Position = position;
        initialPosition = Position;
        Velocity = Vector2.Multiply(velocity, new Vector2((float)9));
        Acceleration = Vector2.Multiply(Vector2.Normalize(Velocity), new Vector2((float)-0.1));
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetMagicalBoomerangSprite(animationFrame);

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