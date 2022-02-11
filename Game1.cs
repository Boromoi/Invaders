
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        Player thePlayer;
        Bullet theBullet;
        MotherShip motherShip;
        List<Shield> shields = new List<Shield>();
        
        List<Invader> invaders = new List<Invader>();

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

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
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();
            motherShip = new MotherShip();
            
            invaders.Add(motherShip);
            for (int i = 0; i < 10; i++)
            {
                AddRandomInvader();
            }

            for (int i = 0; i < 4; i++)
            {
                AddShield();
            }

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("spr_background");
            scanlines = Content.Load<Texture2D>("spr_scanlines");
            base.Initialize();
        }

        private void AddRandomInvader()
        {
            var invaderTypeNumber = new Random().Next(1, 4);
            var invader = Invader.Create((InvaderTypes)invaderTypeNumber);
            invaders.Add(invader);
        }

        private void AddShield()
        {
            var currentShield = new Shield();
            shields.Add(currentShield);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space)) theBullet.Fire(thePlayer.position);
            // Update the game objects
            thePlayer.Update();
            theBullet.Update();

            foreach (var invader in invaders)
            {
                invader.Update();
                if (!invader.dead && theBullet.IsActive)
                {
                    if(invader.IsHit(theBullet))
                    {
                        theBullet.IsActive = false;
                    }    
                }
            }

            //foreach (var shield in shields)
            //{
            //    shield.Update();
            //    if (!shield.dead)
            //    {
            //        if (Overlaps(theBullet.position, theBullet.texture, shield.position, shield.texture) && theBullet.IsActive && !shield.dead)
            //        {
            //            shield.hp -= 1;
            //            theBullet.IsActive = false;
            //        }

            //        foreach (var invader in invaders)
            //        {
            //            if (!invader.dead)
            //            {
            //                if (Overlaps(invader.position, invader.texture, shield.position, shield.texture) && !shield.dead)
            //                {
            //                    shield.hp -= 1;
            //                    invader.hp -= 1;
            //                }
            //            }
            //        }
            //    }
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();

            foreach (var invader in invaders)
            {
                if (!invader.dead)
                {
                    invader.Draw();
                }
            }

            foreach (var shield in shields)
            {
                if (!shield.dead)
                {
                    shield.Draw();
                }
            }

            if (!motherShip.dead)
            {
                motherShip.Draw();
            }

            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
