//
//  PlayingCard.h
//  Matchismo
//
//  Created by Tom Lai on 24/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

#ifndef PlayingCard_h
#define PlayingCard_h

#import <Foundation/Foundation.h>
#import "Card.h"

@interface PlayingCard: Card
@property (strong, nonatomic) NSString * suit;
@property (nonatomic) NSUInteger rank;

+(NSArray *) validSuits;
+(NSUInteger)maxRank;

@end

#endif /* PlayingCard_h */
