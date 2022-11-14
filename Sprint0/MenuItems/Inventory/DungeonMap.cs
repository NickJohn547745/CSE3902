using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.PlayerClasses;

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

    private ISprite MapItem { get; set; }
    private ISprite CompassItem { get; set; }
    
    private PlayerInventory Inventory { get; set; }

    private DungeonMap()
    {
        Background = MenuSpriteFactory.Instance.DungeonMapSprite();
        MapItem = MenuSpriteFactory.Instance.MapItemSprite();
        CompassItem = MenuSpriteFactory.Instance.CompassItemSprite();
    }

    public void UpdateInventory(PlayerInventory inventory)
    {
        Inventory = inventory;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Background.Draw(spriteBatch, new Vector2(0, 352), SpriteEffects.None, Color.White);
        if(Inventory.MapUnlocked)
            MapItem.Draw(spriteBatch, new Vector2(192,448), SpriteEffects.None, Color.White);
        if(Inventory.CompassUnlocked)
            CompassItem.Draw(spriteBatch, new Vector2(176,608), SpriteEffects.None, Color.White);
    }
    
}