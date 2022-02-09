using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class Shield
    {
        public Vector2 position;
        public Texture2D texture;
        public int hp;
        public bool dead;

        public Shield()
        {
            texture = Global.content.Load<Texture2D>("spr_shield");
            Reset();
        }

        public void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(250, Global.height - 100);

            hp = 1;
            dead = false;
        }

        public void Update()
        {
            if (hp == 0)
            {
                dead = true;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
