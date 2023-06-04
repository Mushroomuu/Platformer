using Microsoft.Xna.Framework;
using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMapPolygonObject : TileMapObject
    {

        public override TileMapObjectType ObjectType => TileMapObjectType.Polygon;

        public Polygon Polygon { get; set; }

        public TileMapPolygonObject(int id, string name, string type, int x, int y,PropertyMap propMap, List<Vector2> points, bool isOpen) : base(id, name, type, x, y, propMap)
        {
            Polygon = new Polygon(points, isOpen);
        }
    }
}
