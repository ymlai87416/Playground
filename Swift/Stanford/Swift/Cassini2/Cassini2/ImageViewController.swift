//
//  ViewController.swift
//  Cassini2
//
//  Created by Yiu ming Lai on 8/3/2020.
//  Copyright © 2020 Yiu ming Lai. All rights reserved.
//

import UIKit

class ImageViewController: UIViewController, UIScrollViewDelegate {
    
    var imageView = UIImageView()

    @IBOutlet weak var spinner: UIActivityIndicatorView!
    
    @IBOutlet weak var scrollView: UIScrollView!{
        didSet{
            scrollView.minimumZoomScale = 1/25
            scrollView.maximumZoomScale = 1.0
            scrollView.delegate = self
            scrollView.addSubview(imageView)
        }
    }
    
    func viewForZooming(in scrollView: UIScrollView) -> UIView? {
        return imageView
    }
    
    private var image: UIImage? {
        get{
            return imageView.image
        }
        set{
            imageView.image = newValue
            imageView.sizeToFit()
            scrollView?.contentSize = imageView.frame.size
            spinner?.stopAnimating()
        }
    }
    
    var imageURL: URL?{
       didSet{
            image = nil
            
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
            spinner.startAnimating()
            DispatchQueue.global(qos: .userInitiated).async{[weak self] in
                let urlContent = try? Data(contentsOf:url)
                DispatchQueue.main.async{
                    if let imageData = urlContent, url == self?.imageURL {
                        self?.image = UIImage(data: imageData)
                    }
                }
            }
           
        }
    }

    override func viewDidLoad(){
       super.viewDidLoad()
       if(imageURL == nil){
           imageURL = DemoURLs.stanford
       }
    }


}

