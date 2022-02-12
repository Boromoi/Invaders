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
            Position.X = Global.Random(100, Global.width - 100);
            Position.Y = Texture.Height+200;

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
