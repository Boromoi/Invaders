using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class RedInvader : Invader
    {
        const string AssetName = "spr_red_invader";
        public RedInvader():base(AssetName)
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;

            velocity.X = 3.0f;

            HitPoints = 1;
            dead = false;
        }
    }
}
