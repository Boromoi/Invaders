using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class GreenInvader : Invader
    {
        private Invader invader = new Invader();

        public GreenInvader()
        {
            invader.assetName = "spr_green_invader";
        }
    }
}
