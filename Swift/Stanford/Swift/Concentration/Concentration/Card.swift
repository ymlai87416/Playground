//
//  Card.swift
//  Concentration
//
//  Created by Tom Lai on 26/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

import Foundation

struct Card : Hashable
{
    var isFaceUp  = false
    var isMatched = false
    private var identifier: Int
    
    private static var identifierFactory = 0
    
    private static func getUniqueIdentifier() -> Int{
        identifierFactory += 1
        return identifierFactory
    }
    
    init(){
        self.identifier = Card.getUniqueIdentifier();
    }
    
    func hash(into hasher: inout Hasher){
        hasher.combine(self.identifier)
    }
    
    static func == (lhs: Card, rhs: Card) -> Bool {
        return lhs.identifier == rhs.identifier;
    }
}
