using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    abstract class Invader : SpriteObject
    {
        public Vector2 Velocity;
        public bool IsDead;
        public abstract int GetScore();

        public Invader(string assetName)
        {
            Texture = Global.content.Load<Texture2D>(assetName);
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

        public override void Update()        
        {
            if (HitPoints == 0)
            {
                IsDead = true;
            }

            Position.X += Velocity.X;

            if ((Position.X > Global.width - Texture.Width) || (Position.X < 0))
            {
                Position.X -= Velocity.X;
                Velocity.X = -Velocity.X;
                Position.Y += Velocity.Y;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
