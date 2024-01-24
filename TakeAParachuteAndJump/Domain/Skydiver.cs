using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TakeAParachuteAndJump.Domain
{
    public class Skydiver : FlyingObject
    {
        private BitmapImage _parachuteOpenImage = new BitmapImage();
        private BitmapImage _parachuteClosedImage = new BitmapImage();

        public Skydiver(Canvas drawingCanvas, double positionX, double positionY, double speedX)
            : base(drawingCanvas, positionX, positionY, speedX, 0)
        {
            _parachuteOpenImage.BeginInit();
            _parachuteOpenImage.UriSource = new Uri(@"Images/skydiver-open.png", UriKind.Relative);
            _parachuteOpenImage.EndInit();

            _parachuteClosedImage.BeginInit();
            _parachuteClosedImage.UriSource = new Uri(@"Images/skydiver-closed.png", UriKind.Relative);
            _parachuteClosedImage.EndInit();

            _image.Source = _parachuteClosedImage;
            _image.Width = _parachuteClosedImage.Width;
            _image.Height = _parachuteClosedImage.Height;
            _image.Margin = new Thickness(_positionX, _positionY, 0, 0);

            IsVisible = false;
            IsParachuteOpen = false;
        }

        public bool IsParachuteOpen
        { 
            get
            {
                return _image.Source == _parachuteOpenImage;
            }
            set
            {
                if (value)
                {
                    _image.Source = _parachuteOpenImage;
                }
                else
                {
                    _image.Source = _parachuteClosedImage;
                }
            }
        }

        public override void Update()
        {
            if (!IsVisible) // not visible: flying along with the plane
            {
                double width = _image.Width;
                double maxPositionX = _drawingCanvas.ActualWidth + width / 2;
                _positionX += _speedX;
                if (_positionX > maxPositionX)
                {
                    _positionX = width / 2 * (-1); // start offscreen
                }
            }
            else // falling down
            {
                double height = _image.Height;
                double maxPositionY = _drawingCanvas.ActualHeight - height / 1 - 5;
                _speedY = 5;
                _positionY += _speedY;
                if (_positionY > maxPositionY)
                {
                    _positionY = maxPositionY; // stay on the ground
                }
            }
            _image.Margin = new Thickness(_positionX, _positionY, 0, 0);
        }
    }
}
