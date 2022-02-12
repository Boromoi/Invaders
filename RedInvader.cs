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
            Position.X = Global.Random(100, Global.width - 100);
            Position.Y = Texture.Height + 100;

            Velocity.X = 3.0f;

            HitPoints = 1;
            IsDead = false;
        }

        public override int GetScore()
        {
            return 200;
        }
    }
}
