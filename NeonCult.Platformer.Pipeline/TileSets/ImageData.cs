using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NeonCult.Platformer.Pipeline.TileSets
{
    public class ImageData
    {
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public int Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public int Height { get; set; }

    }
}
