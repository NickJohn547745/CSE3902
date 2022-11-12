using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using Microsoft.Xna.Framework;

namespace sprint0.GameStateClasses;

public class GamePlayState : GameState
{

    private HUD mainHUD;
    
    public GamePlayState(Game1 game, HUD hud, IPlayer link, CollisionManager manager)
    {
        this.game = game;
        mainHUD = hud;
        player = link;
        collisionManager = manager;
    }
    
    public override void Update(GameTime gameTime)
    {
        collisionManager.Update(gameTime, game);

        mainHUD.Update(new PlayerInventory(), 3);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        mainHUD.Draw(spriteBatch);

        Room.Draw(spriteBatch);
        
        collisionManager.Draw(spriteBatch);
    }
}