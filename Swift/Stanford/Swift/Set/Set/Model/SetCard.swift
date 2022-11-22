//
//  SetCard.swift
//  Set
//
//  Created by Tom Lai on 31/3/2018.
//  Copyright © 2018年 Tom Lai. All rights reserved.
//

import Foundation

class SetCard: Card{
    var number: Int
    var color: Int
    var shading: Int
    var symbol: Int
    
    func content() -> String{
        return ""
    }
    
    func match() -> Int{
        return 0
    }
    
    init(number: Int, color: Int, shading:Int, symbol:Int){
        self.number = number
        self.color = color
        self.shading = shading
        self.shading = shading
    }
}
