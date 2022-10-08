﻿using System;
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
using sprint0.Factories;
using sprint0.Interfaces;
using sprint0.ItemClasses;
using sprint0.PlayerClasses;
using sprint0.TileClasses;
using sprint0.Projectiles;

namespace sprint0;

public class Game1 : Game {

    private const float enemySpeed = 75;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public List<IController> Controllers { get; set; }
    public List<IEnemy> EnemyList { get; private set; }
    public List<ITile> TileList { get; private set; }
    public List<IItem> ItemList { get; private set; }
    public List<IProjectile> Projectiles { get; private set; }

    private int currentEnemyIndex = 0;
    private int currentTileIndex = 0;
    private int currentItemIndex = 0;

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
        currentEnemyIndex++;

        int remainder = (currentEnemyIndex % EnemyList.Count);
        currentEnemyIndex = (remainder < 0) ? (EnemyList.Count + remainder) : remainder;
    }

    public void PreviousEnemy()
    {
        currentEnemyIndex--;

        int remainder = (currentEnemyIndex % EnemyList.Count);
        currentEnemyIndex = (remainder < 0) ? (EnemyList.Count + remainder) : remainder;
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

    public void PreviousTile()
    {
        currentTileIndex--;

        int remainder = (currentTileIndex % TileList.Count);
        currentTileIndex = (remainder < 0) ? (TileList.Count + remainder) : remainder;
    }

    public void NextTile()
    {
        currentTileIndex++;

        int remainder = (currentTileIndex % TileList.Count);
        currentTileIndex = (remainder < 0) ? (TileList.Count + remainder) : remainder;
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

        TextureStorage.LoadAllTextures(Content);

        Controllers = new List<IController>();
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
        keyboard.BindCommand(Keys.E, new PlayerTakeDamageCommand(), IController.KeyState.Pressed);

        keyboard.BindCommand(Keys.D1, new UseBombCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D2, new UseWoodenBoomerangCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D3, new UseMagicalBoomerangCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D4, new UseWoodenArrowCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D5, new UseSilverArrowCommand(), IController.KeyState.Pressed);
        keyboard.BindCommand(Keys.D6, new UseFireballCommand(), IController.KeyState.Pressed);
        
        Controllers.Add(keyboard);
        Controllers.Add(new MouseController());

        TileList = new List<ITile>();
        TileList.Add(new TileType1());
        TileList.Add(new TileType2());
        TileList.Add(new TileType3());
        TileList.Add(new TileType4());
        TileList.Add(new TileType5());
        TileList.Add(new TileType6());
        TileList.Add(new TileType7());
        TileList.Add(new TileType8());
        TileList.Add(new TileType9());
        TileList.Add(new TileType10());

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

        Vector2 enemySpawn = new Vector2(WindowWidth * 3 / 4, WindowHeight * 3 / 4);

        EnemyList = new List<IEnemy>();
        IEnemy stalfos = new StalfosEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(stalfos);
        IEnemy keese = new KeeseEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(keese);
        IEnemy goriya = new GoriyaEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(goriya);
        IEnemy zol = new ZolEnemy(enemySpawn, enemySpeed);
        EnemyList.Add(zol);
        IEnemy oldMan = new OldManNPC(enemySpawn);
        EnemyList.Add(oldMan);
        IEnemy aquamentus = new AquamentusBoss(enemySpawn, enemySpeed);
        EnemyList.Add(aquamentus);

        Player = new Player();

        Projectiles = new List<IProjectile>();
    }

    protected override void Update(GameTime gameTime) {
        Controllers.ForEach(controller => controller.Update(this));

        EnemyList[currentEnemyIndex].Update(gameTime, this);

        foreach (IProjectile projectile in Projectiles)
        {
            projectile.Update(gameTime, this);
        }

        EnemyList[Math.Abs(currentEnemyIndex % EnemyList.Count)].Update(gameTime, this);
        Player.Update();
        foreach (IProjectile projectile in Projectiles)
        {
            projectile.Update(gameTime, this);
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Player.Draw(_spriteBatch);

        EnemyList[currentEnemyIndex].Draw(_spriteBatch);
        TileList[currentTileIndex].Draw(_spriteBatch);
        ItemList[currentItemIndex].Draw(_spriteBatch);

        //Credits.Draw(_spriteBatch, new Vector2(140, 360));

        foreach (IProjectile projectile in Projectiles)
        {
            if (EnemyList[Math.Abs(currentEnemyIndex % EnemyList.Count)].GetType() == typeof(GoriyaEnemy) || projectile.GetType() != typeof(GoriyaProjectile))
            {
                projectile.Draw(_spriteBatch);
            }    
        }

        base.Draw(gameTime);

        _spriteBatch.End();
    }
    public void reset()
    {

        currentEnemyIndex = 0;
        currentTileIndex = 0;
        currentItemIndex = 0;

        Player.Reset();

        foreach (IEnemy enemy in EnemyList)
        {
            enemy.Reset();
        }
    }
}
