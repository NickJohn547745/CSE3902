using sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Classes;
using sprint0.PlayerClasses;
using sprint0.RoomClasses;

namespace sprint0.GameStateClasses;

public abstract class GameState : IGameState
{
    protected Game1 game;
    protected IPlayer player;
    protected CollisionManager collisionManager;
    public Room Room { get; set; }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    
    public void Reset()
    {
        
    }
}