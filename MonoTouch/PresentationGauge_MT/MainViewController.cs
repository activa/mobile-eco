using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;

namespace mt_test1
{
	public class MainViewController : UIViewController
	{
		private GaugeView gaugeView;
		
		public override void LoadView ()
		{
			View = gaugeView = new GaugeView();
		}
		
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			
			NSTimer timer = NSTimer.CreateRepeatingTimer(3.0, delegate { gaugeView.Value = DataService.GetScore(); });
			
			NSRunLoop.Current.AddTimer(timer,NSRunLoopMode.Default);
		}
	}
}

