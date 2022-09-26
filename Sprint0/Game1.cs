using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.Classes;

namespace sprint0;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public List<IController> Controllers { get; set; }
    public List<IEnemy> Enemies { get; private set; }

    private int EnemyIndex;

    public Texture2D Spritesheet;
    private SpriteFont Spritefont;
    private ISprite Credits;
    private int WindowWidth;
    private int WindowHeight;
    

    public ISprite CurrentSprite { get; set; }

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public int GetWindowWidth()
    {
        return WindowWidth;
    }

    public int GetWindowHeight()
    {
        return WindowHeight;
    }

    public void CycleEnemyForward()
    {
        EnemyIndex++;

        // keep index in bounds
        if (EnemyIndex >= Enemies.Count)
        {
            EnemyIndex = 0;
        }
    }

    public void CycleEnemyBackward()
    {
        EnemyIndex--;

        // keep index in bounds
        if (EnemyIndex < 0)
        {
            EnemyIndex = Enemies.Count - 1;
        }
    }
    

protected override void Initialize() {
        // TODO: Add your initialization logic here

        WindowWidth = _graphics.PreferredBackBufferWidth;
        WindowHeight = _graphics.PreferredBackBufferHeight;

        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Spritesheet = Content.Load<Texture2D>("smb_mario_sheet");
        Spritefont = Content.Load<SpriteFont>("Arial");

        TextureStorage.LoadAllTextures(Content);

        Controllers = new List<IController>();
        IController keyboard = new KeyboardController();
        keyboard.BindCommand(Keys.D0, new QuitCommand());
        keyboard.BindCommand(Keys.D1, new StationaryStaticCommand());
        keyboard.BindCommand(Keys.D2, new StationaryAnimatedCommand());
        keyboard.BindCommand(Keys.D3, new MovingStaticCommand());
        keyboard.BindCommand(Keys.D4, new MovingAnimatedCommand());
        keyboard.BindCommand(Keys.O, new EnemyCycleBackwardCommand());
        keyboard.BindCommand(Keys.P, new EnemyCycleForwardCommand());


        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        Enemies = new List<IEnemy>();
        EnemyIndex = 0;
        IEnemy stalfos = new Stalfos(new Vector2 (WindowWidth * 3 / 4, WindowHeight * 3 / 4), new Vector2(25, 25));
        Enemies.Add(stalfos);

        CurrentSprite = new StationaryStaticSprite(Spritesheet);

        Credits = new TextSprite(Spritefont);
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));
        Enemies[EnemyIndex].Update(gameTime, this);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        Enemies[EnemyIndex].Draw(_spriteBatch);
        CurrentSprite.Draw(_spriteBatch, Vector2.One);
        Credits.Draw(_spriteBatch, new Vector2(140, 360));
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}