//
//  Deck.swift
//  Set
//
//  Created by Tom Lai on 31/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

import Foundation

class Deck{
    private(set) var cards :  [Card]()
    
    func addCard(card: Card){
        self.addCard(card: card, atTop: false)
    }
    
    func addCard(card: Card, atTop: Bool){
        if atTop{
            cards.insert(card, at: 0)
        }
        else{
            cards.append(card)
        }
    }
    
    func drawRandomCard -> Card{
        let index = Int(arc4raondom() % self.cards.count)
        randomCards = self.cards[index];
        self.cards.remove(index);
        
        return randomCard;
    }
}
