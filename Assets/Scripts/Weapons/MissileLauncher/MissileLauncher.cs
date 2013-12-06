// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/4/13

using UnityEngine;
using System.Collections;

public class MissileLauncher : RangedWeaponClass {

	//FireFunc
    //Purpose: As long as there are more than 0 totalNumberOfProfectiles, there are more than 0 bulletsInClip, and nextFireTime is less than or equal to Time.time the ProjectileFunc function will be called. If there are less than 0 bulletsInClip and the nextReloadTime is less than or equal to Time.time the Reload function will be called. 
	//Parameters: none
    //Returns: void
	public void FireFunc(){
		if(TotalNumberOfProjectiles > 0){
			if(ProjectilesInClip > 0){
				if(Time.time >= NextFireTime){
			
					ProjectileFunc();
				}
			}
			if(Time.time >= NextReloadTime){
				Reload();
			}
		}
		
	}
}
