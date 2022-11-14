using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Sprites;

namespace sprint0.Factories;

public class MenuSpriteFactory
{
    private int MenuScale = 4;

    private Texture2D menuSpriteSheet;
    // any other textures needed

    private static MenuSpriteFactory instance = new MenuSpriteFactory();

    public static MenuSpriteFactory Instance
    {
        get { return instance; }
    }

    private MenuSpriteFactory()
    {
    }
    
    public ISprite ItemSelectSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(1, 11, 256, 88) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }

    public ISprite SelectionCursorSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(519, 137, 16, 16), new Rectangle(536, 137, 16, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 8, MenuScale);
    }
    
    public ISprite BoomerangSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(584, 137, 8, 16), new Rectangle(593, 137, 8, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    public ISprite BombSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(604, 137, 8, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    public ISprite ArrowSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(615, 137, 8, 16),new Rectangle(624, 137, 8, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    public ISprite BowSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(633, 137, 8, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    
    public ISprite CandleSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(644, 137, 8, 16), new Rectangle(653, 137, 8, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }

    public ISprite DungeonMapSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(258, 112, 256, 88) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
}