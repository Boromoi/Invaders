using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class Invader 
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public int hp;
        public bool dead;
        public string[] invaderType = { "spr_red_invader", "spr_blue_invader", "spr_green_invader" , "spr_yellow_invader" };
        public string assetName;

        public Invader()
        {
            texture = Global.content.Load<Texture2D>(invaderType[new Random().Next(0, invaderType.Length)]);
            Reset();
        }

        public void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);

            velocity.X = 3.0f;
            velocity.Y = 10.0f;

            hp = 1;
            dead = false;
        }

        public void Update()        
        {
            if (hp == 0)
            {
                dead = true;
            }

            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
