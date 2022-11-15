using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0.MenuItems.Inventory;

namespace sprint0.GameStateClasses;

public class InventoryState : AGameState
{
    private AbilitySelect AbilitySection { get; set; }
    private DungeonMap MapSection { get; set; }
    public InventoryState(GameState state)
    {
        gameState = state;
        AbilitySelect.Instance.UpdateInventory(gameState.player.GetInventory());
        AbilitySection = AbilitySelect.Instance;
        DungeonMap.Instance.UpdateInventory(gameState.player.GetInventory());
        MapSection = DungeonMap.Instance;
    }

    public override void Update(GameTime gameTime)
    {
        gameState.mainHUD.Update(gameState.player.GetInventory(), gameState.player.GetHealth(), gameState.game.GetLevelIndex());
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        AbilitySection.Draw(spriteBatch);
        MapSection.Draw(spriteBatch);
        gameState.mainHUD.Draw(spriteBatch);
    }
}