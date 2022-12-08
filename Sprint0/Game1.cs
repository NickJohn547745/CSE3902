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
using System;
using sprint0.Configs;
using sprint0.Managers;
using sprint0.SaveLoadClasses;
using sprint0.ProceduralGeneration;

namespace sprint0;

public class Game1 : Game
{
    private const String Font = "Arial";

   
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public int DefaultRoomOffset { get; private set; }
    public static int WindowWidth { get; private set; }
    public static int WindowHeight { get; private set; }

    public CollisionManager CollisionManager { get; private set; }
    public List<IController> Controllers { get; set; }
    public List<LevelConfig> LevelList { get; set; }

    public SaveLoadManager SaveStateManager { get; set; }
    public bool Paused { get; set; }

    public IGameState state;
    
    public int currentLevelIndex;

    public GameConfig GameConfig { get; private set; }
    private string gameFilePath = "./Content/Data/GameFile.xml";

    public IPlayer Player;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public void PreviousLevel()
    {
        currentLevelIndex--;

        int remainder = (currentLevelIndex % LevelList.Count);
        currentLevelIndex = (remainder < 0) ? (LevelList.Count + remainder) : remainder;

        state.Room = new Room(this, LevelList[currentLevelIndex]);
        state.Room.Initialize();
    }

    public void NextLevel()
    {
        currentLevelIndex++;

        int remainder = (currentLevelIndex % LevelList.Count);
        currentLevelIndex = (remainder < 0) ? (LevelList.Count + remainder) : remainder;

        state.Room = new Room(this, LevelList[currentLevelIndex]);
        state.Room.Initialize();
    }

    public void ResetLevel()
    {
        currentLevelIndex = 0;
        state.Room = new Room(this, LevelList[currentLevelIndex]);     
    }

    protected override void Initialize()
    {
        Paused = false;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        TextureStorage.LoadAllTextures(Content);
        SpriteFont font = Content.Load<SpriteFont>("Arial");

        IController gamePad = new GamePadController();
	
        gamePad.BindCommand(Buttons.Back, new QuitCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.Start, new ResetGameCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.LeftThumbstickUp, new MoveUpCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.LeftThumbstickDown, new MoveDownCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.LeftThumbstickRight, new MoveRightCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.LeftThumbstickLeft, new MoveLeftCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.Y, new UseBombCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadUp, new UseWoodenBoomerangCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadDown, new UseMagicalBoomerangCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadRight, new UseWoodenArrowCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.DPadLeft, new UseSilverArrowCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.B, new UseFireballCommand(), IController.KeyState.KeyDown);
        gamePad.BindCommand(Buttons.A, new PlayerSwordAttackCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.RightShoulder, new NextLevelCommand(), IController.KeyState.Pressed);
        gamePad.BindCommand(Buttons.LeftShoulder, new PreviousLevelCommand(), IController.KeyState.Pressed);

        GameConfig = new GameConfig();

        GameFileReader gameFileReader = new GameFileReader(GameConfig);
        gameFileReader.LoadFile(gameFilePath);
        GameConfig = gameFileReader.GameConfig;

        Controllers = new List<IController>();

        IController mouseController = new MouseController();
        foreach (Tuple<Keys, ICommand, IController.KeyState> binding in GameConfig.MouseBinds)
        {
            mouseController.BindCommand(binding.Item1, binding.Item2, binding.Item3);
        }
        Controllers.Add(mouseController);

        IController keyboardController = new KeyboardController();
        foreach (Tuple<Keys, ICommand, IController.KeyState> binding in GameConfig.KeyboardBinds)
        {
            keyboardController.BindCommand(binding.Item1, binding.Item2, binding.Item3);
        }
        Controllers.Add(keyboardController);

        IController gamePadController = new GamePadController();
        foreach (Tuple<Buttons, ICommand, IController.KeyState> binding in GameConfig.GamePadBinds)
        {
            gamePadController.BindCommand(binding.Item1, binding.Item2, binding.Item3);
        }
        Controllers.Add(gamePadController);

        Player = new Player(this);

        _graphics.PreferredBackBufferWidth = GameConfig.ResolutionWidth;
        _graphics.PreferredBackBufferHeight = GameConfig.ResolutionHeight;
        _graphics.ApplyChanges();

        LevelList = new List<LevelConfig>();
        LevelList = GameConfig.LevelConfigs.Values.ToList<LevelConfig>();

        DefaultRoomOffset = LevelList.Count;
        RoomLayoutGenerator.Instance.SetRooms(this, DefaultRoomOffset);
        LevelList.AddRange(RoomLayoutGenerator.Instance.ProceduralRooms);

        CollisionManager = new CollisionManager(Player);

        Room room = new Room(this, GameConfig.LevelConfigs[GameConfig.StartLevelId]);
        room.Initialize();

        WindowWidth = _graphics.PreferredBackBufferWidth;
        WindowHeight = _graphics.PreferredBackBufferHeight;

        state = new GameStateManager(this, new HUD(this, Player.GetInventory(), Player.GetHealth(), currentLevelIndex, font), Player, CollisionManager, room, font);

        SoundManager.Manager.LoadContent(Content);

        SaveStateManager = new SaveLoadManager(this);
        SaveStateManager.LoadGame();
    }

    protected override void Update(GameTime gameTime)
    {
        Controllers.ForEach(controller => controller.Update(this));

        state.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        state.Draw(_spriteBatch);

        base.Draw(gameTime);

        _spriteBatch.End();
    }

    public void Reset()
    {
        // breaks doors when used
        ResetLevel();
        state.Reset();
        Player.Reset();
    }

    public int GetLevelIndex()
    {
        return currentLevelIndex;
    }
}
