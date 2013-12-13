// Name: Myles Nielsen
// Project: Cyber Dino Racing
// Date 11/28/2013

using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MotionController))] // This forces unity to add the MotionController script when this is added to an object.
public class EnemyAI : MonoBehaviour {
	
	public Transform[] waypoints; // List of waypoints.  Set this in the unity inspector window.
	public float waypointRadius = 12.0f; // Distance you have to be from the waypoint to have it trigger.
	
	public float turning = 1.6F; // Variable that adjusts the turning speed or the Vector 3 Lerp.
	
	private MotionController playerController; // Variable that allows access to the MotionController Script on the player car.
	private float oldMaxSpeed; // Old max speed to determine ai max speed.
	private Collider[] aimTargets;
	private GameObject player;
	
	private MotionController controller; // Class reference to the MotionController.
	private EnemyAIMG enemyAIMG;
	
	// Private Variables the determine direction of movement.
	private Vector3 targetDirection; // The point in the world that the unit wants to face.
	private Vector3 currentDirection; // The point in the world that the unit is currently facing.
	private int targetWaypoint; // The current waypoint you are targeting.
	private int closestWaypoint;
	
	public float threatAngle = 10.0f;
	private Collider playerCollider;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<MotionController>(); // Gets access to the MotionController script.
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MotionController>();
		playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshCollider>();
		enemyAIMG = GetComponentInChildren<EnemyAIMG>();
		
		oldMaxSpeed = controller.maxspeed;
		currentDirection = transform.forward; // Sets current direction to infront of the unit on the z axis.
		closestWaypoint = 0; // Sets closest waypoint to the first waypoint in the list.
		targetWaypoint = closestWaypoint + 1; // Target waypoint is one further than the closest waypoint.
	}
	
	// Update is called once per frame
	void Update () {
		
		aimTargets = Physics.OverlapSphere (transform.position, 8);
		
		Move ();
		
		for (int i = 0; i < aimTargets.Length; i++){
				if (aimTargets[i] = playerCollider) {
					float angle = Vector3.Angle(transform.forward, aimTargets[i].gameObject.transform.position - transform.position);
					if (angle <= threatAngle){
						enemyAIMG.AIFireMG();
					}
				}
			}
		
		transform.LookAt(transform.position + currentDirection); // Makes the unit look at the current direction.
		
		// Controls the changing of the target waypoint.  If within range it changes to the next on the list and makes it restart when it hits the end.
		if(Vector3.Distance(transform.position, waypoints[closestWaypoint].position) >=	Vector3.Distance(transform.position, waypoints[targetWaypoint].position)) {
			closestWaypoint = targetWaypoint;
			targetWaypoint = closestWaypoint + 1;
			if (targetWaypoint >= waypoints.Length) {
				targetWaypoint = 0;
			}
		}
		
		// If the player is too far behind or infront of the enemy it will adjust the speed to keep them closer to the player unit.
		if (controller.racePosition >= playerController.racePosition + 4){
			controller.maxspeed = oldMaxSpeed * 0.8f;
		}
		else if (controller.racePosition <= playerController.racePosition - 2){
			controller.maxspeed = oldMaxSpeed * 1.2f;
		}
		else {
			controller.maxspeed = oldMaxSpeed;
		}
	}
	
	public void Act() {
		if (aimTargets == null){
			FindWaypoint();
		}
		else {
			FindTarget();	
		}
		
	}
	
	void Move(){
		controller.x = 1; // Sets the x in the controller to 
		targetDirection = waypoints[targetWaypoint].position - transform.position; // Sets the direction towards the current target waypoint.
		currentDirection = Vector3.Lerp(currentDirection, targetDirection, turning * Time.deltaTime); // Lerping causes a gradual turn between the current direction and target direction.
	}
	
	void FindWaypoint() {
		targetDirection = waypoints[targetWaypoint].position - transform.position; // Sets the target direction towards the current target waypoint.
		currentDirection = Vector3.Lerp(currentDirection, targetDirection, turning * Time.deltaTime); // Lerping causes a gradual turn between the current direction and target direction.
	}
	
	void FindTarget() {
		targetDirection = player.transform.position - transform.position; // Sets the target direction towards the current target waypoint.
		currentDirection = Vector3.Lerp(currentDirection, targetDirection, turning * Time.deltaTime); // Lerping causes a gradual turn between the current direction and target direction.
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