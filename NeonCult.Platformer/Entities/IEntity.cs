using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Entities
{
    public interface IEntity
    {

        List<string> Ids { get; set; }

        int UpdateOrder { get; }

        void Update(GameTime gameTime);

    }
}
