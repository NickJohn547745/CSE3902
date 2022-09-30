using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.Utils;

namespace sprint0.PlayerClasses.Abilities; 

public class MagicalBoomerang : IAbility {
    private Player player;
    private int xPos;
    private int yPos;

    private int frameCounter = 0;
    private int animationFrame = 0;
    
    private Direction direction;

    public MagicalBoomerang(Player player,int xPos, int yPos, Direction direction) {
        this.player = player;
        this.xPos = xPos;
        this.yPos = yPos;
        this.direction = direction;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetMagicalBoomerangSprite(animationFrame);
        Rectangle pos = new Rectangle(xPos, yPos, texturePos.Width*player.ScaleFactor, texturePos.Height*player.ScaleFactor);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);
    }
    
    public void Update() {
        frameCounter++;
        if (frameCounter % 5 == 0) {
            animationFrame++;
        }
        
        if (direction == Direction.Down) {
            yPos += 3;
        }
        else if (direction == Direction.Up) {
            yPos -= 3;
        }
        else if (direction == Direction.Left) {
            xPos -= 3;
        }
        else if (direction == Direction.Right) {
            xPos += 3;
        }

        if (frameCounter == 60) {
            player.AbilityManager.RemoveCurrentAbility();
        }
    }
}