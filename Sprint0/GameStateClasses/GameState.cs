using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.PlayerClasses;
using sprint0.RoomClasses;

namespace sprint0.GameStateClasses;

public class GameState : IGameState
{
    public Game1 game { get; set; }
    public IPlayer player { get; set; }
    public CollisionManager collisionManager { get; private set; }
    public HUD mainHUD { get; set; }
    public Room Room { get; set; }
    public AGameState currentState { get; set; }

    public GameState(Game1 game, HUD hud, IPlayer link, CollisionManager manager, Room room)
    {
        this.game = game;
        mainHUD = hud;
        player = link;
        collisionManager = manager;
        Room = room;
        currentState = new GamePlayState(this);
    }
    
    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentState.Draw(spriteBatch);
    }

    public virtual void TogglePause()
    {
        currentState.TogglePause();
    }
    
    public void Reset()
    {
        currentState.Reset();
    }
}