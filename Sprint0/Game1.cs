using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Interfaces;
using sprint0.Classes;

namespace sprint0;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public List<IController> Controllers { get; set; }
    
    public Texture2D Spritesheet;
    public Texture2D BackgroundSpritesheet;
    private SpriteFont Spritefont;
    private ISprite Credits;
    private TextureStorage storage;

    public ISprite CurrentSprite { get; set; }

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here

        storage = new TextureStorage(Content);

        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Spritefont = Content.Load<SpriteFont>("Arial");

        storage.LoadAllTextures();

        Spritesheet = storage.GetLinkSpritesheet();
        BackgroundSpritesheet = storage.GetOuterborderSpritesheet();

        Controllers = new List<IController>();
        IController keyboard = new KeyboardController();
        keyboard.BindCommand(Keys.Escape, new QuitCommand());
        keyboard.BindCommand(Keys.D0, new QuitCommand());
        keyboard.BindCommand(Keys.D1, new StationaryStaticCommand());
        keyboard.BindCommand(Keys.D2, new StationaryAnimatedCommand());
        keyboard.BindCommand(Keys.D3, new MovingStaticCommand());
        keyboard.BindCommand(Keys.D4, new MovingAnimatedCommand());

        keyboard.BindCommand(Keys.W, new MoveUpCommand());
        keyboard.BindCommand(Keys.A, new MoveLeftCommand());
        keyboard.BindCommand(Keys.S, new MoveDownCommand());
        keyboard.BindCommand(Keys.D, new MoveRightCommand());

        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        CurrentSprite = new StationaryStaticSprite(Spritesheet);

        Credits = new TextSprite(Spritefont);
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(BackgroundSpritesheet, 
            new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), 
            Color.White);
        _spriteBatch.End();

        CurrentSprite.Draw(_spriteBatch, Vector2.One, Color.White);
        Credits.Draw(_spriteBatch, new Vector2(140, 360), Color.White);

        base.Draw(gameTime);
    }
}