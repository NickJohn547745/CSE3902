using System.Collections.Generic;
using System.Linq;
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
using sprint0.RoomClasses;
using sprint0.FileReaderClasses;
using sprint0.Sound;

namespace sprint0;

public class Game1 : Game {

    private const float enemySpeed = 60;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public CollisionManager CollisionManager { get; private set; }
    public List<IController> Controllers { get; set; }
    public List<ICollidable> EnemyList { get; private set; }
    public List<ICollidable> TileList { get; private set; }
    public List<IItem> ItemList { get; private set; }
    public List<LevelConfig> LevelList { get; set; }
    public List<ICollidable> Projectiles { get; private set; }
    public List<ICollidable> CollidableList { get; private set; }
    
    public List<ICollidable> CollidablesToAdd { get; set; }
    public List<ICollidable> CollidablesToDelete { get; set; }

    private int startingLevelIndex = 0;

    private int currentLevelIndex;
    private int currentEnemyIndex;
    private int currentTileIndex;
    private int currentItemIndex;

    private int WindowWidth;
    private int WindowHeight;

    public GameConfig GameConfig { get; private set; }
    private string gameFilePath = "./Content/Data/GameFile.xml";

    public IPlayer Player;
    public Room Room;
    public HUD MainHUD;
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

    public void NextEnemy()
    {
        CollisionManager.collidables.Remove(EnemyList[currentEnemyIndex]);
        currentEnemyIndex++;

        int remainder = (currentEnemyIndex % EnemyList.Count);
        currentEnemyIndex = (remainder < 0) ? (EnemyList.Count + remainder) : remainder;
        CollisionManager.collidables.Add(EnemyList[currentEnemyIndex]);
    }

    public void PreviousEnemy()
    {
        CollisionManager.collidables.Remove(EnemyList[currentEnemyIndex]);
        currentEnemyIndex--;

        int remainder = (currentEnemyIndex % EnemyList.Count);
        currentEnemyIndex = (remainder < 0) ? (EnemyList.Count + remainder) : remainder;
        CollisionManager.collidables.Add(EnemyList[currentEnemyIndex]);
    }

    public void PreviousItem()
    {
        currentItemIndex--;

        int remainder = (currentItemIndex % ItemList.Count);
        currentItemIndex = (remainder < 0) ? (ItemList.Count + remainder) : remainder;
    }

    public void NextItem()
    {
        currentItemIndex++;

        int remainder = (currentItemIndex % ItemList.Count);
        currentItemIndex = (remainder < 0) ? (ItemList.Count + remainder) : remainder;
    }
    public void PreviousLevel()
    {
        currentLevelIndex--;

        int remainder = (currentLevelIndex % LevelList.Count);
        currentLevelIndex = (remainder < 0) ? (LevelList.Count + remainder) : remainder;

        Room = new Room(this, LevelList[currentLevelIndex]);
    }

    public void NextLevel()
    {
        currentLevelIndex++;

        int remainder = (currentLevelIndex % LevelList.Count);
        currentLevelIndex = (remainder < 0) ? (LevelList.Count + remainder) : remainder;

        Room = new Room(this, LevelList[currentLevelIndex]);
    }

    public void PreviousTile()
    {
        CollisionManager.collidables.Remove(TileList[currentTileIndex]);
        currentTileIndex--;

        int remainder = (currentTileIndex % TileList.Count);
        currentTileIndex = (remainder < 0) ? (TileList.Count + remainder) : remainder;

        if (TileList[currentTileIndex].type != ICollidable.objectType.Tile)
        {
            CollisionManager.collidables.Add(TileList[currentTileIndex]);
        }

    }

    public void ResetLevel()
    {
        currentLevelIndex = startingLevelIndex;
        Room = new Room(this, LevelList[currentLevelIndex]);

        // reset enemy health, dynamic parts of the map, etc. once implemented. May also be done in room class though
        
    }

    public void NextTile()
    {
        CollidableList.Remove(TileList[currentTileIndex]);
        currentTileIndex++;

        int remainder = (currentTileIndex % TileList.Count);
        currentTileIndex = (remainder < 0) ? (TileList.Count + remainder) : remainder;

        if (TileList[currentTileIndex].type != ICollidable.objectType.Tile)
        {
            CollisionManager.collidables.Add(TileList[currentTileIndex]);
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

        TextureStorage.LoadAllTextures(Content);
        SpriteFont font = Content.Load<SpriteFont>("Arial");

        Controllers = new List<IController>();

        IController mouse = new MouseController();
        // May add binding for mouse clicks later

        IController keyboard = new KeyboardController();
        
        keyboard.BindCommand(Keys.Q, new QuitCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.R, new ResetGameCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.W, new MoveUpCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.S, new MoveDownCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.D, new MoveRightCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.A, new MoveLeftCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.Up, new MoveUpCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.Down, new MoveDownCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.Right, new MoveRightCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.Left, new MoveLeftCommand(), IController.KeyState.KeyDown);
        keyboard.BindCommand(Keys.Z, new PlayerSwordAttackCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.N, new PlayerSwordAttackCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.T, new NextTileCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.Y, new PreviousTileCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.I, new NextItemCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.U, new PreviousItemCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.O, new PreviousEnemyCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.P, new NextEnemyCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.K, new PreviousLevelCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.L, new NextLevelCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.E, new PlayerTakeDamageCommand(), IController.KeyState.Pressed);
        
        // For testing purposes only
        keyboard.BindCommand(Keys.G, new SpawnItemPickupCommand(), IController.KeyState.Pressed);

        keyboard.BindCommand(Keys.M, new MuteCommand(), IController.KeyState.Pressed);

        keyboard.BindCommand(Keys.D1, new UseBombCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D2, new UseWoodenBoomerangCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D3, new UseMagicalBoomerangCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D4, new UseWoodenArrowCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D5, new UseSilverArrowCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D6, new UseFireballCommand(), IController.KeyState.Pressed);
        
        Controllers.Add(keyboard);
        Controllers.Add(mouse);

        IController gamePad = new GamePadController();
	
	    gamePad.BindCommand(Buttons.Back, new QuitCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.Start, new ResetGameCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.LeftThumbstickUp, new MoveUpCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.LeftThumbstickDown, new MoveDownCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.LeftThumbstickRight, new MoveRightCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.LeftThumbstickLeft, new MoveLeftCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadUp, new MoveUpCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadDown, new MoveDownCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadRight, new MoveRightCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadLeft, new MoveLeftCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.A, new PlayerSwordAttackCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.RightShoulder, new PlayerSwordAttackCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.X, new NextTileCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.Y, new PreviousTileCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.RightTrigger, new NextItemCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.LeftTrigger, new PreviousItemCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.RightThumbstickLeft, new PreviousEnemyCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.RightThumbstickRight, new NextEnemyCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.RightStick, new PlayerTakeDamageCommand(), IController.KeyState.Pressed);

        TileList = new List<ICollidable>();
        TileList.Add(new TileType1(1000, 360));
        TileList.Add(new TileType2(1000, 360));
        TileList.Add(new TileType3(1000, 360));
        TileList.Add(new TileType4(1000, 360));
        TileList.Add(new TileType5(1000, 360));
        TileList.Add(new TileType6(1000, 360));
        TileList.Add(new TileType7(1000, 360));
        TileList.Add(new TileType8(1000, 360));
        TileList.Add(new TileType9(1000, 360));
        TileList.Add(new TileType10(1000, 360));

        ItemList = new List<IItem>();
        ItemList.Add(new Arrow());
        ItemList.Add(new Bomb());
        ItemList.Add(new Boomerang());
        ItemList.Add(new Bow());
        ItemList.Add(new Clock());
        ItemList.Add(new Compass());
        ItemList.Add(new Fairy());
        ItemList.Add(new Heart());
        ItemList.Add(new HeartContainer());
        ItemList.Add(new Key());
        ItemList.Add(new Map());
        ItemList.Add(new Rupee());
        ItemList.Add(new Triforce());

        Vector2 enemySpawn = new Vector2(200, WindowHeight / 2 + 100);

        EnemyList = new List<ICollidable>();
        ICollidable stalfos = new StalfosEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(stalfos);
        ICollidable keese = new KeeseEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(keese);
        ICollidable goriya = new GoriyaEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(goriya);
        ICollidable zol = new ZolEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(zol);
        ICollidable oldMan = new OldManNPC(Vector2.One * 200);
        EnemyList.Add(oldMan);
        ICollidable aquamentus = new AquamentusBoss(enemySpawn, enemySpeed);
        EnemyList.Add(aquamentus);

        Player = new Player(this);

        Projectiles = new List<ICollidable>();

        CollidableList = new List<ICollidable>();
        //CollidableList.Add(keese);
        CollidableList.Add(Player);
        
        CollidablesToDelete = new List<ICollidable>();
        CollidablesToAdd = new List<ICollidable>();


        GameConfig = new GameConfig();

        GameFileReader gameFileReader = new GameFileReader(GameConfig);
        gameFileReader.LoadFile(gameFilePath);
        GameConfig = gameFileReader.GameConfig;

        _graphics.PreferredBackBufferWidth = GameConfig.ResolutionWidth;
        _graphics.PreferredBackBufferHeight = GameConfig.ResolutionHeight;
        _graphics.ApplyChanges();

        LevelList = new List<LevelConfig>();
        LevelList = GameConfig.LevelConfigs.Values.ToList<LevelConfig>();

        CollisionManager = new CollisionManager(CollidableList);

        Room = new Room(this, GameConfig.LevelConfigs[GameConfig.StartLevelId]);
        Room.Initialize();

        MainHUD = new HUD(this, new PlayerInventory(), 3, font);


        SoundManager.Manager.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));

        CollisionManager.Update(gameTime, this);

        MainHUD.Update(new PlayerInventory(), 3);

        if (CollidablesToDelete != null) {
            CollisionManager.collidables = CollisionManager.collidables.Except(CollidablesToDelete).ToList();
            CollidablesToDelete.Clear();
        }

        if (CollidablesToAdd != null) {
            CollisionManager.collidables.AddRange(CollidablesToAdd);
            CollidablesToAdd.Clear();
        }

        //EnemyList[currentEnemyIndex].Update(gameTime, this);
        //Player.Update(gameTime, this);
        foreach (ICollidable projectile in Projectiles)
        {
            projectile.Update(gameTime, this);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.Black);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        MainHUD.Draw(_spriteBatch);

        Room.Draw(_spriteBatch);

        //TileList[currentTileIndex].Draw(_spriteBatch);
        //Player.Draw(_spriteBatch);
        CollisionManager.Draw(_spriteBatch);
        //EnemyList[currentEnemyIndex].Draw(_spriteBatch);
        //ItemList[currentItemIndex].Draw(_spriteBatch);

        foreach (ICollidable projectile in Projectiles)
        {
            projectile.Draw(_spriteBatch);  
        }

        base.Draw(gameTime);

        _spriteBatch.End();
    }
    public void reset()
    {

        currentEnemyIndex = 0;
        currentTileIndex = 0;
        currentItemIndex = 0;
        currentLevelIndex = 0;

        foreach (ICollidable enemy in EnemyList)
        {
            enemy.Reset(this);
        }

        Player.Reset(this);

    }
}
