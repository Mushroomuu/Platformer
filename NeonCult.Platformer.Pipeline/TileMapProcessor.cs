using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using NeonCult.Platformer.Core;
using NeonCult.Platformer.Pipeline.TileMaps;
using NeonCult.Platformer.TileMaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Pipeline
{
    [ContentProcessor(DisplayName = "TileMap Processor")]
    public class TileMapProcessor : ContentProcessor<TileMapData, TileMap>
    {

        public const string TILE_SET_PATH = "TileSets";

        public override TileMap Process(TileMapData input, ContentProcessorContext context)
        {

            TileMap tileMap = new TileMap(input.TileWidth, input.TileHeight, input.Width, input.Height);

            foreach(var tileSetData in input.TileSets)
            {
                string tsPath = $"{TILE_SET_PATH}/{Path.GetFileNameWithoutExtension(tileSetData.Source)}";
                tileMap.AddTileSetReference(tileSetData.FirstGid, tsPath);
            }

            foreach(var layer in input.Layers)
            {
                TileMatrix tileMatrix = TileMatrix.ParseCsv(layer.Data);
                tileMap.AddLayer(new TileMapTileLayer(tileMap, layer.Id, layer.Name, tileMatrix));
                
            }


            foreach(var objGroup in input.ObjectGroups)
            {
                TileMapObjectLayer objLayer = new TileMapObjectLayer(tileMap, objGroup.Id, objGroup.Name);
                tileMap.AddLayer(objLayer);
                foreach(var obj in objGroup.Objects)
                {

                    PropertyMap propMap = CreatePropMap(obj);

                    if(obj.Point != null)
                    {
                        TileMapPointObject point = new TileMapPointObject(obj.Id, obj.Name, obj.Type, obj.X, obj.Y, propMap);
                        objLayer.AddObject(point);
                        continue;
                    }
                    if (obj.Polyline != null)
                    {
                        TileMapPolygonObject polyline = new TileMapPolygonObject(obj.Id, obj.Name, obj.Type, obj.X, obj.Y, propMap, ToPoints(obj.Polyline.Points, obj.X,obj.Y), true);
                        objLayer.AddObject(polyline);
                        continue;
                    }
                    if(obj.Polygon != null)
                    {
                        TileMapPolygonObject polygon = new TileMapPolygonObject(obj.Id, obj.Name, obj.Type, obj.X, obj.Y, propMap, ToPoints(obj.Polygon.Points, obj.X, obj.Y), false);
                        objLayer.AddObject(polygon);
                        continue;
                    }
                    TileMapRectangleObject rectangle = new TileMapRectangleObject(obj.Id, obj.Name, obj.Type, obj.X, obj.Y, propMap, obj.Width, obj.Height);
                    objLayer.AddObject(rectangle);
                    

                }

            }

            return tileMap;

        }

        private PropertyMap CreatePropMap(TileMapObjectData objectData)
        {

            PropertyMap propMap = new PropertyMap();

             if(objectData is null)
                return propMap;

             foreach(var prop in objectData.Properties)
            {
                propMap.Add(prop.Name, prop.Value);
            }

            return propMap;

        }

        private List<Vector2> ToPoints(string points, int offsetX, int offsetY)
        {
            string[] coordinates = points.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            List<Vector2> newPoints = new List<Vector2>();
            foreach(var point in coordinates)
            {
                string[] coordinate = point.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                newPoints.Add(new Vector2(Convert.ToInt16(coordinate[0]) + offsetX, Convert.ToInt16(coordinate[1]) + offsetY));
            }
            return newPoints;
        }

    }

}
