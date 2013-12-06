// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/4/13

using UnityEngine;
using System.Collections;

public class ProjectileML : ProjectileClass {
	
	//Class Variables	
	private RacerHealthClass theRacer; // Used to access variables on a racer.
	private bool haveTarget = false; // Used to check whether this projectile has a target or not.
	public bool HaveTarget
	{
		get
		{
			return haveTarget;
		}
		set
		{
			haveTarget = value;
		}
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
			Debug.Log("Hit Racer");
			theRacer = other.gameObject.GetComponent<RacerHealthClass>();
			theRacer.Health -= DealDamage(theRacer.Armor);
			Destroy(gameObject);
		}
	}
	
	public override void FireProjectileFunc(){
		base.FireProjectileFunc(); // Calls the base FireProjectileFunc()
		Transform target = null;
		if(!HaveTarget){ // Checks if the projectile has a target, if not one will be randomly chosen from the list of Targets
			int min = 0; // Minimum index number for the random range func.
			int max = Targets.Count; // Maximum index number for the random range func.
			int randomIndex = Random.Range( min, max); // The random number that will be used as the index Targets for the specific target
			target = Targets[randomIndex]; // The target
		}
		if(target != null){ // If the projectile has a target, it will look at the target
			transform.LookAt(target);
		}
	}
	
}
