using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TakeAParachuteAndJump.Domain
{
    public class Plane
    {
        private double _positionX; // center of the visual representation
        private double _positionY;
        private double _speedX; // in horizontal direction
        private double _width;
        private double _height;
        private double _canvasWidth; // is width of the canvas

        public Plane(double positionX, double positionY, double speedX, double canvasWidth)
        {
            _positionX = positionX;
            _positionY = positionY;
            _speedX = speedX;
            _canvasWidth = canvasWidth;
        }

        public double Width
        { 
            get => _width;
            set => _width = value;
        }

        public double Height
        { 
            get => _height;
            set => _height = value;
        }

        public double PositionX
        {
            get => _positionX;
            set => _positionX = value;
        }

        public double PositionY
        {
            get => _positionY;
            set => _positionY = value;
        }

        public void Update()
        {
            double maxPositionX = _canvasWidth + Width / 2;
            PositionX = (PositionX + _speedX) % maxPositionX;
        }
    }
}
