using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal abstract  class Ship
    {
        public int HitPoints;
        public Vector2 position;
        public Texture2D texture;

        private bool Overlaps(Vector2 position0, Texture2D texture0, Vector2 position1, Texture2D texture1)
        {
            int w0 = texture0.Width,
              h0 = texture0.Height,
              w1 = texture1.Width,
              h1 = texture1.Height;

            if (position0.X > position1.X + w1 || position0.X + w0 < position1.X ||
              position0.Y > position1.Y + h1 || position0.Y + h0 < position1.Y)
            {
                return false;
            }

            else
                return true;
        }

        internal bool IsHit(Bullet theBullet)
        {
            if (Overlaps(theBullet.position, theBullet.texture, this.position, this.texture))
            {
                this.HitPoints -= theBullet.Damage;
                return true;
            }
            return false;
        }
    }
}
