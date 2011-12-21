#import <UIKit/UIKit.h>

@interface GaugeView : UIView 
{
    UIImageView * _dialView;
    UIImageView * _needleView;
    CGSize _size;
}

- (void) setScore:(int) score;

@end
