using Microsoft.Xna.Framework.Content;
using NeonCult.Platformer.TileMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.ContentReaders
{
    public class TileSetReader : ContentTypeReader<TileSet>
    {
        protected override TileSet Read(ContentReader input, TileSet existingInstance)
        {
            return new TileSet(input.ReadString(), input.ReadInt32(), input.ReadInt32(), input.ReadInt32(), input.ReadString(), input.ReadInt32());
        }
    }
}
