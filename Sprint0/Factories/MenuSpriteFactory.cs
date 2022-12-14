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
    public ISprite MapItemSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(601, 156, 8, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    
    public ISprite CompassItemSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(612, 156, 15, 16) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    
    public ISprite MapRoomSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(519, 108, 8, 8), new Rectangle(528, 108, 8, 8), new Rectangle(537, 108, 8, 8), new Rectangle(546, 108, 8, 8), new Rectangle(555, 108, 8, 8), new Rectangle(564, 108, 8, 8), new Rectangle(573, 108, 8, 8), new Rectangle(582, 108, 8, 8), new Rectangle(591, 108, 8, 8), new Rectangle(600, 108, 8, 8), new Rectangle(609, 108, 8, 8), new Rectangle(618, 108, 8, 8), new Rectangle(627, 108, 8, 8), new Rectangle(636, 108, 8, 8), new Rectangle(645, 108, 8, 8), new Rectangle(654, 108, 8, 8)};
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 20, MenuScale);
    }
    
    public ISprite PlayerMarkerSprite()
    {
        List<Rectangle> frameSource = new List<Rectangle> { new Rectangle(519, 126, 8, 8) };
        return new BasicSprite(TextureStorage.GetInventorySpritesheet(), frameSource, 1, MenuScale);
    }
    
    
}