using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

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
    

    public IPlayer Player;

    public ISprite CurrentSprite { get; set; }

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);

        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

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

    public void PreviousItem()
    {
        this.PreviousItem();
    }

    public void NextItem()
    {
        this.NextItem();
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

        TextureStorage.LoadAllTextures(Content);

        Controllers = new List<IController>();
        IController keyboard = new KeyboardController();
        
        keyboard.BindCommand(Keys.D0, new QuitCommand());
        keyboard.BindCommand(Keys.W, new MoveUpCommand());
        keyboard.BindCommand(Keys.S, new MoveDownCommand());
        keyboard.BindCommand(Keys.D, new MoveRightCommand());
        keyboard.BindCommand(Keys.A, new MoveLeftCommand());
        keyboard.BindCommand(Keys.Z, new PlayerSwordAttackCommand());
        keyboard.BindCommand(Keys.N, new PlayerSwordAttackCommand());
        keyboard.BindCommand(Keys.I, new NextItemCommand());
        keyboard.BindCommand(Keys.U, new PreviousItemCommand());
        
        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        Enemies = new List<IEnemy>();
        EnemyIndex = 0;
        IEnemy stalfos = new Stalfos(new Vector2 (WindowWidth * 3 / 4, WindowHeight * 3 / 4), new Vector2(25, 25));
        Enemies.Add(stalfos);

        CurrentSprite = new StationaryStaticSprite(Spritesheet);

        Player = new Player();

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
        Player.Draw(_spriteBatch);
        _spriteBatch.End();
        CurrentSprite.Draw(_spriteBatch, Vector2.One);
        Credits.Draw(_spriteBatch, new Vector2(140, 360));

        base.Draw(gameTime);
    }

    public void reset()
    {

    }
}