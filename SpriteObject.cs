using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    internal abstract  class SpriteObject
    {
        public Guid Identity = Guid.NewGuid();
        public int HitPoints;
        public Vector2 Position;
        public Texture2D Texture;

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
            if (Overlaps(theBullet.position, theBullet.texture, this.Position, this.Texture))
            {
                this.HitPoints -= theBullet.Damage;
                return true;
            }
            return false;
        }

        public abstract void Update();
    }
}
