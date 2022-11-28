using Microsoft.Xna.Framework.Graphics;

namespace sprint0.GameStateClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0.Factories;

public class GameWinState : AGameState
{
    private readonly string gameWin = "You WON!";
    private readonly string reset = "Press 'r' to reset";
    private const float gameScale = 5;
    private const float resetScale = 3;
    private const int gameOriginX = 60;
    private const int gameOriginY = 25;
    private const int resetOriginX = 80;
    private const int scale = 15;
    private ISprite triforce;
    private Vector2 textPos;

    public GameWinState(GameStateManager state)
    {
        gameState = state;
        Mute();
        textPos = new Vector2(Game1.WindowWidth / 2, Game1.WindowHeight / 2);
        triforce = ItemSpriteFactory.Instance.TriforceSprite(scale);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.GraphicsDevice.Clear(Color.White);
        
        triforce.Draw(spriteBatch, new Vector2(textPos.X - triforce.GetWidth() / 2, triforce.GetHeight()), SpriteEffects.None, Color.White);
        spriteBatch.DrawString(gameState.Font, gameWin, textPos, Color.Green, 0f, new Vector2(gameOriginX, gameOriginY), gameScale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(gameState.Font, reset, textPos, Color.DarkGreen, 0f, new Vector2(resetOriginX, 0), resetScale, SpriteEffects.None, 0f);
    }

    public override void Reset()
    {
        Unmute();
        gameState.currentState = new GamePlayState(gameState);
    }
}