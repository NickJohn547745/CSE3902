using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Enemies;
using sprint0.Interfaces;
using sprint0.ItemClasses;
using sprint0.PlayerClasses;
using sprint0.TileClasses;

namespace sprint0;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public List<IController> Controllers { get; set; }
    public List<IEnemy> Enemies { get; private set; }

    private int EnemyIndex;

    private TileType[] tileList = new TileType[10];
    public int TileIndex = 0;
    private ItemType[] itemList = new ItemType[13];
    public int itemIndex = 0;

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
        //this.PreviousItem();
    }

    public void NextItem()
    {
        //this.NextItem();
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
        keyboard.BindCommand(Keys.I, new CycleForwardItemCommand());
        keyboard.BindCommand(Keys.U, new CyclePreviousItemCommand());
        keyboard.BindCommand(Keys.T, new CycleForwardTileCommand());
        keyboard.BindCommand(Keys.Y, new CyclePreviousTileCommand());

        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        tileList[0] = new TileType1();
        tileList[1] = new TileType2();
        tileList[2] = new TileType3();
        tileList[3] = new TileType4();
        tileList[4] = new TileType5();
        tileList[5] = new TileType6();
        tileList[6] = new TileType7();
        tileList[7] = new TileType8();
        tileList[8] = new TileType9();
        tileList[9] = new TileType10();

        itemList[0] = new Arrow();
        itemList[1] = new Bomb();
        itemList[2] = new Boomerang();
        itemList[3] = new Bow();
        itemList[4] = new Clock();
        itemList[5] = new Compass();
        itemList[6] = new Fairy();
        itemList[7] = new Heart();
        itemList[8] = new HeartContainer();
        itemList[9] = new Key();
        itemList[10] = new Map();
        itemList[11] = new Rupee();
        itemList[12] = new Triforce();

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

        int tRemainder = (TileIndex % 9);
        TileType tile = tileList[(tRemainder < 0) ? (9 + tRemainder) : tRemainder];
        tile.Draw(_spriteBatch);

        int iRemainder = (itemIndex % 9);
        ItemType item = itemList[(iRemainder < 0) ? (9 + iRemainder) : iRemainder];
        item.Draw(_spriteBatch);

        base.Draw(gameTime);
    }

    public void reset()
    {

    }
}