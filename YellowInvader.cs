using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class YellowInvader : Invader
    {
        private Invader invader = new Invader();

        public YellowInvader()
        {
            invader.assetName = "spr_yellow_invader";
        }
    }
}
