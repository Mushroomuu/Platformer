using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileMapObjectLayer : TileMapLayer
    {

        private readonly List<TileMapObject> _objects = new List<TileMapObject>();

        public List<TileMapObject> Objects => _objects;

        public override TileMapLayerType LayerType => TileMapLayerType.Object;

        public TileMapObjectLayer(TileMap tileMap,int id, string name) : base (tileMap, id, name) 
        {
            
        }

        public void AddObject(TileMapObject obj)
        {
            if(obj is null)
                throw new ArgumentNullException(nameof(obj));

            _objects.Add(obj);
        }

        public void RemoveObject(TileMapObject obj)
        {

            if (!HasObject(obj))
                return;

            _objects.Remove(obj);
        }

        public bool HasObject(TileMapObject obj) => _objects.Contains(obj);



    }
}
