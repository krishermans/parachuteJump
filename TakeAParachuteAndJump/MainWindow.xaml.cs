using System.Windows;
using System.Windows.Threading;
using TakeAParachuteAndJump.Domain;

namespace TakeAParachuteAndJump
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _animationTimer;
        private Game _game;
        private Plane _plane;
        private Skydiver _skydiver;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            _animationTimer.Start();
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            _game = new Game(landscapeCanvas.ActualWidth, landscapeCanvas.ActualHeight);
            _game.Setup();

            _plane = new Plane(landscapeCanvas, 10, 30, 5);
            _skydiver = new Skydiver(landscapeCanvas, 10, 30, 5);
            
            _animationTimer = new DispatcherTimer();
            _animationTimer.Interval = TimeSpan.FromMilliseconds(1000 / 25); // 25 fps
            _animationTimer.Tick += (s, e) =>
            { 
                _plane.Update();
                _skydiver.Update();
            };
        }

        private void diveButton_Click(object sender, RoutedEventArgs e)
        {
            _skydiver.IsVisible = true; // dive
        }
    }
}