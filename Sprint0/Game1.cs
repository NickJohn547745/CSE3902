using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Classes;
using sprint0.Commands;
using sprint0.Controllers;
using sprint0.Interfaces;
using sprint0.PlayerClasses;
using sprint0.RoomClasses;
using sprint0.FileReaderClasses;
using sprint0.GameStateClasses;
using sprint0.Sound;
using sprint0.HudClasses;

namespace sprint0;

public class Game1 : Game {
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public CollisionManager CollisionManager { get; private set; }
    public List<IController> Controllers { get; set; }
    public List<LevelConfig> LevelList { get; set; }
   
    public bool Paused { get; set; }

    public IGameState state;

    private int startingLevelIndex = 0;

    private int currentLevelIndex;
    
    public GameConfig GameConfig { get; private set; }
    private string gameFilePath = "./Content/Data/GameFile.xml";

    public IPlayer Player;
    

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public int GetWindowWidth()
    {
        return _graphics.PreferredBackBufferWidth;
    }

    public int GetWindowHeight()
    {
        return _graphics.PreferredBackBufferHeight;
    }
    
    public void PreviousLevel()
    {
        currentLevelIndex--;

        int remainder = (currentLevelIndex % LevelList.Count);
        currentLevelIndex = (remainder < 0) ? (LevelList.Count + remainder) : remainder;

        state.Room = new Room(this, LevelList[currentLevelIndex]);
    }

    public void NextLevel()
    {
        currentLevelIndex++;

        int remainder = (currentLevelIndex % LevelList.Count);
        currentLevelIndex = (remainder < 0) ? (LevelList.Count + remainder) : remainder;

        state.Room = new Room(this, LevelList[currentLevelIndex]);
    }

    public void ResetLevel()
    {
        currentLevelIndex = startingLevelIndex;
        state.Room = new Room(this, LevelList[currentLevelIndex]);

        // Reset enemy health, dynamic parts of the map, etc. once implemented. May also be done in room class though
        
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here
        Paused = false;
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
        keyboard.BindCommand(Keys.K, new PreviousLevelCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.L, new NextLevelCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.E, new PlayerTakeDamageCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.Escape, new TogglePauseCommand(), IController.KeyState.Pressed);
        
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
        gamePad.BindCommand(Buttons.RightStick, new PlayerTakeDamageCommand(), IController.KeyState.Pressed);

        Player = new Player(this);

        GameConfig = new GameConfig();

        GameFileReader gameFileReader = new GameFileReader(GameConfig);
        gameFileReader.LoadFile(gameFilePath);
        GameConfig = gameFileReader.GameConfig;

        _graphics.PreferredBackBufferWidth = GameConfig.ResolutionWidth;
        _graphics.PreferredBackBufferHeight = GameConfig.ResolutionHeight;
        _graphics.ApplyChanges();

        LevelList = new List<LevelConfig>();
        LevelList = GameConfig.LevelConfigs.Values.ToList<LevelConfig>();

        CollisionManager = new CollisionManager(Player);

        Room room = new Room(this, GameConfig.LevelConfigs[GameConfig.StartLevelId]);
        room.Initialize();
        
        state = new GameState(this, new HUD(this, Player.GetInventory(), Player.GetHealth(), currentLevelIndex, font), Player, CollisionManager, room, font);

        SoundManager.Manager.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));

        state.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.Black);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        state.Draw(_spriteBatch);

        base.Draw(gameTime);

        _spriteBatch.End();
    }
    
    public void Reset()
    {
        currentLevelIndex = 0;
        state.Reset();
        Player.Reset();
    }

    public int GetLevelIndex()
    {
        return currentLevelIndex;
    }
}
