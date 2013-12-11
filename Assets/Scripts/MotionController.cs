// Name: Lee Whittaker
// Project: Cyber-Dino Racing
// Date: 12/02/2013

using UnityEngine;
using System.Collections;

public class MotionController : MonoBehaviour {
	
	//Class Variables
	//Public Variables that vary based on Dino and Upgrades.
	public float maxspeed = 60.0F; // The maximum speed of the Vehicle's forward momentum
	public float acceleration = 7.0F; // The Vehicle's rate of acceleration
	public float maxspeedreverse = -15.0F; // The maximum speed of the Vehicle's reverse momentum
	
	//Public Variables that control motion
	public float x; // Receives forward/reverse input from -1 to 1
	public float y; // Recieves left/right input from -1 to 1
	
	// Functional Private Variables
	// Motion Variables
	private float n; // Inertia variable. = move / maxspeed / 2; 0 to 2
	private float inertia; // move multiplier. = n^2 * 2n; 0.1 to 1 to 0.1
	private float move = 0.0F; // controls forward/reverse propultion, set by x, accelleration, & innertia
	private float turn = 0.0F; // controls left/right steering, set by y
	
	// Tubro Variables
	private float oldMaxSpeed; // contains maxspeed data for reinitializing

	// Trackers and Finish Line Objects.
	private GameObject[] trackers; // Array of trackers on the track for respawn and checkpoint functions
	//creating properties
	private GameObject[] Trackers{
		get
		{
			if(trackers == null){
				trackers = new GameObject[0];
			}
			return trackers;
		}
		set
		{
			trackers = value;
		}

	}
	private GameObject closestTracker; // the GameObject container for the tracker closest to the vehicle at all times.
	private GameObject finishLine; // The collision object for crossing the finish line. 
	private int lap = 1; // Laps, increments when passing 3 checkpoint and finishline objects.
	private bool[] checks = new bool[]{false,false,false}; // Array of bools, each element turns true when checkpoints are reached.

	
	void Start () {
		
		// Initialize Variables
		oldMaxSpeed = maxspeed; // Set maxSpeed container for Turbo function
		finishLine = GameObject.Find ("FinishBox"); // Set Finish Line by name
		trackers = GameObject.FindGameObjectsWithTag("tracker"); // Populate array with trackers
		closestTracker = trackers[0]; // set first Closest Tracker object

		Debug.Log (lap); // Print First Lap

	}
	
	

	void Update () {
		
		// Set Inertia
		n = Mathf.Abs(move / (maxspeed / 2)); // Set n from move
		inertia = -(Mathf.Pow (n, 2)) + (2 * n); // Set inertia from n
		if (inertia < 0.1F) { inertia = 0.1F; } // Ensure inertia is no less than 0.1
		
		// Test if closestTracker is a checkpoint, modify check[] to true.
		int nodeNum = int.Parse(closestTracker.name.Substring(closestTracker.name.Length-3, 3));
		if (nodeNum % 13 == 0)
		{
			checks[(nodeNum/13)-1] = true;
		}

		
		// Modify move controrler between maxspeed forward and reverse 
		if (move <= maxspeed && move >= maxspeedreverse)
		{
			move += x * acceleration * inertia;
		}		
		
		
		// Drift to a stop or reduce speed by inertia
		if (move != 0 && x == 0 || move > maxspeed)
		{
			if (move > 0.1F)
			{
				move -= inertia;
			}
			else if (move < -0.1F)
			{
				move += inertia;
			}
			else
			{
				move = 0;
			}
		}
				
		// set turn from input
		turn = y;
		
		// Actually move the Vehicle
		//this.transform.Translate(new Vector3(-move,0,0) * Time.deltaTime); // Move forward/reverse
		this.transform.Translate(new Vector3(0,0,move) * Time.deltaTime); // Move forward/reverse
		this.transform.Rotate (0,turn,0); // Turn left/right
	}
	

	
	// Trigger finish line collision
	void OnTriggerEnter(Collider collision)
	{
		if (checks[0] && checks[1] && checks[2]) // Check if all checkpoints were passed.
		{
			if (collision.gameObject.name == finishLine.name) // Check that the collider is the finish line
			{
				lap += 1; // Increase Lap
				Debug.Log (lap); // Print Lap
				for(int i = 0; i < 3; i++)
				{
					checks[i] = false; // Reset checkpoint array to falses
				}
			}
		}
	}
	
	
	// Test collision with track
	void OnCollisionStay(Collision collision)
	{
		
		// Update closest tracker while colliding with track
		if (collision.gameObject.name == "Torus001")
		{
			foreach (GameObject node in Trackers)// Checks for null values
			{
				float lastDistance = Vector3.Distance(this.transform.position, node.transform.position);
				float thisDistance = Vector3.Distance(this.transform.position, closestTracker.transform.position);
				
				if (lastDistance <= thisDistance)
				{
					closestTracker = node;
				}	
			}
		}
	}
	
	// Test if car hits the bottom floor.
	void OnCollisionEnter(Collision collision)
	{
		// Respawn if the collider hits the bottom. 
		if (collision.gameObject.tag == "bottom")
		{
			Respawn();
		}
	}
	
	
	// callTurbo
	// Purpose: Call the Turbo() co-routine.
	// Parameters: none
	// Returns: none
	public void callTurbo()
	{
		// Start the Turbo coroutine
		StartCoroutine("Turbo");
	}
	
	
	// Turbo
	// Purpose: Cause the Vehicle to go "Turbo" speed for 5 seconds, then restore to original speed. 
	// Parameters: none
	// Returns: Coroutine wait for 5.0 seconds
	IEnumerator Turbo()
	{
		maxspeed = 90;
		while (move < maxspeed)
		{
			move += acceleration;
		}
		yield return new WaitForSeconds(5.0f);

		maxspeed = oldMaxSpeed;
	}
	
	
	// Respawn
	// Purpose: Return the Vehicle to the track at standard condition.
	// Parameters: none
	// Returns: none
	public void Respawn()
	{
		// Set Respawn Position and move speed from last tracker collected while connected to track.
		move = 0;
		this.rigidbody.velocity = Vector3.zero;
		this.transform.position = closestTracker.transform.position;
		
		// Set Respawn Rotation and turn speed from last tracker collected while connected to track.
		turn = 0;
		this.rigidbody.angularVelocity = Vector3.zero;
		this.transform.rotation = Quaternion.identity;
		int nodeNum = int.Parse(closestTracker.name.Substring(closestTracker.name.Length-3, 3));
		if (nodeNum < trackers.Length)
		{
			nodeNum += 1;
		}
		else
		{
			nodeNum = 1;
		}
		this.transform.LookAt(GameObject.Find("tracker" + nodeNum.ToString("000")).transform);
		this.transform.Rotate (0,0,0);
	}
	
	
	
	
	// GetLap
	// Purpose: Get this vehicle's lap
	// Parameters: none
	// Returns: int lap
	public int GetLap()
	{
		return lap;
	}
}