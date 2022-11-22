//
//  CardMatchingGame.h
//  Matchismo
//
//  Created by Tom Lai on 25/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Card.h"
#import "Deck.h"

@interface CardMatchingGame : NSObject

// designated initializer
-(instancetype) initWithCardCount: (NSInteger) count usingDeck: (Deck*) deck;

-(void) chooseCardAtIndex:(NSUInteger)index;
-(Card *) cardAtIndex: (NSUInteger) index;
-(void) toggleGameMode;

@property (nonatomic, readonly) NSInteger score;
@property (nonatomic, readonly) NSString* matchMessage;
@property (nonatomic, readonly) NSInteger maxCard;
@property (nonatomic, readonly) BOOL gameStart;
@end
