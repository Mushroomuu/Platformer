using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMapPointObject : TileMapObject
    {
        public override TileMapObjectType ObjectType => TileMapObjectType.Point;

        public TileMapPointObject(int id, string name, string type, int x, int y, PropertyMap propMap) : base(id, name, type, x, y, propMap)
        {
        }

    }
}
