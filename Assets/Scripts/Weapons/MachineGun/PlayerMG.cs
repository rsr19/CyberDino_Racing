// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 11/26/13

using UnityEngine;
using System.Collections;

public class PlayerMG : MachineGun {
	
	void Start(){
		
		RWStart();
		
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
				FireFunc();
		}
	}

}
