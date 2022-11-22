//
//  Card.swift
//  Set
//
//  Created by Tom Lai on 31/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

import Foundation

class Card{
    
    var isFaceUp = false
    var isMatched = false
    var identifier: Int
    
    static var identifierFactory = 0
    
    static func getUnqiueIdentifier() -> Int{
        identifierFactory += 1
        return identifierFactory
    }
    
    init(){
        self.identifier = Card.getUnqiueIdentifier();
    }
}

