using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Collision
{
    public interface ICollisionRectangle : ICollisionObject
    {

        Rectangle CollisionBox { get; }

    }
}
