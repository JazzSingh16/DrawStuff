using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DrawStuff
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        Texture2D square;
        SpriteBatch spriteBatch;
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            square = Content.Load<Texture2D>(@"square");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        public void DrawCheckerboard()
        {
            for (int x = 0; x < this.Window.ClientBounds.Width / 15; x++)
            {
                for (int y = 0; y < this.Window.ClientBounds.Height / 15; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        //spriteBatch.Draw(square, new Vector2(x * 15 + rand.Next(-1,1), y * 15), Color.Red);
                        Rectangle rect = new Rectangle(x * 15 + (int)(Math.Sin((double)x) * 2), y * 15, 15, 15);
                        spriteBatch.Draw(square, rect, Color.Cyan);
                    }
                    else
                    {
                        spriteBatch.Draw(square, new Vector2(x * 15, y * 15), Color.Black);
                    }
                }
            }
        }
        public void DrawClearScreen()
        {
            for (int x = 0; x <= this.Window.ClientBounds.Width / 15; x++)
            {
                for (int y = 0; y <= this.Window.ClientBounds.Height / 15; y++)
                {
                    spriteBatch.Draw(square, new Vector2(x * 15, y * 15), Color.BurlyWood);
                }
            }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            DrawClearScreen();
            spriteBatch.End();

            spriteBatch.Begin();
            DrawCheckerboard();
            spriteBatch.End();
            // DrawRainbow();
            // DrawCrazySquares();

            base.Draw(gameTime);
        }
    }
}