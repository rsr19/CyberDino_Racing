﻿// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/6/13

using UnityEngine;
using System.Collections;

public class PlayerML : MissileLauncher {
	
	void Start(){
		
		RWStart();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			
			FireFunc();
			
		}
	}
}
