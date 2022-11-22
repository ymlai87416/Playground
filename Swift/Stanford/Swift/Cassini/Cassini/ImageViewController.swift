//
//  ViewController.swift
//  Cassini
//
//  Created by Yiu ming Lai on 8/3/2020.
//  Copyright © 2020 Yiu ming Lai. All rights reserved.
//

import UIKit

class ImageViewController: UIViewController {

    @IBOutlet weak var imageView: UIImageView!
    
    var imageURL: URL?{
        willSet{
            print(newValue)
        }
        didSet{
            imageView.image = nil
            if view.window != nil{
                fetchImage()
            }
        }
    }
    
    override func viewDidAppear(_ animated: Bool){
        super.viewDidAppear(animated)
        
        if imageView.image == nil{
            fetchImage()
        }
    }
    
    private func fetchImage(){
        if let url = imageURL{
            let urlContent = try? Data(contentsOf:url)
            if let imageData = urlContent{
                imageView.image = UIImage(data: imageData)
            }
        }
    }
    
    override func viewDidLoad(){
        super.viewDidLoad()
        if(imageURL == nil){
            imageURL = DemoURLs.stanford
            //imageURL = URL(string: "https://upload.wikimedia.org/wikipedia/commons/5/55/Stanford_Oval_September_2013_panorama.jpg")
        }
    }
}

