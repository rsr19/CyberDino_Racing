// Name: Myles Nielsen
// Project: Cyber Dino Racing
// Date 11/28/2013

using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MotionController))] // This forces unity to add the MotionController script when this is added to an object.
public class EnemyAI : MonoBehaviour {
	
	public Transform[] waypoints; // List of waypoints.  Set this in the unity inspector window.
	public float waypointRadius = 10.0f; // Distance you have to be from the waypoint to have it trigger.
	
	public float turning = 1.6F; // Variable that adjusts the turning speed or the Vector 3 Lerp.
	
	private MotionController controller; // Class reference to the MotionController.
	
	// Private Variables the determine direction of movement.
	private Vector3 targetDirection; // The point in the world that the unit wants to face.
	private Vector3 currentDirection; // The point in the world that the unit is currently facing.
	private int targetWaypoint; // The current waypoint you are targeting.
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<MotionController>(); // Gets access to the MotionController script.
		
		currentDirection = transform.forward; // Sets current direction to infront of the unit on the z axis.
		targetWaypoint = 0;	// Sets target waypoint to the first in the list.
	}
	
	void FixedUpdate() {
		targetDirection = waypoints[targetWaypoint].position - transform.position; // Sets the target direction towards the current target waypoint.
		
		currentDirection = Vector3.Lerp(currentDirection, targetDirection, turning * Time.deltaTime); // Lerping causes a gradual turn between the current direction and target direction.
	}
	
	// Update is called once per frame
	void Update () {
		
		controller.x = 1; // Sets the x in controller to move the unit.
		
		transform.LookAt(transform.position + currentDirection); // Makes the unit look at the current direction.
		
		// Controls the changing of the target waypoint.  If within range it changes to the next on the list and makes it restart when it hits the end.
		if(Vector3.Distance(transform.position, waypoints[targetWaypoint].position) <=	waypointRadius) {
			targetWaypoint++;
			if (targetWaypoint >= waypoints.Length) {
				targetWaypoint = 0;
			}
		}
	}
}

/* To get this working I had to modify a few things in MotionController.cs and in the scene in Unity.
 * 
 * For determining transform.forward it always uses the z axis so I had to change line 95 to
 * this.transform.Translate(new Vector3(0,0,move) * Time.deltaTime); // Move forward/reverse
 * 
 * An in the scene I changed the units to be rotated on the y axis at 270 and switched the x and z scales.
 * That has to be done for the enemy car and the player car.
 * 
 * Last is the waypoints.  Just create empty game objects and lay them around the track to determine the path
 * you want the ai to follow.  Then in the inspector window within the EnemyAI script change the size under
 * waypoints to the amount of waypoints you created and drag the waypoints from the hierarchy window to their
 * positions in the inspector window.
*/