using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class YellowInvader : Invader
    {
        const string AssetName = "spr_yellow_invader";
        public YellowInvader():base(AssetName)
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;

            velocity.X = 3.0f;

            HitPoints = 1;
            dead = false;
        }
    }
}
