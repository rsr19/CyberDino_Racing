// Name: Samantha Spray
// Project: Cyber-Dino Racing
// Date: 12/09/13

using UnityEngine;
using System.Collections;

public class RacerHealthClass : MonoBehaviour {

	// Class Variables and Properties
	
	#region Fields
	[SerializeField]
	private float totalHealth; // Total health of the racer.
	[SerializeField]
	private float health; // Current health of the racer, this is the variable to use when causing damage to the racer.
	[SerializeField]
	[Range(.00f, 1.00f)] private float armor; // This variable should be between .00 and .99, it is used to reduce damage taken by the racer.
	private bool isDead = false; // This variable is used to determine whether or not the racer is dead.
	private MotionController theMC; // MotionController is being called so that this script can use MotionController.Respawn().
	#endregion Fields
	
	#region Properties
	public float TotalHealth
	{
		get
		{
			return totalHealth;
		}
		set
		{
			totalHealth = value;
		}
	}
	
	public float Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
		}
		
	}
	
	public float Armor
	{
		get
		{
			return armor;
		}
		set
		{
			armor = value;
		}
	}
	
	protected bool IsDead
	{
		get
		{
			return isDead;
		}
		set
		{
			isDead = value;
		}
	}
	
	private MotionController TheMC
	{
		get
		{
			if(theMC == null)
			{
				theMC = new MotionController();
			}
			return theMC;
		}
		set
		{
			theMC = value;
		}
	}
	#endregion Properties
	
	// Methods
	
	//RacerStart
    //Purpose: Initialize variables for the racer, to be put in the start function of inheriting classes.
	//Parameters: none
    //Returns: void
	/// <summary>
	/// Racer's start function.
	/// </summary>
	public void RacerStart()
	{
		TotalHealth = 100;
		//Create an instance of the MotionController class
		TheMC = this.gameObject.GetComponent<MotionController>();
		//Set health equal to totalHealth at the begining of the race
		Health = TotalHealth;
	}

	
	//CheckHealth
    //Purpose: checks if the racer's health is above 0 every frame and will respawn the racer and reset its health.
	//Parameters: none
    //Returns: void
	/// <summary>
	/// Checks the health of the racer.
	/// </summary>
	public void CheckHealth()
	{
		
		if(Health <= 0)
		{
			IsDead = true;
		}
		
		// If the racer is dead it will respawn, change its isDead var to false and reset its health back to full
		if(IsDead)
		{
			TheMC.Respawn();
			IsDead = false;
			RacerReset();
		}
		
	}
	
	//RacerReset
    //Purpose: resets racer's variables after death by weapons respawn.
	//Parameters: none
    //Returns: void
	/// <summary>
	/// Resets the racer.
	/// </summary>
	public void RacerReset(){
		
		Health = TotalHealth;
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Weapon"){
			Debug.Log (this + " has been hit with a weapon!");
		}
	}

}

