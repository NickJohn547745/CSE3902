using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.PlayerClasses;
using sprint0.RoomClasses;

namespace sprint0.GameStateClasses;

public abstract class GameState : IGameState
{
    protected static Game1 game;
    protected static IPlayer player;
    protected static CollisionManager collisionManager;
    protected static HUD mainHUD;
    public Room Room { get; set; }

    public void Initialize(Game1 game, HUD hud, IPlayer link, CollisionManager manager)
    {
        GameState.game = game;
        mainHUD = hud;
        player = link;
        collisionManager = manager;
    }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    public virtual void PauseGame()
    {
        
    }
    
    public void Reset()
    {
        
    }
}