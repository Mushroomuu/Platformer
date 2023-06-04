using Microsoft.Xna.Framework.Content.Pipeline;
using NeonCult.Platformer.Pipeline.TileSets;
using System.IO;
using System.Xml.Serialization;

namespace NeonCult.Platformer.Pipeline;

[ContentImporter(".tsx", DisplayName = "Tileset Importer", DefaultProcessor = nameof(TileSetProcessor))]
public class TileSetImporter : ContentImporter<TileSetData>
{
    public override TileSetData Import(string filename, ContentImporterContext context)
    {
        using (FileStream fileStream = new FileStream(filename, FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TileSetData));

            return xmlSerializer.Deserialize(fileStream) as TileSetData;
        }


    }
}
