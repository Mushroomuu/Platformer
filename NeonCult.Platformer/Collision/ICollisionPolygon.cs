using NeonCult.Platformer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Collision
{
    internal interface ICollisionPolygon : ICollisionObject
    {

        Polygon CollisionPolygon { get; set; }

    }
}
