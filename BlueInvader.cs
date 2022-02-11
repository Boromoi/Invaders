using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class BlueInvader : Invader
    {
        private Invader invader = new Invader();

        public BlueInvader()
        {
            invader.assetName = "spr_blue_invader";
        }
    }
}
