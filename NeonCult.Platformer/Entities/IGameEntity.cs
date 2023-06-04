using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Entities
{
    public interface IGameEntity : IUpdatable
    {

        int DrawOrder { get; }

        int UpdateOrder { get; }

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    }
}
