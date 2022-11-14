using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;

namespace sprint0.MenuItems.Inventory;

public class DungeonMap
{
    private static DungeonMap instance = new DungeonMap();
    
    public static DungeonMap Instance
    {
        get {
            return instance;
        }
    }
    
    private ISprite Background { get; set; }

    private DungeonMap()
    {
        Background = MenuSpriteFactory.Instance.DungeonMapSprite();
    }

    public void Update()
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Background.Draw(spriteBatch, new Vector2(0, 352), SpriteEffects.None, Color.White);
    }
    
}