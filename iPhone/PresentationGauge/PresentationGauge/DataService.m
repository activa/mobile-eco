#import "DataService.h"

@implementation DataService

- (int) getScore
{
    NSData *data = [NSData dataWithContentsOfURL:[NSURL URLWithString:@"http://axum.mobi/api/xml"]];
    
    NSXMLParser *parser = [[NSXMLParser alloc] initWithData:data];
    
    parser.delegate = self;
    
    [parser parse];
    
    [parser release];
    
    return  _score;
}

- (void) parser:(NSXMLParser *)parser didStartElement:(NSString *)elementName namespaceURI:(NSString *)namespaceURI qualifiedName:(NSString *)qName attributes:(NSDictionary *)attributeDict
{
    if ([elementName isEqualToString:@"score"])
        _score = [[attributeDict valueForKey:@"value"] intValue];
}


@end
