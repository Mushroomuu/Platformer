using NeonCult.Platformer.Pipeline.TileSets;
using System.Xml.Serialization;

namespace NeonCult.Platformer.Test
{
    [TestClass]
    public class TileSetTest
    {

        private const string TEST_TILESET_PATH = @"C:\Users\smets\source\repos\Platformer\NeonCult.Platformer.Test\Resources\BMBT-WorldOneTiles.tsx";

        [TestMethod]
        public void DeserializeDataSet()
        {

            string fileContent = System.IO.File.ReadAllText(TEST_TILESET_PATH);

            XmlSerializer serializer = new XmlSerializer(typeof(TileSetData));

            TileSetData tileSetData = null;

            using(FileStream stream = new FileStream(TEST_TILESET_PATH, FileMode.Open))
            {
                tileSetData = serializer.Deserialize(stream) as TileSetData;
            }

            Assert.IsNotNull(tileSetData);

        }
    }
}