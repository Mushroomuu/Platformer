using Microsoft.Xna.Framework.Content.Pipeline;
using NeonCult.Platformer.Pipeline.TileMaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NeonCult.Platformer.Pipeline
{
    [ContentImporter(".tmx", DisplayName = "TileMap Importer", DefaultProcessor = nameof(TileMapProcessor))]
    public class TileMapImporter : ContentImporter<TileMapData>
    {
        public override TileMapData Import(string filename, ContentImporterContext context)
        {
            using(FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TileMapData));

                TileMapData data = xmlSerializer.Deserialize(fileStream) as TileMapData;

                return data;
            }
        }
    }
}
