using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using NeonCult.Platformer.Pipeline.TileSets;
using NeonCult.Platformer.TileMaps;
using System.IO;

namespace NeonCult.Platformer.Pipeline;

[ContentProcessor(DisplayName = "TileSet Processor")]
class TileSetProcessor : ContentProcessor<TileSetData, TileSet>
{
    private const string TEXTURE_ROOT_PATH = "Textures/TileSetTextures/";
    public override TileSet Process(TileSetData input, ContentProcessorContext context)
    {

        string tileSetPath = Path.Combine(TEXTURE_ROOT_PATH,Path.GetFileNameWithoutExtension(input.Image.Source));
        TileSet tileSet = new TileSet(input.Name, input.TileWidth, input.TileHeight, input.TileCount, tileSetPath, input.Columns); ;

        return tileSet;
    }

}