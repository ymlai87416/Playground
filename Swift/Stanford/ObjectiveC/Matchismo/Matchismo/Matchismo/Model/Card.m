//
//  Card.m
//  Matchismo
//
//  Created by Tom Lai on 24/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

#import "Card.h"

@interface Card()

@end

@implementation Card

- (int) match:(NSArray*) otherCards{
    
    int score = 0;
    for(Card *card in otherCards){
        if([card.contents isEqualToString:self.contents]){
            score = 1;
        }
    }
    
    return score;
}

@end
