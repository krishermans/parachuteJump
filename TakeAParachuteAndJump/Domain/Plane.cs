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

        public Plane(double positionX, double positionY, double speedX)
        {
            _positionX = positionX;
            _positionY = positionY;
            _speedX = speedX;
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
            PositionX = PositionX + _speedX;
        }
    }
}
