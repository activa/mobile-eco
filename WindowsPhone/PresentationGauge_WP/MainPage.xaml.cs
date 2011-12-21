using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PresentationGauge_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            needleRotation.CenterX = imageNeedle.RenderSize.Width / 2;
            needleRotation.CenterY = imageNeedle.RenderSize.Height * 0.83;

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };

            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DataService.GetScore(delegate(int score) 
            {
                DoubleAnimation animation = needleAnimation.Children.OfType<DoubleAnimation>().First();

                animation.From = needleRotation.Angle;
                animation.To = score * 220.0 / 100.0 - 110.0;

                needleAnimation.Begin();
            });
        }
    }
}