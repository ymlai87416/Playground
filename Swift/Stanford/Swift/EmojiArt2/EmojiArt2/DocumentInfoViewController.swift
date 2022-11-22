//
//  DocumentInfoViewController.swift
//  EmojiArt2
//
//  Created by Yiu ming Lai on 19/3/2020.
//  Copyright © 2020 Yiu ming Lai. All rights reserved.
//

import UIKit

class DocumentInfoViewController: UIViewController {

    var document: EmojiArtDocument?{
        didSet{
            updateUI()
        }
    }
    
    override func viewDidLoad(){
        super.viewDidLoad()
        updateUI()
    }
    
    private let shortDateFormatter: DateFormatter = {
        let formatter = DateFormatter()
        formatter.dateStyle = .short
        formatter.timeStyle = .short
        return formatter
    }()
    
    private func updateUI(){
        if sizeLabel != nil, createdLabel != nil,
            let url = document?.fileURL,
            let attributes = try? FileManager.default.attributesOfItem(atPath: url.path){
                sizeLabel.text = "\(attributes[.size] ?? 0) bytes"
                if let created = attributes[.creationDate] as? Date{
                    createdLabel.text = shortDateFormatter.string(from: created)
                }
                    
        }
        if thumbnailImageView != nil, thumbnailAspectRatio != nil, let thumbnail = document?.thumbnail{
            thumbnailImageView.image = thumbnail
            thumbnailImageView.removeConstraint(thumbnailAspectRatio)
            thumbnailAspectRatio = NSLayoutConstraint(
                item: thumbnailImageView,
                attribute: .width,
                relatedBy: .equal,
                toItem: thumbnailImageView,
                attribute: .height,
                multiplier: thumbnail.size.width / thumbnail.size.height, constant: 0)
            thumbnailImageView.addConstraint(thumbnailAspectRatio)
        }
        
        if presentationController is UIPopoverPresentationController{
            thumbnailImageView?.isHidden = true
            returnToDocumentButton?.isHidden = true
            view.backgroundColor = .clear
        }
    }
    
    override func viewDidLayoutSubviews() {
        super.viewDidLayoutSubviews()
        if let fittedSize = topLevelView?.sizeThatFits(UIView.layoutFittingCompressedSize){
            preferredContentSize = CGSize(width: fittedSize.width+30, height: fittedSize.height+30)
        }
    }

    
    @IBOutlet weak var topLevelView: UIStackView!
    @IBOutlet weak var thumbnailImageView: UIImageView!
    @IBOutlet weak var sizeLabel: UILabel!
    @IBOutlet weak var createdLabel: UILabel!
    @IBAction func done(_ sender: Any) {
        presentingViewController?.dismiss(animated: true)
    }
    @IBOutlet weak var returnToDocumentButton: UIButton!
    @IBOutlet weak var thumbnailAspectRatio: NSLayoutConstraint!
    /*
    // MARK: - Navigation

     
     // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
