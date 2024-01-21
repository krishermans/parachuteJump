﻿using System.Windows;
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

            _plane = new Plane(landscapeCanvas, 10, 30, 5); ;
            
            _animationTimer = new DispatcherTimer();
            _animationTimer.Interval = TimeSpan.FromMilliseconds(1000 / 25); // 25 fps
            _animationTimer.Tick += (s, e) => { _plane.Update(); };
        }

        private void planeButton_Click(object sender, RoutedEventArgs e)
        {
            _plane.Visible = !_plane.Visible;
        }
    }
}