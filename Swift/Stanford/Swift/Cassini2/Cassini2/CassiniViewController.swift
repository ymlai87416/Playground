//
//  CassiniViewController.swift
//  Cassini2
//
//  Created by Yiu ming Lai on 8/3/2020.
//  Copyright © 2020 Yiu ming Lai. All rights reserved.
//

import UIKit

class CassiniViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }
    

    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
        
        if let identifier = segue.identifier{
            if let url = DemoURLs.NASA[identifier]{
                
                if let imageVC = segue.destination.contents as? ImageViewController{
                    imageVC.imageURL = url
                    imageVC.title = (sender as? UIButton)?.currentTitle
                }
            }
        }
    }

}


extension UIViewController{
    var contents: UIViewController{
        if let navcon = self as? UINavigationController{
            return  navcon.visibleViewController ?? self
        }
        else{
            return self
        }
    }
}
