﻿// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/16/13

using UnityEngine;
using System.Collections;

public class PlayerMG : MachineGun {
	
	void Start(){
		
		RWStart();
		
	}
	
	void onEnable()
	{
		// Subscribe to the shoot event delegate
		FireButton.shoot += FireFunc; 
	}
	
	void onDisable()
	{
		// Unsubscribe to the shoot event delegate
		FireButton.shoot -= FireFunc;
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Q)){
				FireFunc();
		}
	}

}
