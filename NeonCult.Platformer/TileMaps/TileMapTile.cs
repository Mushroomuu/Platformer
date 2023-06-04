using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMapTile
    {

        public int Id { get; private set; }

        public bool IsEmpty => Id <= 0;

        private TileMapTile()
        {
            
        }

        public TileMapTile(int id)
        {
            Id = id;
        }
    }
}
