using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TakeAParachuteAndJump.Domain
{
    public abstract class FlyingObject
    {
        protected double _positionX; // center of the visual representation
        protected double _positionY; // center of the visual representation
        protected double _speedX; // in horizontal direction
        protected double _speedY; // in vertical direction
        protected Image _image;
        protected Canvas _drawingCanvas;

        public FlyingObject(Canvas drawingCanvas, double positionX, double positionY, double speedX, double speedY)
        {
            _drawingCanvas = drawingCanvas;
            _positionX = positionX;
            _positionY = positionY;
            _speedX = speedX;
            _speedY = speedY;

            _image = new Image();
        }

        public bool Visible
        {
            get => _drawingCanvas.Children.Contains(_image);
            set
            {
                if (value)
                {
                    if (!_drawingCanvas.Children.Contains(_image))
                    {
                        _drawingCanvas.Children.Add(_image);
                    }
                }
                else
                {
                    _drawingCanvas.Children.Remove(_image);
                }
            }
        }

        // Update your movement, typically on every Tick event of a DispatcherTimer
        public abstract void Update();
    }
}
