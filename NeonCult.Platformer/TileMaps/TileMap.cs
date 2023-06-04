using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMap
    {

        private List<TileMapLayer> _layers = new List<TileMapLayer>();
        private List<TileSetReference> _tileSetReferneces = new List<TileSetReference>();
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Vector2 Position { get; set; }

        public int LayerCount => _layers.Count;
        public int TileSetRefCount => _tileSetReferneces.Count;

        public IEnumerable<TileSetReference> TileSetReferences => new ReadOnlyCollection<TileSetReference>(_tileSetReferneces);
        public IEnumerable<TileMapLayer> Layers => new ReadOnlyCollection<TileMapLayer>(_layers);
        private TileMap()
        {
            
        }

        public TileMap(int tileWidth, int tileHeight, int width, int height)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Width = width;
            Height = height;
        }

        public void AddTileSet(int firstGid, TileSet tileSet)
        {
            _tileSetReferneces.Add(new TileSetReference(firstGid, tileSet));

        }

        public void AddTileSetReference(int firstGid, string tileSetPath)
        {
            _tileSetReferneces.Add(new TileSetReference(firstGid, tileSetPath));
        }

        public void AddTileSetReference(TileSetReference tileSetReference) => _tileSetReferneces.Add(tileSetReference);

        public void LoadTileSets(ContentManager content)
        {
            foreach (var tileSetRef in _tileSetReferneces)
                tileSetRef.LoadTileSet(content);
        }

        public void AddLayer(TileMapLayer layer)
        {
            if (layer is null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            _layers.Add(layer);
        }

        public void AddLayer(TileMapLayerType layerType, int id, string name)
        {
            if(layerType == TileMapLayerType.Tile)
            {
                TileMapTileLayer tileLayer = new TileMapTileLayer(this ,id, name, Width, Height);
                _layers.Add(tileLayer);
            }
            else if(layerType == TileMapLayerType.Object)
            {

            }
            else
            {
                throw new ArgumentException("Unkown tile layer type");
            }
        }

        public TileSetReference GetTileSetByGlobalTileId(int gid)
        {
            return _tileSetReferneces.LastOrDefault(tr => tr.FirstGid <= gid);
        }


    }

}
