// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 11/26/13

using UnityEngine;
using System.Collections;

public class OpponentHealthClass : RacerHealthClass {

	// Use this for initialization
	void Start () {
	
		RacerStart();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		CheckHealth();
		
	}
}
