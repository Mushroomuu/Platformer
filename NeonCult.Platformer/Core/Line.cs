using Microsoft.Xna.Framework;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Core
{
    public class Line
    {

        public Vector2 VectorA { get; set; }
        public Vector2 VectorB { get; set; }

        public float Top => VectorA.Y < VectorB.Y ? VectorA.Y : VectorB.Y;
        public float Bottom => VectorA.Y > VectorB.Y ? VectorA.Y : VectorB.Y;
        public float Left => VectorA.X < VectorB.X ? VectorA.X : VectorB.X;
        public float Right => VectorA.X > VectorB.X ? VectorA.X : VectorB.X;
        public float Slope => (VectorB.Y - VectorA.Y)/(VectorA.X - VectorB.X);
        public Line(Vector2 A, Vector2 B)
        {
            VectorA = A;
            VectorB = B;
        }

        //From https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/#
        public bool IsIntersecting (Line other)
        {
            LineOrientation o1 = GetOrientation(VectorA, VectorB, other.VectorA);
            LineOrientation o2 = GetOrientation(VectorA, VectorB, other.VectorB);
            LineOrientation o3 = GetOrientation(other.VectorA, other.VectorB, VectorA);
            LineOrientation o4 = GetOrientation(other.VectorA, other.VectorB, VectorB);

            if (o1 != o2 && o3 != o4)
                return true;

            if (o1 == LineOrientation.Collinear && onSegment(VectorA, other.VectorA, VectorB)) return true;
            if (o2 == LineOrientation.Collinear && onSegment(VectorA, other.VectorB, VectorB)) return true;
            if (o3 == LineOrientation.Collinear && onSegment(other.VectorA, VectorA, other.VectorB)) return true;
            if (o4 == LineOrientation.Collinear && onSegment(other.VectorA, VectorB, other.VectorB)) return true;

            return false;

        }

        private LineOrientation GetOrientation(Vector2 a, Vector2 b,Vector2 v)
        {
            float val = (b.Y - a.Y) * (v.X - b.X) - (b.X - a.X)*(v.Y - b.Y);

            if (val == 0)
                return LineOrientation.Collinear;
            return val > 0 ? LineOrientation.Sunwise : LineOrientation.Widdershins;

        }

        private bool onSegment(Vector2 p, Vector2 q, Vector2 r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;

            return false;
        }


    }
}
