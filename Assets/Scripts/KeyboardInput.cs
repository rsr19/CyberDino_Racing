// Name: Lee Whittaker
// Project: Cyber-Dino Racing
// Date: 11/25/2013

using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	
	//Private Variables that recieve motion control data
	private float x; // Receives forward/reverse input from -1 to 1
	private float y; // Recieves left/right input from -1 to 1
	
	//Private variables that control the script
	private MotionController car; // Controls the vehicle motion script;

	
	
	void Start () {
		
		car = this.gameObject.GetComponent<MotionController>(); // set the vehicle motion script;

	}

	void Update () {
		
		// Get Keybord Input for move and turn
		x = Input.GetAxis ("Vertical");
		y = Input.GetAxis ("Horizontal");
		
		// set move and turn from input
		car.x = x;
		car.y = y;

		// Activate Turbo with spacebar
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// Start the Turbo coroutine
			car.callTurbo();
		}
		
		// Activate Respawn with R
		if(Input.GetKeyDown (KeyCode.R))
		{
			// Use Respawn
			car.Respawn();
		}
	}
}