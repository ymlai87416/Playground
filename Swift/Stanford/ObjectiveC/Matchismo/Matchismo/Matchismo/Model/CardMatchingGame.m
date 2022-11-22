//
//  CardMatchingGame.m
//  Matchismo
//
//  Created by Tom Lai on 25/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

#import "CardMatchingGame.h"

@interface CardMatchingGame()

@property (nonatomic, readwrite) NSInteger score;
@property (nonatomic, readwrite) NSString* matchMessage;
@property (nonatomic, strong) NSMutableArray *cards;
@property (nonatomic, readwrite) NSInteger maxCard;
@property (nonatomic, readwrite) BOOL gameStart;
@end

@implementation CardMatchingGame

- (NSMutableArray *) cards
{
    if (!_cards) _cards = [[NSMutableArray alloc ] init];
    return _cards;
}

-(instancetype) initWithCardCount:(NSInteger)count usingDeck:(id)deck
{
    self = [super init];
    
    if (self){
        for(int i=0; i<count; ++i){
            Card * card = [deck drawRandomCard];
            if(card){
                [self.cards addObject:card];
            }
            else{
                self = nil;
                break;
            }
        }
    }
    
    self.gameStart = NO;
    self.maxCard = 2;
    
    return self;
}

-(void) toggleGameMode{
    if(self.maxCard == 2)
        self.maxCard = 3;
    else
        self.maxCard = 2;
}

-(Card*) cardAtIndex:(NSUInteger)index{
    return (index < [self.cards count]) ? self.cards[index] : nil;
}

static const int MATCH_BONUS = 4;
static const int MISMATCH_PENALTY = 2;
static const int COST_TO_CHOOSE = 1;

-(void) chooseCardAtIndex:(NSUInteger)index
{
    self.gameStart = YES;
    Card* card = [self cardAtIndex:index];
    self.matchMessage = nil;
    
    if(!card.isMatched){
        if(card.isChosen){
            card.chosen = NO;
            self.matchMessage = @"";
        }
        else
        {
            NSMutableArray *otherCards = [NSMutableArray array];
            for(Card * otherCard in self.cards){
                if (otherCard.isChosen && !otherCard.isMatched){
                    [otherCards addObject:otherCard];
                }
            }
            
            if([otherCards count] == self.maxCard-1){
                int matchScore = [card match:otherCards];
                if(matchScore){
                    self.score += matchScore * MATCH_BONUS;
                    NSString * cardContents = card.contents;
                    for(Card* otherCard in otherCards){
                        otherCard.matched = YES;
                        cardContents = [cardContents stringByAppendingString:@" "];
                        cardContents = [cardContents stringByAppendingString:otherCard.contents];
                    }
                    
                    card.matched = YES;
                    self.matchMessage = [NSString stringWithFormat: @"Matched %@ for %d points", cardContents, matchScore*MATCH_BONUS];
                }
                else{
                    self.score -= MISMATCH_PENALTY;
                    NSString * cardContents = card.contents;
                    for(Card* otherCard in otherCards){
                        otherCard.chosen = NO;
                        cardContents = [cardContents stringByAppendingString:@" "];
                        cardContents = [cardContents stringByAppendingString:otherCard.contents];
                    }
                    
                    self.matchMessage = [NSString stringWithFormat: @"%@ don't match %d points penalty!", cardContents, MISMATCH_PENALTY];
                }
            }
            
            if(self.matchMessage == nil)
                self.matchMessage = card.contents;
            
            self.score -= COST_TO_CHOOSE;
            card.chosen = YES;
        }
            
    }
    
}



@end
