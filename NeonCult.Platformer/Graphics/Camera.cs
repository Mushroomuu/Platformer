using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Graphics
{
    public class Camera
    {

        private ICameraSnappable _mainSnappable;

        private Point _screenSize;
        private SnapType _snapType = SnapType.None;

        public Point CameraPoint { get; private set; }

        public Camera(Point screenSize)
        {
            _screenSize = screenSize;
        }

        public void Update(GameTime gameTime)
        {
            switch (_snapType)
            {
                case SnapType.Center:
                    CameraPoint = _mainSnappable.CameraPosition.ToPoint();
                    break;
            }
        }

        public void SetCenterSnap(ICameraSnappable snappable)
        {
            _mainSnappable = snappable;
            _snapType = SnapType.Center;
        }

    }
}
