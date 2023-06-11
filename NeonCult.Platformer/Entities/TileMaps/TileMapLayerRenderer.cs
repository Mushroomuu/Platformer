using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeonCult.Platformer.TileMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Entities.TileMaps
{
    public class TileMapLayerRenderer : IGameEntity
    {
        public int DrawOrder => 0;

        public int UpdateOrder => 0;

        public TileMapTileLayer Layer { get; }
        public List<string> Ids { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TileMapLayerRenderer(TileMapTileLayer layer)
        {
            Layer = layer;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Layer?.TileMatrix?.ForEachTile((x, y) =>
                {
                    var tile = Layer.TileMatrix.GetTile(x, y);
                    var tileSetRef = Layer.ParentTileMap.GetTileSetByGlobalTileId(tile?.Id ?? 0);

                    if (tileSetRef?.TileSet is null)
                        return;

                    var tileSet = tileSetRef.TileSet;

                    Vector2 pos = new Vector2(x* tileSet.TileWidth, y* tileSet.TileHeight);

                    var tileBounds = tileSet.GetTileBoundsByLocalId(tileSetRef.GetLocalTileId(tile.Id));

                    spriteBatch.Draw(tileSet.Texture, Layer.ParentTileMap.Position + pos, tileBounds, Color.White);
                });
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
