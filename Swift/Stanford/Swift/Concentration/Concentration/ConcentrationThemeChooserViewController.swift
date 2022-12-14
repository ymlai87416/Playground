//
//  ConcentrationThemeChooserViewController.swift
//  Concentration
//
//  Created by Yiu ming Lai on 2/3/2020.
//  Copyright Β© 2020 Tom Lai. All rights reserved.
//

import UIKit

class ConcentrationThemeChooserViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }
    
    let themes = [
        "Sports" : "β½οΈππβΎοΈπ₯πππ±πβ·π³β³οΈ",
        "Animals" : "πΆππ¦πΌπ¦πͺππππ¦π΅",
        "Faces" : "ππππ©π°π΄ππ€ππ·"
    ]
    
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
        
        if segue.identifier == "Choose Theme" {
            if let button = sender as? UIButton{
                if let themeName = button.currentTitle, let theme = themes[themeName]{
                    if let cvc = segue.destination as? ConcentrationViewController{
                        cvc.theme = theme
                    }
                }
            }
        }
    }
}
