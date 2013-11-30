// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 11/27/13

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileClass : WeaponClass {

	// Class Variables and Properties
	
	[SerializeField]
	private float projSpeed; // How fast the projectile travels.
	public float ProjSpeed
	{
		get
		{
			return projSpeed;
		}
		set
		{
			projSpeed = value;
		}
	}
	
	[SerializeField]
	private float projRange; // The farthest the projectile will travel.
	public float ProjRange
	{
		get
		{
			return projRange;
		}
		set
		{
			projRange = value;
		}
	}
	
	private float projDist; // How far the projectile has traveled.
	public float ProjDist
	{
		get
		{
			return projDist;
		}
		set
		{
			projDist = value;
		}
	}
	
	//FireProjectileFunc
    //Purpose: Translates the projectile from its starting point, if the projDist is less than or equal to the projRange the gameObject destroys itself.
	//Parameters: none
    //Returns: void
	public void FireProjectileFunc(){
		
		transform.Translate(Vector3.forward * Time.deltaTime * ProjSpeed);
		ProjDist += Time.deltaTime * ProjSpeed;
	
		if(ProjDist >= ProjRange){
			
			Destroy(gameObject);
			
		}
		
	}
	
}
