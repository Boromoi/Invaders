using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class BlueInvader : Invader
    {
        const string AssetName = "spr_blue_invader";

        public BlueInvader():base(AssetName)
        {
            Position.X = Global.Random(100, Global.width - 100);
            Position.Y = Texture.Height + 150;

            Velocity.X = 3.0f;

            HitPoints = 1;
            IsDead = false;
        }

        public override int GetScore()
        {
            return 150;
        }
    }
}
