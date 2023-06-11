using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeonCult.Platformer.Collision;
using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Entities.TileMaps
{
    public class LevelPlayer : IDynamicCollider, ITileMapPlaceable
    {
        public Rectangle CollisionBox => throw new NotImplementedException();

        public string Type => "LevelPlayer";

        public string Name { get; set; }
        public Texture2D DebugTexture { get; set; }

        public int DrawOrder => 0;

        public List<string> Ids { get; set; }

        public int UpdateOrder => 0;

        public Rectangle PreviousCollider => throw new NotImplementedException();

        public void Initialize(ContentManager content, PropertyMap properties)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void DebugDraw(SpriteBatch spriteBatch, Vector2 CameraPosition)
        {
            spriteBatch.Draw(DebugTexture, CollisionBox, Color.White);
        }

        public void Collision(ICollisionObject collisionObject)
        {
            throw new NotImplementedException();
        }


    }
}
