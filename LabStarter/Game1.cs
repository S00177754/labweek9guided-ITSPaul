﻿using Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Engines;

namespace LabStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Chase : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        string Message = "ppowell Paul Powell";
        SpriteFont messageFont;
        ChaseEngine chaseEngine;

        public ActiveScreenState current { get; private set; }

        public Chase()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            current = ActiveScreenState.PLAY;
            chaseEngine = new ChaseEngine(this);
            base.Initialize();
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Helper.graphicsDevice = GraphicsDevice;
            // Also Load and Add font reference to a spritefont in the helper static class

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(spriteBatch);
            messageFont = Content.Load<SpriteFont>("Message");
            
            // Load all the assets and create your objects here


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (current)
            {
                case ActiveScreenState.OPENING:
                    break;
                case ActiveScreenState.PLAY:
                    chaseEngine.Update(gameTime);
                    break;
                case ActiveScreenState.ENDING:
                    break;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            switch (current)
            {
                case ActiveScreenState.OPENING:
                    break;
                case ActiveScreenState.PLAY:
                    draw_play_screen(spriteBatch);
                    break;
                case ActiveScreenState.ENDING:
                    break;
            }

            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }

        private void draw_play_screen(SpriteBatch spriteBatch)
        {
            chaseEngine.Draw(); 
            spriteBatch.DrawString(messageFont, 
                Message, new Vector2(20, 20), Color.White);
            
        }
    }
}
