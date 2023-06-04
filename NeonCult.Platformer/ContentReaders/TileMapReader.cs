using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using NeonCult.Platformer.Core;
using NeonCult.Platformer.TileMaps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.ContentReaders
{
    public class TileMapReader : ContentTypeReader<TileMap>
    {
        protected override TileMap Read(ContentReader input, TileMap existingInstance)
        {
            if (existingInstance != null)
                return existingInstance;
            

            int tileWidth = input.ReadInt32();
            int tileHeight = input.ReadInt32();
            int width = input.ReadInt32();
            int height = input.ReadInt32();

            TileMap tileMap = new TileMap(tileWidth, tileHeight, width, height);

            int tileSetRefCount = input.ReadInt32();

            for(int i = 0; i < tileSetRefCount; i++)
            {
                tileMap.AddTileSetReference(ReadTileSetReference(input));
            }

            int tileLayerCount = input.ReadInt32();

            for(int i = 0; i < tileLayerCount; i++)
            {
                tileMap.AddLayer(ReadTileMapTileLayer(input, tileMap));
            }

            int objLayerCount = input.ReadInt32();

            for(int i = 0; i < objLayerCount; i++ )
            {
                tileMap.AddLayer(ReadObjectLayer(input, tileMap));
            }

            return tileMap;


        }

        private TileSetReference ReadTileSetReference(ContentReader input)
        {
            return new TileSetReference(input.ReadInt32(), input.ReadString());
        }

        private TileMapTileLayer ReadTileMapTileLayer(ContentReader input, TileMap tileMap)
        {
            int id = input.ReadInt32();
            string name = input.ReadString();

            TileMatrix tileMatrix = ReadTileMatrix(input);

            return new TileMapTileLayer(tileMap,id, name, tileMatrix);
        }

        private TileMatrix ReadTileMatrix(ContentReader input)
        {

            List<TileMapTile> tileCache = new List<TileMapTile>();

            int width = input.ReadInt32();
            int height = input.ReadInt32();

            List<List<TileMapTile>> tiles = new List<List<TileMapTile>>();

            for(int i = 0; i < height; i++)
            {
                List<TileMapTile> t = new List<TileMapTile>();

                for (int j = 0; j < width; j++)
                {
                    int tileId = input.ReadInt32();
                    var tile = tileCache.FirstOrDefault(t => t.Id == tileId);
                    if(tile == null)
                    {
                        tile = new TileMapTile(tileId);
                        tileCache.Add(tile);
                    }

                    t.Add(tile);
                    
                }

                tiles.Add(t);

            }
            
            return new TileMatrix(tiles);
            

        }

        public TileMapObjectLayer ReadObjectLayer(ContentReader input, TileMap tileMap)
        {
            int id = input.ReadInt32();
            string name = input.ReadString();
            TileMapObjectLayer objLayer = new TileMapObjectLayer(tileMap, id, name);

            int objCount = input.ReadInt32();
            for(int i = 0; i < objCount; i++)
            {
                int objId = input.ReadInt32();
                string objName = input.ReadString();
                string objType = input.ReadString();
                int X = input.ReadInt32();
                int Y = input.ReadInt32();

                int propCount = input.ReadInt32();
                PropertyMap propMap = new PropertyMap();
                for(int j = 0; j < propCount; j++)
                {
                    string key = input.ReadString();
                    string val = input.ReadString();
                    propMap.Add(key, val);
                }
                int objShape = input.ReadInt32();
                switch (objShape)
                {
                    case 0:
                        objLayer.AddObject(new TileMapPointObject(objId, objName, objType, X, Y, propMap));
                        continue;
                    case 1:
                        int width = input.ReadInt32();
                        int height = input.ReadInt32();
                        objLayer.AddObject(new TileMapRectangleObject(objId, objName, objType, X, Y, propMap, width, height));
                        continue;
                    case 2:
                        List<Vector2> points = new List<Vector2>();
                        int pointCount = input.ReadInt32();
                        for(int  k = 0; k < pointCount; k++)
                        {
                            int x = input.ReadInt32();
                            int y = input.ReadInt32();
                            points.Add(new Vector2(x, y));
                        }
                        bool isOpen = input.ReadBoolean();
                        objLayer.AddObject(new TileMapPolygonObject(objId, objName, objType, X, Y, propMap, points, isOpen));
                        continue;

                }

                


            }



            return objLayer;
        }


    }
}
