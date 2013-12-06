// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/4/13

using UnityEngine;
using System.Collections;

public class RangedWeaponClass : WeaponClass {

	//Class Variables and Properties
	
	//Reload Variables
	[SerializeField]
	private float reloadTime = 0.0f;	// The ammount of time it takes the gun to reload.
	public float ReloadTime
	{
		get
		{
			return reloadTime;
		}
		set
		{
			reloadTime = value;
		}
	}
	
	private float nextReloadTime; // The next time the gun will reload.
	public float NextReloadTime
	{
		get
		{
			return nextReloadTime;
		}
		set
		{
			nextReloadTime = value;
		}
	}
	
	[SerializeField]
	private float firePauseTime = 0.0f; // The ammount of time between the firing of each projectile.
	public float FirePauseTime
	{
		get
		{
			return firePauseTime;
		}
		set
		{
			firePauseTime = value;
		}
	}
	
	private float nextFireTime; // The next time the gun will fire.
	public float NextFireTime
	{
		get
		{
			return nextFireTime;
		}
		set
		{
			nextFireTime = value;
		}
	}
	
	//Clip Variables
	[SerializeField]
	private int projectilesInClip; // The number of bullets in a clip.
	public int ProjectilesInClip
	{
		get
		{
			return projectilesInClip;
		}
		set
		{
			projectilesInClip = value;
		}
	}
	
	[SerializeField]
	private int numberOfClips; // The number of clips the gun comes with (this could be changed through the game by picking up power-ups that replenish or add to the number of clips).
	public int NumberOfClips
	{
		get
		{
			return numberOfClips;
		}
		set
		{
			numberOfClips = value;
		}
	}
	
	[SerializeField]
	private int totalNumberOfClips; // The total number of clips the gun starts with.
	public int TotalNumberOfClips
	{
		get
		{
			return totalNumberOfClips;
		}
		set
		{
			totalNumberOfClips = value;
		}
	}
	
	private int totalNumberOfProjectiles; // The total ammount of bullets between all clips.
	public int TotalNumberOfProjectiles
	{
		get
		{
			return totalNumberOfProjectiles;
		}
		set
		{
			totalNumberOfProjectiles = value;
		}
	}
	
	//Projectile Variable
	[SerializeField]
	private GameObject theProjectile; // The gameObject the gun will use as a bullet.
	public GameObject TheProjectile
	{
		get
		{
			return theProjectile;
		}
		set
		{
			theProjectile = value;
		}
	}
	
	[SerializeField]
	private Transform[] muzzlePosition; // The position that theProjectile will instantiate from.
	public Transform[] MuzzlePosition
	{
		get
		{
			return muzzlePosition;
		}
		set
		{
			muzzlePosition = value;
		}
	}
	
	//MGStart
    //Purpose: Initialize variables for the ranged weapon in the Start function of the child classes.
	//Parameters: none
    //Returns: void
	public void RWStart(){
		
		NumberOfClips = TotalNumberOfClips;
		TotalNumberOfProjectiles = ProjectilesInClip * NumberOfClips;
		
	}
	
	//ProjectileFunc
    //Purpose: Instantiates a projectile object and set the damage variables of the projectile equal to those of the machine gun. Decreases the totalNumberOfBullets and bulletsInClip by 1.
	//Parameters: none
    //Returns: void
	public void ProjectileFunc(){
		NextFireTime = Time.time + FirePauseTime;
		
		foreach(Transform MuzzlePos in MuzzlePosition){
				GameObject spawnedProj = Instantiate(TheProjectile, MuzzlePos.position, MuzzlePos.rotation) as GameObject;
				projectileMG theProj = spawnedProj.gameObject.GetComponent<projectileMG>();
				theProj.Damage = Damage;
				ProjectilesInClip--;
				TotalNumberOfProjectiles--;
		}
		
	}
	
	//Reload
    //Purpose: After a short time this function will reload bulletsInClip as long as numberOfClips is greater than 0, otherwise it will alert the racer that they are out of bullets.
	//Parameters: none
    //Returns: void
	public void Reload(){
		NextReloadTime = Time.time + ReloadTime;
		
		
		if(NumberOfClips > 0){
			if(ProjectilesInClip <= 0){
				NumberOfClips--;
				ProjectilesInClip = TotalNumberOfProjectiles / NumberOfClips;
				Debug.Log("Reloaded");
			}	
		}
		else{
			
			Debug.Log("You are out of bullets!");
			
		}
		
		
	}
	
	
}