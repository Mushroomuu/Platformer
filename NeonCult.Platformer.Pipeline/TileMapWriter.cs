using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using NeonCult.Platformer.ContentReaders;
using NeonCult.Platformer.TileMaps;
using System.Linq;

namespace NeonCult.Platformer.Pipeline
{
    [ContentTypeWriter]
    public class TileMapWriter : ContentTypeWriter<TileMap>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(TileMapReader).AssemblyQualifiedName;
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(TileMap).AssemblyQualifiedName;
        }

        protected override void Write(ContentWriter output, TileMap value)
        {

            output.Write(value.TileWidth);
            output.Write(value.TileHeight);
            output.Write(value.Width);
            output.Write(value.Height);

            output.Write(value.TileSetRefCount);
            foreach (TileSetReference tsRef in value.TileSetReferences)
            {
                WriteTileSetReference(output, tsRef);
            }
            output.Write(value.Layers.Count(l => l.LayerType == TileMapLayerType.Tile));
            foreach (TileMapTileLayer layer in value.Layers.OfType<TileMapTileLayer>())
            {
                WriteTileLayer(output, layer);
            }
            output.Write(value.Layers.Count(l => l.LayerType == TileMapLayerType.Object));
            foreach (TileMapObjectLayer layer in value.Layers.OfType<TileMapObjectLayer>())
            {
                WriteObjectLayer(output, layer);
            }


        }

        private void WriteTileSetReference(ContentWriter output, TileSetReference reference) 
        {
            output.Write(reference.FirstGid);
            output.Write(reference.TileSetPath);
        
        }
        
        private void WriteTileLayer(ContentWriter output, TileMapTileLayer layer)
        {
            output.Write(layer.Id);
            output.Write(layer.Name);
            int width = layer.TileMatrix.Width;
            int height = layer.TileMatrix.Height;
            output.Write(width);
            output.Write(height);
            int x = 0;
            foreach (var tile in layer.TileMatrix)
            {
                
                int tileId = tile?.Id ?? 0;
                output.Write(tileId);
                x++;
            }

            
        }
        private void WriteObjectLayer(ContentWriter output, TileMapObjectLayer layer)
        {
            output.Write(layer.Id);
            output.Write(layer.Name);
            output.Write(layer.Objects.Count());
            foreach(var obj in layer.Objects) 
            { 
                output.Write(obj.Id);
                output.Write(obj.Name ?? ""); 
                output.Write(obj.Type ?? "");
                output.Write(obj.X);
                output.Write(obj.Y);
                output.Write(obj.CustomProperties.Count());
                foreach(var property in obj.CustomProperties)
                {
                    output.Write(property.Key);
                    output.Write(property.Value);
                }
                if (obj is TileMapPointObject)
                {
                    output.Write(0);
                    continue;
                }
                    
                if(obj is TileMapRectangleObject)
                {
                    output.Write(1);
                    TileMapRectangleObject rect = obj as TileMapRectangleObject;
                    output.Write(rect.Width);
                    output.Write(rect.Height);
                    continue;
                }
                output.Write(2);
                TileMapPolygonObject polygon = obj as TileMapPolygonObject;
                output.Write(polygon.Polygon.Vertices.Count());
                foreach(var point in polygon.Polygon.Vertices)
                {
                    output.Write(point.X);
                    output.Write(point.Y);
                }
                output.Write(polygon.Polygon.IsOpen);


            
            }
        }

    }

}
