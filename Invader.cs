using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    abstract class Invader : Ship
    {
        public Vector2 velocity;
        public bool dead;

        public Invader(string assetName)
        {
            texture = Global.content.Load<Texture2D>(assetName);
        }

        public static Invader Create(InvaderTypes invaderType)
        {
            Invader createdInvader = null;
            switch(invaderType)
            {
                case InvaderTypes.Blue: 
                    createdInvader = new BlueInvader();
                    break;
                case InvaderTypes.Red: 
                    createdInvader = new RedInvader();
                    break;
                case InvaderTypes.Yellow: 
                    createdInvader = new YellowInvader();
                    break;
                case InvaderTypes.Green: 
                    createdInvader = new GreenInvader();
                    break;
                case InvaderTypes.Mothership: 
                    createdInvader = new MotherShip();
                    break;
            }
            return createdInvader;
        }

        public void Update()        
        {
            if (HitPoints == 0)
            {
                dead = true;
            }

            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
