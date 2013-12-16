//Samantha Spray
//Project: Cyber-Dino Racing
//12/16/13
using UnityEngine;
using System.Collections;

public class PlayerMotion : Motion {

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate () {
		// If there is touch or mouse input the player will not get movement input from the keyboard
		if(Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
		{
			
		}
		
		else
		{
			H = Input.GetAxis("Horizontal");
			V = Input.GetAxis("Vertical");
		}
		
		// Move the player
		TranslateRacer(H, V);
		
		if(Input.GetKeyUp(KeyCode.T))
		{
			UseTurbo();
		}
		
	}
}
