using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TakeAParachuteAndJump.Domain
{
    public class Plane : FlyingObject
    {
        private BitmapImage _planeBitmap = new BitmapImage();
        
        public Plane(Canvas drawingCanvas, double positionX, double positionY, double speedX)
            :base(drawingCanvas, positionX, positionY, speedX, 0)
        {   
            _planeBitmap.BeginInit();
            _planeBitmap.UriSource = new Uri(@"Images/planeYellow1.png", UriKind.Relative);
            _planeBitmap.EndInit();
            
            _image.Source = _planeBitmap;
            _image.Width = _planeBitmap.Width;
            _image.Height = _planeBitmap.Height;
            _image.Margin = new Thickness(_positionX, _positionY, 0, 0);
            Visible = true;
        }

        public override void Update()
        {
            double width = _planeBitmap.Width;
            double maxPositionX = _drawingCanvas.ActualWidth + width / 2;
            _positionX += _speedX;
            if (_positionX > maxPositionX)
            {
                _positionX = width / 2 * (-1); // start offscreen
            }
            _image.Margin = new Thickness(_positionX, _positionY, 0, 0);
        }
    }
}
