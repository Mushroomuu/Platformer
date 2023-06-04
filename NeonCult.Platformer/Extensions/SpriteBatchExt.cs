using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NeonCult.Platformer.Extensions
{
    public static class SpriteBatchExt
    {

        public static void DrawLine(this SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 end, Color color, int thickness = 1)
        {
            float angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            float length = Vector2.Distance(start, end);

            spriteBatch.Draw(texture, start, null, color, angle, Vector2.Zero, new Vector2(length, thickness), SpriteEffects.None, 0);
        }

    }
}
