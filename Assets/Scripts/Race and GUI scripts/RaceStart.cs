// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/06/2013

using UnityEngine;
using System.Collections;

public class RaceStart : MonoBehaviour {
	
	//the player
	private GameObject player;
	//the cpu
	private GameObject cpu;
	
	//the motion scripts
	private MotionController playerMotion;
	private MotionController cpuMotion;
	
	//hold the children of this object
	public GameObject[] childTex = new GameObject[4];
	
	//the index for accessing the children
	private int index = 0;

	// Use this for initialization
	void Start () {
		//get the player dino and store in player
		player = GameObject.FindGameObjectWithTag("Player");
		
		//get the cpu dino and store in cpu
		cpu = GameObject.FindGameObjectWithTag("Racer");
		
		//get the MotionControllers from the player and the cpu
		playerMotion = player.GetComponent<MotionController>();
		cpuMotion = cpu.GetComponent<MotionController>();
		
		//turn off the motion scripts for the player and the cpu
		playerMotion.enabled = false;
		cpuMotion.enabled = false;
		
		//invoke the CountDown method
		InvokeRepeating ("CountDown", 1.0f, 1.0f);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
	
	void CountDown()
	{
		//if the index reaches the end
		if(index > 3) 
		{
			//get ride of the last child
			childTex[index - 1].SetActive(false);
		
			//reenable the motion scripts
			playerMotion.enabled = true;
			cpuMotion.enabled = true;
			
			//stop the repeating
			CancelInvoke("CountDown");
		}
		else
		{
			//set the next child as active
			childTex[index].SetActive(true);
			
			//if this is the first child
			if(index > 0)
			{
				//deactivate the child from before
				childTex[index - 1].SetActive(false);
			}
		
			//increment to the next child
			index++;
		}
	}
}
