using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Factories;
using sprint0.Interfaces;

namespace sprint0.PlayerClasses.Abilities; 

public class Bomb : IAbility {
    private Player player;
    private int xPos;
    private int yPos;

    private int frameCounter = 0;
    private int animationFrame = 0;

    public Bomb(Player player,int xPos, int yPos) {
        this.player = player;
        this.xPos = xPos;
        this.yPos = yPos;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        Texture2D sprite = TextureStorage.GetPlayerSpritesheet();
        Rectangle texturePos = PlayerSpriteFactory.GetBombSprite(animationFrame);
        Rectangle pos = new Rectangle(xPos, yPos, texturePos.Width*player.ScaleFactor, texturePos.Height*player.ScaleFactor);
        
        spriteBatch.Draw(sprite, pos,texturePos, Color.White);
    }

    public void Update() {
        frameCounter++;
        if (frameCounter == 20) {
            animationFrame = 1;
        }
        else if (frameCounter == 25) {
            animationFrame = 2;
        }
        else if (frameCounter == 30) {
            animationFrame = 3;
        }
        else if (frameCounter == 35) {
            player.AbilityManager.RemoveBomb();
        }
    }
}