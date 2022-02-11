using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class GreenInvader : Invader
    {
        public InvaderTypes InvaderType => InvaderTypes.Green;
        const string AssetName = "spr_green_invader";
        public GreenInvader():base(AssetName)
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;

            velocity.X = 3.0f;

            HitPoints = 1;
            dead = false;
        }
    }
}
