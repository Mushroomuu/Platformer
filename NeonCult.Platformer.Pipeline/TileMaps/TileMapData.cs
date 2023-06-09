﻿using NeonCult.Platformer.Pipeline.TileSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NeonCult.Platformer.Pipeline.TileMaps
{
    [XmlRoot(ElementName = "map")]
    public class TileMapData
    {
        [XmlAttribute(AttributeName = "width")]
        public int Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public int Height { get; set; }
        [XmlAttribute(AttributeName = "tilewidth")]
        public int TileWidth { get; set; }
        [XmlAttribute(AttributeName = "tileheight")]
        public int TileHeight { get; set; }
        [XmlElement(ElementName = "tileset")]
        public List<TileMapTileSetData> TileSets { get; set; }
        [XmlElement(ElementName = "layer")]
        public List<TileMapLayerData> Layers { get; set; }
        [XmlElement(ElementName = "objectgroup")]
        public List<TileMapObjectGroupData> ObjectGroups { get; set; }
    }
}
