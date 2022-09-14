using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Collections;

namespace Sprint0
{
    public class Game1 : Game
    {
        private List<IController> controllerList;
        private List<DrawableSprite> spriteList;
        private List<DrawableText> textList;

        static string creditString = "Sprites from: http://www.mariouniverse.com.com\nProgram Made By: Nicholas Johnson\n";

        private int currentSpriteIndex = 0;

        public GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            /* Setup & initialize list of controllers */
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController());
            controllerList.Add(new MouseController());

            /* Setup & initialize list of sprites starting @ center */
            spriteList = new List<DrawableSprite>();
            textList = new List<DrawableText>();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < 5; i++)
            {
                DrawableSprite playerSprite = new DrawableSprite(this, Content.Load<Texture2D>("MarioAtlas"), 2, 2);
                spriteList.Add(playerSprite);
                playerSprite.SetGraphicsDM(graphics);
                playerSprite.EnqueueLocation(Drawable.Locations.Center);
            }

            spriteList[0].SetAnimationStatus(false);
            spriteList[0].SetMobileStatus(false);

            spriteList[1].SetAnimationStatus(true);
            spriteList[1].SetMobileStatus(false);

            spriteList[2].SetAnimationStatus(false);
            spriteList[2].SetMobileStatus(true);
            spriteList[2].EnqueueLocation(Drawable.Locations.CenterRight);
            spriteList[2].EnqueueLocation(Drawable.Locations.Center);
            spriteList[2].EnqueueLocation(Drawable.Locations.CenterLeft);

            spriteList[3].SetAnimationStatus(true);
            spriteList[3].SetMobileStatus(true);
            spriteList[3].EnqueueLocation(Drawable.Locations.CenterTop);
            spriteList[3].EnqueueLocation(Drawable.Locations.Center);
            spriteList[3].EnqueueLocation(Drawable.Locations.CenterBottom);


            SpriteFont font = Content.Load<SpriteFont>("Score");

            for (int i = 0; i < 5; i++)
            {
                textList.Add(new DrawableText(this, font, creditString));
                textList[i].SetGraphicsDM(graphics);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            IDrawable currentSprite = spriteList[currentSpriteIndex];
            currentSprite.Update(gameTime);

            IDrawable textSprite = textList[0];
            textSprite.Update(gameTime);

            foreach (IController controller in controllerList)
            {
                controller.Update();

                Dictionary<string, int> controllerContents = controller.ControllerContents;

                if (controller.IsKeyboardController)
                {
                    if (controllerContents["D0"] == 1) Exit();
                    else if (controllerContents["Esc"] == 1) Exit();
                    else if (controllerContents["D1"] == 1) currentSpriteIndex = 0;
                    else if (controllerContents["D2"] == 1) currentSpriteIndex = 1;
                    else if (controllerContents["D3"] == 1) currentSpriteIndex = 2;
                    else if (controllerContents["D4"] == 1) currentSpriteIndex = 3;
                }
                else
                { // Current controller is of type 'MouseController'
                    if (controllerContents["RightMB"] == 1) Exit();
                    if (controllerContents["LeftMB"] == 1)
                    { // Left mouse button is clicked

                        //Get the coordinates of the cursor
                        int xPos = controllerContents["PosX"],
                            yPos = controllerContents["PosY"];

                        if (xPos >= (graphics.PreferredBackBufferWidth / 2))
                        { // Mouse is on the Right-Half of the window
                            if (yPos >= (graphics.PreferredBackBufferHeight / 2)) 
                                currentSpriteIndex = 3; // Mouse is in the Bottom-Right quadrant
                            else 
                                currentSpriteIndex = 1; // Mouse is in the Top-Right quadrant
                        } else
                        { // Mouse is on the Left-Half of the window
                            if (yPos >= (graphics.PreferredBackBufferHeight / 2)) 
                                currentSpriteIndex = 2; // Mouse is in the Bottom-Left quadrant
                            else 
                                currentSpriteIndex = 0; // Mouse is in the Top-Left quadrant
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawableSprite currentSprite = spriteList[currentSpriteIndex];
            currentSprite.Draw();

            DrawableText textSprite = textList[0];
            textSprite.Draw();

            base.Draw(gameTime);
        }

        public GraphicsDeviceManager GetGraphicsDM()
        {
            return graphics;
        }

        public SpriteBatch GetSpriteBatch()
        {
            return spriteBatch;
        }
    }
}