using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Collision
{
    public interface IDynamicCollider : ICollisionRectangle
    {

        Rectangle PreviousCollider { get; }


    }
}
