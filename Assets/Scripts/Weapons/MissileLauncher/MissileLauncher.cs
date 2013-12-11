// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/09/13

using UnityEngine;
using System.Collections;

public class MissileLauncher : RangedWeaponClass {

	//FireFunc
    //Purpose: As long as there are more than 0 totalNumberOfProfectiles, there are more than 0 bulletsInClip, and nextFireTime is less than or equal to Time.time the ProjectileFunc function will be called. If there are less than 0 bulletsInClip and the nextReloadTime is less than or equal to Time.time the Reload function will be called. 
	//Parameters: none
    //Returns: void
	/// <summary>
	/// Fires the func.
	/// </summary>
	public override void FireFunc(){
		if(TotalNumberOfProjectiles > 0){
			
					ProjectileFunc();

		}
		else{
			
			Debug.Log("Out of missiles!");
			
		}
		
	}
	
	
	//ProjectileFunc
    //Purpose: Instantiates a projectile object and set the damage variables of the projectile equal to those of the machine gun. Decreases the totalNumberOfBullets and bulletsInClip by 1.
	//Parameters: none
    //Returns: void
	public void ProjectileFunc(){
		NextFireTime = Time.time + FirePauseTime;
		
		foreach(Transform MuzzlePos in MuzzlePosition){
				GameObject spawnedProj = Instantiate(TheProjectile, MuzzlePos.position, MuzzlePos.rotation) as GameObject;
				ProjectileML theProj = spawnedProj.gameObject.GetComponent<ProjectileML>();
				theProj.Damage = Damage;
				ProjectilesInClip--;
				TotalNumberOfProjectiles--;
		}
		
	}
	
}
