using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMapRectangleObject : TileMapObject
    {

        public override TileMapObjectType ObjectType => TileMapObjectType.Rectangle;

        public int Width { get; set; }
        public int Height { get; set; }

        public TileMapRectangleObject(int id, string name, string type, int x, int y, PropertyMap propMap, int width, int height) : base(id, name, type, x, y, propMap)
        {
            Width = width;
            Height = height;
        }


    }
}
