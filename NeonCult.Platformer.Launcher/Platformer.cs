using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NeonCult.Platformer.Core;
using NeonCult.Platformer.TileMaps;
using System;
using System.Collections.Generic;

namespace NeonCult.Platformer.Launcher;

public class Platformer : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private TileSet _testTileSet;
    private TileMap _testTileMap;

    private Texture2D _whitePixel;

    private Polygon _testPolygon;

    public Platformer()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _whitePixel = Content.Load<Texture2D>("Textures/WhitePixel");

        _testTileSet = Content.Load<TileSet>("TileSets/BMBT-WorldOneTiles");
        _testTileSet.LoadTexture(Content);

        _testTileMap = Content.Load<TileMap>("TileMaps/TestWorld");
        _testTileMap.LoadTileSets(Content);

        List<Vector2> points = new List<Vector2>();
        points.Add(Vector2.Zero);
        points.Add(new Vector2(0,200));
        points.Add(Vector2.One*200);
        points.Add(new Vector2(200, 0));

        _testPolygon = new Polygon(points, false);
        _testPolygon.Translate(Vector2.One * 100);
        

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _testPolygon.RotateDynamic((float)Math.PI / (4f*60), new Vector2(100f, 100f));

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_testTileSet.Texture, Vector2.One, Color.White);

        _testPolygon.Draw(_spriteBatch, _whitePixel);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
