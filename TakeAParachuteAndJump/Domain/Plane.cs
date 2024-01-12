using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

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

        private BitmapImage _planeBitmap = new BitmapImage();
        private Image _planeImage = new Image();
        private Canvas _drawingCanvas;


        public Plane(Canvas drawingCanvas, double positionX, double positionY, double speedX)
        {
            _drawingCanvas = drawingCanvas;
            _positionX = positionX;
            _positionY = positionY;
            _speedX = speedX;
            _canvasWidth = drawingCanvas.ActualWidth;

            _planeBitmap.BeginInit();
            _planeBitmap.UriSource = new Uri(@"Images/planeYellow1.png", UriKind.Relative);
            _planeBitmap.EndInit();

            _planeImage.Source = _planeBitmap;
            _planeImage.Width = _planeBitmap.Width;
            _planeImage.Height = _planeBitmap.Height;
            Width = _planeBitmap.Width;
            Height = _planeBitmap.Height;
            _planeImage.Margin = new System.Windows.Thickness(PositionX, PositionY, 0, 0);

            _drawingCanvas.Children.Add(_planeImage);

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
            _planeImage.Margin = new System.Windows.Thickness(PositionX, PositionY, 0, 0);
        }
    }
}
