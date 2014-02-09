﻿// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/4/13

using UnityEngine;
using System.Collections;

public class ProjectileMachineGunClass : ProjectileClass {
	
	//Class Variables	
	private RacerHealthClass theRacer; // Used to access variables on a racer.

	void Start()
	{
		ProjectileStart();
	}

	// Update is called once per frame
	void Update () {
	
		FireProjectileFunc();
		
	}
	
	//OnTriggerEnter
    //Purpose: detects when the projectile hits an object with the tag "Racer," the projectile will get the health variable 
	//			from the object and call the DealDamage function then destroy itself.
	//Parameters: Collider other
    //Returns: void
	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "Weapon"){
			Physics.IgnoreCollision(this.collider, other);
		}
		if(other.gameObject.tag == "Racer"){
				theRacer = other.gameObject.GetComponent<RacerHealthClass>();
				theRacer.Health -= DealDamage(theRacer.Armor);
				GameObject spawnedHitParticle = Instantiate(HitParticle, this.transform.position, this.transform.rotation) as GameObject;
	//			gameObject.transform.position = StartPosition.position;
				gameObject.SetActive(false);
		}
	}
	
}
