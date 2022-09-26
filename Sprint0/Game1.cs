using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public List<IController> Controllers { get; set; }

    public Texture2D Spritesheet;
    private SpriteFont Spritefont;
    private ISprite Credits;

    public IPlayer Player;

    public ISprite CurrentSprite { get; set; }

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Spritesheet = Content.Load<Texture2D>("smb_mario_sheet");
        Spritefont = Content.Load<SpriteFont>("Arial");
        
        TextureStorage.LoadAllTextures(Content);

        Controllers = new List<IController>();
        IController keyboard = new KeyboardController();
        keyboard.BindCommand(Keys.D0, new Command0());
        keyboard.BindCommand(Keys.W, new MoveUpCommand());
        keyboard.BindCommand(Keys.S, new MoveDownCommand());
        keyboard.BindCommand(Keys.D, new MoveRightCommand());
        keyboard.BindCommand(Keys.A, new MoveLeftCommand());
        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        CurrentSprite = new StationaryStaticSprite(Spritesheet);

        Player = new Player();

        Credits = new TextSprite(Spritefont);
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        Player.Draw(_spriteBatch);
        _spriteBatch.End();
        CurrentSprite.Draw(_spriteBatch, Vector2.One, Color.White);
        Credits.Draw(_spriteBatch, new Vector2(140, 360), Color.White);

        base.Draw(gameTime);
    }
}