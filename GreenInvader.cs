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
            Position.X = Global.Random(100, Global.width - 100);
            Position.Y = Texture.Height;

            Velocity.X = 5.0f;

            HitPoints = 1;
            IsDead = false;
        }

        public override int GetScore()
        {
            return 200;
        }
    }
}
