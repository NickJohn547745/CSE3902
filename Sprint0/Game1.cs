using System;
using System.Collections.Generic;
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

    public void NextEnemy()
    {
        EnemyIndex++;
    }

    public void PreviousEnemy()
    {
        EnemyIndex--;
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
        keyboard.BindCommand(Keys.D1, new UseBombCommand());
        keyboard.BindCommand(Keys.D2, new UseWoodenBoomerangCommand());
        keyboard.BindCommand(Keys.D3, new UseMagicalBoomerangCommand());
        keyboard.BindCommand(Keys.D4, new UseWoodenArrowCommand());
        keyboard.BindCommand(Keys.D5, new UseSilverArrowCommand());
        keyboard.BindCommand(Keys.D6, new UseFireballCommand());
        keyboard.BindCommand(Keys.O, new PreviousEnemyCommand());
        keyboard.BindCommand(Keys.P, new NextEnemyCommand());
        keyboard.BindCommand(Keys.E, new PlayerTakeDamageCommand());
        
        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        Enemies = new List<IEnemy>();
        EnemyIndex = 0;
        IEnemy stalfos = new Stalfos(new Vector2 (WindowWidth * 3 / 4, WindowHeight * 3 / 4), 25);
        Enemies.Add(stalfos);
        IEnemy keese = new Keese(new Vector2(WindowWidth * 3 / 4, WindowHeight * 3 / 4), 25);
        Enemies.Add(keese);

        CurrentSprite = new StationaryStaticSprite(Spritesheet);

        Player = new Player();
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));
        Enemies[Math.Abs(EnemyIndex % Enemies.Count)].Update(gameTime, this);
        Player.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        Player.Draw(_spriteBatch);
        Enemies[Math.Abs(EnemyIndex % Enemies.Count)].Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void reset()
    {

    }
}