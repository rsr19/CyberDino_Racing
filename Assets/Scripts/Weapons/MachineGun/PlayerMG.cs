// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/4/13

using UnityEngine;
using System.Collections;

public class PlayerMG : MachineGun {
	
	void Start(){
		
		RWStart();
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Q)){
				FireFunc();
		}
	}

}
