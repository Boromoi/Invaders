using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class MotherShip:Invader
    {
        //public Vector2 position;
        //public Vector2 velocity;
        //public Texture2D texture;
        //public int hp;
        //public bool dead;

        const string AssetName = "spr_enemy_ship";

        public MotherShip():base(AssetName)
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;
            velocity.X = 3.0f;
            HitPoints = 2;
            dead = false;
        }

        //public void Update()
        //{
        //    position.X += velocity.X;

        //    if ((position.X > Global.width - texture.Width) || (position.X < 0))
        //    {
        //        position.X -= velocity.X;
        //        velocity.X = -velocity.X;
        //    }

        //    if (HitPoints == 0)
        //    {
        //        dead = true;
        //    }
        //}

        //public void Draw()
        //{
        //    Global.spriteBatch.Draw(texture, position, Color.White);
        //}
    }
}