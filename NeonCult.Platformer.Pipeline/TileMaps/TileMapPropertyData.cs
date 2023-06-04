using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NeonCult.Platformer.Pipeline.TileMaps
{
    [XmlRoot(ElementName = "property")]
    public class TileMapPropertyData
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

    }
}
