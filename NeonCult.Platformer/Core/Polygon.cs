using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NeonCult.Platformer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Core
{
    public class Polygon
    {


        private List<Vector2> _pointsStatic = new List<Vector2>();
        private List<Vector2> _points = new List<Vector2>();

        private float _culmulativeRadians;

        public bool IsOpen { get; set; }

        public List<Line> Lines { get; set; } = new List<Line>();
        public List<Vector2> Vertices => _points;

        public Polygon(List<Vector2> points, bool isOpen)
        {
            _pointsStatic = points;
            _points = new List<Vector2>(points);
            IsOpen = isOpen;

            MakeLines();

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D debugTexture)
        {
            foreach (Line line in Lines)
                spriteBatch.DrawLine(debugTexture, line.VectorA, line.VectorB, Color.Magenta, 1);
        }

        public bool IsIntersecting(Polygon other)
        {
            foreach(Line line in other.Lines)
                if (IsIntersecting(line)) 
                   return true;
            return false;
        }

        public bool IsIntersecting(Line line)
        {
            foreach(Line l in  Lines)
                if(l.IsIntersecting(line)) 
                   return true;
            return false;
        }

        public void Translate(Vector2 translation)
        {
            List<Vector2> translatedPoints = new List<Vector2>();
            foreach (Vector2 vector2 in _points)
                translatedPoints.Add(vector2 + translation);
            _points = new List<Vector2>(translatedPoints);
            translatedPoints.Clear();
            foreach (Vector2 vector2 in _pointsStatic)
                translatedPoints.Add(vector2 + translation);
            _pointsStatic = new List<Vector2>(translatedPoints);

            MakeLines();

        }

        public void RotateStatic(float angle, Vector2 Origin, bool isRelative)
        {
            Rotate(angle, isRelative ? Origin + GetTopLeft(_pointsStatic) : Origin, _pointsStatic);

            _culmulativeRadians += angle;

            if (_culmulativeRadians > Math.PI * 2)
                _culmulativeRadians -= (float)Math.PI * 2;
        }

        public void RotateDynamic(float angle, Vector2 Origin) => Rotate(angle, Origin, _points);

        public void StampPoints()
        {
            _pointsStatic = new List<Vector2>(_points);
            _culmulativeRadians = 0;
        }

        private void Rotate(float angle, Vector2 Origin, List<Vector2> points) //angle is in Radians
        {
            List<Vector2> newPoints = new List<Vector2>();

            foreach(Vector2 point in points)
            {
                Vector2 translatedPoint = point - Origin;

                float oldX = translatedPoint.X;
                float oldY = translatedPoint.Y;

                float angleX = (float) Math.Cos(angle + _culmulativeRadians);
                float angleY = (float) Math.Sin(angle + _culmulativeRadians);

                float newX = oldX*angleX - oldY*angleY;
                float newY = oldX*angleY + oldY*angleX;

                newPoints.Add(new Vector2(newX + Origin.X, newY + Origin.Y));
            }

            _points = newPoints;

            MakeLines();

        }

        private void MakeLines()
        {
            var lines = new List<Line>();

            for (int i = 1; i < _points.Count; i++)
                lines.Add(new Line(_points[i - 1], _points[i]));

            if (!IsOpen)
                lines.Add(new Line(_points[_points.Count - 1], _points[0]));

            Lines = lines;

        }

        private Vector2 GetTopLeft(List<Vector2> points)
        {
            float x = float.MaxValue;
            float y = float.MaxValue;
            foreach(Vector2 point in points)
            {
                if (point.X < x)
                    x = point.X;
                if (point.Y < y)
                    y = point.Y;
            }
            return new Vector2(x, y);
        }

    }
}
