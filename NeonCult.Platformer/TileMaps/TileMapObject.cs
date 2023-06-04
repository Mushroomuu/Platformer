using Microsoft.Xna.Framework;
using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{

    public abstract class TileMapObject
    {


        public abstract TileMapObjectType ObjectType { get; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public PropertyMap CustomProperties { get; private set; }

        public TileMapObject(int id, string name, string type, int x, int y, PropertyMap propMap)
        {
            Id = id;
            Name = name;
            Type = type;
            X = x;
            Y = y;

            CustomProperties = propMap;

        }



    }
}
