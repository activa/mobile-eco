#import "GaugeView.h"
#import <QuartzCore/QuartzCore.h>

@implementation GaugeView

- (id)initWithFrame:(CGRect)frame
{
    self = [super initWithFrame:frame];
    
    if (self) 
    {
        _dialView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"dial.png"]];
        _needleView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"needle"]];
        
        _dialView.contentMode = UIViewContentModeScaleAspectFit;
        _needleView.contentMode = UIViewContentModeScaleAspectFit;
        
        _needleView.layer.anchorPoint = CGPointMake(0.5, 0.83);
        
        [self addSubview:_dialView];
        [self addSubview:_needleView];
    }
    
    return self;
}

- (void) layoutSubviews
{
    if (CGSizeEqualToSize(_size, self.bounds.size))
        return;
    
    _size = self.bounds.size;
    
    _dialView.frame = self.bounds;
    
    CGFloat scale = _size.width / _dialView.image.size.width;
    
    _needleView.frame = CGRectMake(0, 0, _needleView.image.size.width * scale, _needleView.image.size.height * scale);
    _needleView.center = CGPointMake(_size.width/2, _size.height/2);
}

- (void) setScore:(int) score
{
    CGFloat angle = (-110.0 + 220.0 * score / 100.0) * M_PI / 180.0;
    
    [UIView animateWithDuration:1.0 animations:^{ _needleView.transform = CGAffineTransformMakeRotation(angle); }];
}

- (void) dealloc
{
    [_dialView release];
    [_needleView release];
}

@end
