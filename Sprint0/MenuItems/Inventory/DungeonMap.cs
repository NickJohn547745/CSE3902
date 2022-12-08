using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Factories;
using sprint0.Interfaces;
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

    public int[,] Map { get; set; } = new int[16, 16];
    public int[] CurrentRoom { get; set; } = new int[2] { 3, 7 };
    
    private ISprite Background { get; set; }

    private ISprite MapItem { get; set; }
    private ISprite CompassItem { get; set; }
    
    private ISprite MapRoom { get; set; }
    private ISprite PlayerMarker { get; set; }
    
    private PlayerInventory Inventory { get; set; }

    private DungeonMap()
    {
        Background = MenuSpriteFactory.Instance.DungeonMapSprite();
        MapItem = MenuSpriteFactory.Instance.MapItemSprite();
        CompassItem = MenuSpriteFactory.Instance.CompassItemSprite();
        MapRoom = MenuSpriteFactory.Instance.MapRoomSprite();
        PlayerMarker = MenuSpriteFactory.Instance.PlayerMarkerSprite();
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

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (Map[i, j] != 0)
                {
                    Vector2 position = new Vector2(512 + i * MapRoom.GetWidth(), 384 + j * MapRoom.GetHeight());
                    MapRoom.Draw(spriteBatch, position, Map[i,j] - 1, SpriteEffects.None,Color.White);
                    if (i == CurrentRoom[0] && j == CurrentRoom[1])
                    {
                        PlayerMarker.Draw(spriteBatch, Vector2.Add(position, new Vector2(MapRoom.GetWidth()/4, MapRoom.GetHeight()/4)), SpriteEffects.None, Color.White);
                    }
                }
            }
        }
    }

    public void AddRoomToMap(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                CurrentRoom[1] -= 1;
                break;
            case Direction.Down:
                CurrentRoom[1] += 1;
                break;
            case Direction.Left:
                CurrentRoom[0] -= 1;
                break;
            case Direction.Right:
                CurrentRoom[0] += 1;
                break;
        }

        Map[CurrentRoom[0], CurrentRoom[1]] = 16;
    }
    
}