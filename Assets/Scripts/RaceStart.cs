// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/03/2013

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
	
	public Transform[] childTex = new Transform[4];
	
	private float time = 1000;
	private int index = 0;
	
	//the countdown game objects
	/*private Transform count1;
	private Transform count2;
	private Transform count3;
	private Transform countGo;*/

	// Use this for initialization
	void Start () {
		//get the player dino and store in player
		player = GameObject.FindGameObjectWithTag("Player");
		
		//get the cpu dino and store in cpu
		cpu = GameObject.FindGameObjectWithTag("Racer");
		
		//turn off the motion scripts for the player and the cpu
		playerMotion = player.GetComponent<MotionController>();
		cpuMotion = cpu.GetComponent<MotionController>();
		playerMotion.active = false;
		cpuMotion.active = false;
		
		/*count1 = transform.FindChild("countTex1");
		count2 = transform.FindChild("countTex1");
		count3 = transform.FindChild("countTex1");
		countGo = transform.FindChild("countTex1");*/
		
		//testTexture.transform.Translate( new Vector3(.1f, .1f, 0));
		

		//loop through the array assigning it the child objects
		for(int i = 0; i < childTex.Length; i++)
		{
			childTex[i] = transform.FindChild("countTex" + i);
		}
		
		InvokeRepeating ("CountDown", 1.0f, 1.0f);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*if (Input.GetKeyDown ("space")){
		if (childTex[3].active == true)
		{
			childTex[3].active = false;
		}
		else 
		{
			childTex[3].active = true;
		}
		}*/
		//loop through the array assigning it the child objects
		/*for(int i = 0; i < childTex.Length; i++)
		{
			childTex[i] = transform.FindChild("countTex" + i);
			childTex[i].active = true;
			//StartCoroutine("WaitToDisplay");
			//WaitToDisplay();
			//childTex[i].active = false;
			//Debug.Log(childTex[i]);
		}*/
		
	}
	
	void CountDown()
	{
		if(index > 3) 
		{
			childTex[index - 1].active = false;
		
			playerMotion.active = true;
			cpuMotion.active = true;
			
			CancelInvoke("CountDown");
		}
		else
		{
			childTex[index].active = true;
			if(index > 0)
			{
				childTex[index - 1].active = false;
			}
		
			index++;
		}
	}
}
