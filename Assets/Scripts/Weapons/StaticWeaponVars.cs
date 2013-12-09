﻿// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/6/13

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticWeaponVars : MonoBehaviour {

	public static List<Transform> targets = new List<Transform>();
	
	public static void AddRacer(RacerHealthClass racer){
		if(!targets.Contains(racer.transform)){
			targets.Add(racer.transform);
		}
	}
	
}
