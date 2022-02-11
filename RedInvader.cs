using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class RedInvader : Invader
    {
        private Invader invader = new Invader();

        public RedInvader()
        {
            invader.assetName = "spr_red_invader";
        }
    }
}
