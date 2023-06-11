using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Collision
{
    public interface ICollisionObject
    {

        string Type { get; }
        string Name { get; set; }
        Texture2D DebugTexture { get; set; }
        void Collision(ICollisionObject collisionObject);
        void DebugDraw(SpriteBatch spriteBatch, Vector2 CameraPosition);

    }
}
