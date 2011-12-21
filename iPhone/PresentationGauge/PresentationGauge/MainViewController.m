#import "MainViewController.h"
#import "GaugeView.h"
#import "DataService.h"

@implementation MainViewController

- (void)loadView
{
    self.view = [[[GaugeView alloc] init] autorelease];
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    NSTimer *timer = [NSTimer timerWithTimeInterval:3.0 target:self selector:@selector(timerFired) userInfo:nil repeats:YES];
                      
    [[NSRunLoop currentRunLoop] addTimer:timer forMode:NSRunLoopCommonModes];
}

- (void) timerFired
{
    DataService *dataService = [[DataService alloc] init];
    
    int score = [dataService getScore];
    
    [dataService release];
    
    [((GaugeView *)self.view) setScore:score];
}
                      
@end
