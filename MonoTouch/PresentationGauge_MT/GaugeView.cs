using System;
using System.Diagnostics;
using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;

namespace mt_test1
{
	public class GaugeView : UIView
	{
		private UIImageView _dialView;
		private UIImageView _needleView;
		private SizeF _size;
		
		public GaugeView ()
		{
			_dialView = new UIImageView(UIImage.FromBundle("images/dial.png"));
			_needleView = new UIImageView(UIImage.FromBundle("images/needle.png"));
		
			_dialView.ContentMode = UIViewContentMode.ScaleAspectFit;
			_needleView.ContentMode = UIViewContentMode.ScaleAspectFit;

			_needleView.Layer.AnchorPoint = new PointF(0.5f,0.83f);

			AddSubview(_dialView);
			AddSubview(_needleView);
		}
		
		public override void LayoutSubviews ()
		{
			if (_size.Equals(Bounds.Size))
				return;
			
			_size = Bounds.Size;
			
			float scale = _size.Width / _dialView.Image.Size.Width;

			_dialView.Frame = Bounds;

			_needleView.Frame = new RectangleF(0,0,_needleView.Image.Size.Width * scale, _needleView.Image.Size.Height * scale);
			_needleView.Center = new PointF(_size.Width/2,_size.Height/2);
		}
		
		public int Value 
		{
			set 
			{ 
				UpdateNeedle(value); 
			}
		}
		
		private void UpdateNeedle(int value)
		{
			double angle = (-110.0 + 220.0 * value / 100.0) * Math.PI / 180.0;
			
			UIView.Animate( 1.0,
			              	0.0,
			              	UIViewAnimationOptions.BeginFromCurrentState, 
			              	delegate { _needleView.Transform = CGAffineTransform.MakeRotation((float)angle); }, 
							null );
		}
		
	}
}
