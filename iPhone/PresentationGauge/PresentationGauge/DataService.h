#import <Foundation/Foundation.h>

@interface DataService : NSObject<NSXMLParserDelegate>
{
    int _score;
}

- (int) getScore;

@end
