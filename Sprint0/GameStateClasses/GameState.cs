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
    public SpriteFont Font { get; set; }

    public GameState(Game1 game, HUD hud, IPlayer link, CollisionManager manager, Room room, SpriteFont font)
    {
        this.game = game;
        mainHUD = hud;
        player = link;
        collisionManager = manager;
        Room = room;
        Font = font;
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

    public void TransitionState(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Pause:
                currentState = new GamePauseState(this);
                break;
            case GameStates.Play:
                currentState = new GamePlayState(this);
                break;
            case GameStates.Inventory:
                if(currentState.GetType() != typeof(InventoryState))
                    currentState = new InventoryState(this);
                else
                    currentState = new GamePlayState(this);
                
                break;
            default:
                break;
        }
    }
    
}