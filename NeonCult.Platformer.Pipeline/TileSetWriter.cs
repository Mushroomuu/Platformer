using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using NeonCult.Platformer.ContentReaders;
using NeonCult.Platformer.TileMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Pipeline
{
    [ContentTypeWriter]
    public class TileSetWriter : ContentTypeWriter<TileSet>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(TileSetReader).AssemblyQualifiedName;
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(TileSet).AssemblyQualifiedName;
        }

        protected override void Write(ContentWriter output, TileSet value)
        {
            output.Write(value.Name);
            output.Write(value.TileWidth);
            output.Write(value.TileHeight);
            output.Write(value.TileCount);
            output.Write(value.TexturePath);
            output.Write(value.ColumnCount);
        }
    }
}
