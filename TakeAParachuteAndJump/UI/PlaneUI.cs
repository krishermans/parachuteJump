using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TakeAParachuteAndJump.Domain;

namespace TakeAParachuteAndJump.UI
{
    public class PlaneUI
    {
        private Plane _planeModel;

        private BitmapImage _planeBitmap = new BitmapImage();
        private Image _planeImage = new Image();
        private Canvas _drawingCanvas;

        public PlaneUI(Plane planeModel, Canvas drawingCanvas)
        {
            _planeModel = planeModel;
            _drawingCanvas = drawingCanvas;

            _planeBitmap.BeginInit();
            _planeBitmap.UriSource = new Uri(@"Images/planeYellow1.png", UriKind.Relative);
            _planeBitmap.EndInit();

            _planeImage.Source = _planeBitmap;
            _planeImage.Width = _planeBitmap.Width;
            _planeImage.Height = _planeBitmap.Height;
            _planeModel.Width = _planeBitmap.Width;
            _planeModel.Height = _planeBitmap.Height;

            _drawingCanvas.Children.Add(_planeImage);

            Update();
        }

        public void Update()
        {
            _planeModel.Update();
            _planeImage.Margin = new System.Windows.Thickness(_planeModel.PositionX, _planeModel.PositionY, 0, 0);
        }

    }
}
