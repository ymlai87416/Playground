//
//  PlayingCard.m
//  Matchismo
//
//  Created by Tom Lai on 24/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

#import "PlayingCard.h"

@implementation PlayingCard

- (NSString* ) contents
{
    NSArray *rankString = [PlayingCard rankStrings];
    return [rankString [self.rank] stringByAppendingString:self.suit];
    
}

@synthesize suit = _suit;

+ (NSArray*) validSuits
{
    return @[@"♥", @"♦", @"♠", @"♣"];
}

+ (NSArray*) rankStrings
{
    return @[@"?", @"A", @"2", @"3", @"4", @"5", @"6", @"7", @"8", @"9", @"10", @"J", @"Q", @"K"];
}

+ (NSUInteger) maxRank { return [[self rankStrings] count] -1; }


-(void)setSuit:(NSString *)suit
{
    if ([[PlayingCard validSuits] containsObject:suit]){
        _suit = suit;
    }
}

-(NSString* ) suit
{
    return _suit ? _suit : @"?";
}

-(void) setRank: (NSUInteger) rank{
    if (rank <= [PlayingCard maxRank]){
        _rank = rank;
    }
}

-(int) match: (NSArray* ) otherCards
{
    int score = 0;
    
    for(PlayingCard* otherCard in otherCards){
        if (otherCard.rank == self.rank){
            score = 4;
        } else if ([otherCard.suit isEqualToString:self.suit]){
            score = 1;
        }
    }
    
    if( [otherCards count] > 1)
    {
        PlayingCard * firstOtherCard = otherCards[0];
        NSArray* otherCardsSubList = [otherCards subarrayWithRange:NSMakeRange(1, [otherCards count] - 1)];
        score += [firstOtherCard match:otherCardsSubList];
    }
    
    return score;
}

@end
