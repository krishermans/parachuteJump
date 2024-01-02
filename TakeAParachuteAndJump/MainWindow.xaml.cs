using System.Windows;
using System.Windows.Threading;
using TakeAParachuteAndJump.Domain;
using TakeAParachuteAndJump.UI;

namespace TakeAParachuteAndJump
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _animationTimer;
        private Game _game;
        private PlaneUI _planeUI;
        private Plane _planeModel;

        public MainWindow()
        {
            InitializeComponent();

            _game = new Game(landscapeCanvas.ActualWidth, landscapeCanvas.ActualHeight);
            _game.Setup();

            _planeModel = new Plane(60, 200, 0.001);
            _planeUI = new PlaneUI(_planeModel, landscapeCanvas);

            _animationTimer = new DispatcherTimer();
            _animationTimer.Interval = TimeSpan.FromSeconds(1 / 30); // 3O fps
            _animationTimer.Tick += (s, e) => { _planeUI.Update(); };

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            _animationTimer.Start();
        }
    }
}