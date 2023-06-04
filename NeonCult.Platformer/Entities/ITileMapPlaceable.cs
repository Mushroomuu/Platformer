using Microsoft.Xna.Framework.Content;
using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Entities
{
    internal interface ITileMapPlaceable : IGameEntity
    {

        void Initialize(ContentManager content, PropertyMap properties);

    }
}
