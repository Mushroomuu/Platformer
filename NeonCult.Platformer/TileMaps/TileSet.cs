using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.TileMaps
{
    public class TileSet
    {


        public string Name { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TileCount { get; set; }

        public Texture2D Texture { get; private set; }
        public string TexturePath { get; set; }

        public int ColumnCount { get; set; }

        public int RowCount => TileCount / ColumnCount;

        private TileSet()
        {

        }

        public TileSet(string name, int tileWidth, int tileHeight, int tileCount, string texturePath, int columnCount)
        {
            Name = name;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TileCount = tileCount;
            TexturePath = texturePath;
           // Texture = texture ?? throw new ArgumentNullException(nameof(texture));
            ColumnCount = columnCount;
        }

        public Rectangle GetTileBounds(int x, int y)
        {
            return new Rectangle
            {
                X = x * TileWidth,
                Y = y * TileHeight,
                Width = TileWidth,
                Height = TileHeight
            };
        }

        public Rectangle GetTileBoundsByLocalId(int tileId)
        {
            int tileid = tileId - 1;
            int x = tileid % ColumnCount;
            int y = tileid / ColumnCount;
            return GetTileBounds(x, y);
        }

        public bool LoadTexture(ContentManager contentManager)
        {
            if (contentManager is null)
                throw new ArgumentNullException(nameof(contentManager));
            Texture = contentManager.Load<Texture2D>(TexturePath);

            return Texture != null;
        }

    }
}
