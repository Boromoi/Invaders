using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class BlueInvader : Invader
    {
        public InvaderTypes InvaderType => InvaderTypes.Blue;

        const string AssetName = "spr_blue_invader";

        public BlueInvader():base(AssetName)
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;

            velocity.X = 3.0f;

            HitPoints = 1;
            dead = false;
        }
    }
}
