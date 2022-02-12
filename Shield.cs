using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class Shield:SpriteObject
    {
        public bool IsDead;

        public Shield(int x, int y)
        {
            Texture = Global.content.Load<Texture2D>("spr_shield");
            Position.X = x;
            Position.Y = y;
            HitPoints = 1;
            IsDead = false;
        }

        public override void Update()
        {
            if (HitPoints == 0)
            {
                IsDead = true;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
