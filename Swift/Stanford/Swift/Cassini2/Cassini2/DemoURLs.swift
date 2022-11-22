//
//  DemoURLs.swift
//  Cassini2
//
//  Created by Yiu ming Lai on 8/3/2020.
//  Copyright © 2020 Yiu ming Lai. All rights reserved.
//

import Foundation


struct DemoURLs{
    
    static let stanford = Bundle.main.url(forResource: "oval", withExtension: "jpg")
    //static let stanford = URL(string: "https://upload.wikimedia.org/wikipedia/commons/5/55/Stanford_Oval_September_2013_panorama.jpg")
    
    static var NASA: Dictionary<String, URL> = {
        let NASAURLStrings = [
            "Cassini" : "https://www.jpl.nasa.gov/images/cassini/20090202/pia03883-full.jpg",
            "Earth": "http://www.nasa.gov/sites/default/files/wave_earth_mosaic_3.jpg",
            "Saturn": "http://www.nasa.gov/sites/default/files/saturn_collage.jpg"
        ]
        
        var urls = Dictionary<String, URL>()
        for (key, value) in NASAURLStrings{
            print(URL(string: value)!)
            urls[key] = getCleanedURL(urlStr: value)!
        }
        
        return urls
    }()
    
    static func getCleanedURL(urlStr: String) -> URL? {
       if let url = URL(string: urlStr) {
           return url
       } else {
           if let urlEscapedString = urlStr.addingPercentEncoding(withAllowedCharacters: CharacterSet.urlQueryAllowed) , let escapedURL = URL(string: urlEscapedString){
               return escapedURL
           }
       }
       return nil
    }
}
