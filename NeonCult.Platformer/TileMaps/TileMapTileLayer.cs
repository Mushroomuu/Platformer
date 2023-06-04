using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMapTileLayer : TileMapLayer
    {

        public int Width => TileMatrix.Width;
        public int Height => TileMatrix.Height;

        public override TileMapLayerType LayerType => TileMapLayerType.Tile;

        public TileMatrix TileMatrix { get; private set; }

        public TileMapTileLayer(TileMap tileMap, int id, string name, TileMatrix tileMatrix) : base (tileMap,id, name)
        {
            TileMatrix = tileMatrix;
        }

        public TileMapTileLayer(TileMap tileMap,int id, string name, int width, int height) : base(tileMap,id, name)
        {

            TileMatrix = new TileMatrix(width, height);
            
        }

    }
}
