//
//  Concentration.swift
//  Concentration
//
//  Created by Tom Lai on 26/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

import UIKit

class Concentration: NSObject {
    var cards = [Card]()
    
    var indexOfOneAndOnlyFaceUpCard: Int? {
        get{
            let faceUpCardIndicies = cards.indices.filter{cards[$0].isFaceUp}
            return faceUpCardIndicies.oneAnyOnly
        }
        set{
            for index in cards.indices{
                cards[index].isFaceUp = (index == newValue)
            }
        }
    }
    
    
    func chooseCard(at index: Int){
        assert(cards.indices.contains(index), "Concentration.chooseCard(at: \(index)): choose index not in the cards")
        if !cards[index].isMatched{
            if let matchIndex = indexOfOneAndOnlyFaceUpCard, matchIndex != index{
                if cards[matchIndex] == cards[index]{
                    cards[matchIndex].isMatched = true
                    cards[index].isMatched = true
                }
                cards[index].isFaceUp = true
            }
            else{
                indexOfOneAndOnlyFaceUpCard = index;
            }
        }
    }
    
    init(numberOfPairsOfCards: Int){
        assert(numberOfPairsOfCards > 0, "Concentration.init(\(numberOfPairsOfCards)): you must have at least one pair of cards")
        for _ in 1...numberOfPairsOfCards{
            let card = Card()
            let matchingCard = card
            
            cards.append(card)
            cards.append(matchingCard)
        }
        
        cards = cards.shuffled()
    }
}

extension MutableCollection {
    /// Shuffles the contents of this collection.
    mutating func shuffle() {
        let c = count
        guard c > 1 else { return }
        
        for (firstUnshuffled, unshuffledCount) in zip(indices, stride(from: c, to: 1, by: -1)) {
            // Change `Int` in the next line to `IndexDistance` in < Swift 4.1
            let d : Int = numericCast(arc4random_uniform(numericCast(unshuffledCount)))
            let i = self.index(firstUnshuffled, offsetBy: d)
            swapAt(firstUnshuffled, i)
        }
    }
}

extension Sequence {
    /// Returns an array with the contents of this sequence, shuffled.
    func shuffled() -> [Element] {
        var result = Array(self)
        result.shuffle()
        return result
    }
}

extension Collection{
    var oneAnyOnly: Element? {
        return count == 1 ? first: nil
    }
}
