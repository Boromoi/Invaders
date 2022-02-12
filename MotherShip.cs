using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class MotherShip:Invader
    {
        const string AssetName = "spr_enemy_ship";

        public MotherShip():base(AssetName)
        {
            Position.X = Global.Random(100, Global.width - 100);
            Position.Y = Texture.Height;
            Velocity.X = 3.0f;
            HitPoints = 2;
            IsDead = false;
        }

        public override int GetScore()
        {
            return 500;
        }
    }
}