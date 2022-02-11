using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class Bullet
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public bool IsActive;

        public int Damage => 1;

        //public float speed;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("spr_bullet");
            Reset();
        }

        public void Reset()
        {
            IsActive = false;
            position.X = -1000f;
            velocity.Y = 0;
        }

        public void Update()
        {
            if (IsActive)
            {
                if (position.Y < 0)
                {
                    Reset();
                }
            }
            position.Y += velocity.Y;
        }

        public void Draw()
        {
            if (IsActive)
            {
                Global.spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public void Fire(Vector2 startPosition)
        {
            if (!IsActive)
            {
                IsActive = true;
                position = startPosition;
                velocity.Y = -3.0f;
            }
        }
    }
}
