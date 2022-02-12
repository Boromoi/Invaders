
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
        int totalScore = 0;
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
            
            AddInvaders();
            AddShields();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("spr_background");
            scanlines = Content.Load<Texture2D>("spr_scanlines");
            base.Initialize();
        }

        private void AddInvaders()
        {
            motherShip = new MotherShip();
            invaders.Add(motherShip);

            for (int i = 0; i < 10; i++)
            {
                AddRandomInvader();
            }
        }

        private void AddRandomInvader()
        {
            var invaderTypeNumber = new Random().Next(1, 4);
            var invader = Invader.Create((InvaderTypes)invaderTypeNumber);
            invaders.Add(invader);
        }

        private void AddShields()
        {
            shields.Add(new Shield(80, 400));
            shields.Add(new Shield(280, 400));
            shields.Add(new Shield(480, 400));
            shields.Add(new Shield(680, 400));
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

            invaders.ForEach(i => CheckSpriteObjectAndBullet(i));
            shields.ForEach(s => CheckSpriteObjectAndBullet(s));

            base.Update(gameTime);
        }

        private void CheckSpriteObjectAndBullet(SpriteObject sprite)
        {
            sprite.Update();
            //if the bullet hit the sprite deactivate the bullet
            if (theBullet.IsActive && sprite.IsHit(theBullet))
            {
                //The target was hit
                //deactivate the bullet and update the total score
                theBullet.IsActive = false;
                if(sprite is Invader)
                {
                    totalScore += ((Invader)sprite).GetScore();
                }
            }
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

            //Remove all dead invaders.
            invaders.RemoveAll(i => i.IsDead);
            //Draw all invaders
            invaders.ForEach(i => i.Draw());

            //Remove all dead shields
            shields.RemoveAll(s => s.IsDead);
            //Draw all shields
            shields.ForEach(s => s.Draw());

            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
