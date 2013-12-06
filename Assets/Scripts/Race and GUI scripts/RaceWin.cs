// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/06/2013
using UnityEngine;
using System.Collections;

public class RaceWin : MonoBehaviour {
	
	//the player
	private GameObject player;
	//the cpu
	private GameObject cpu;
	
	//the motion scripts
	private MotionController playerMotion;
	private MotionController cpuMotion;
	
	//win or lose tests
	private bool winRace = false;
	private bool looseRace = false;
	
	//the win texture
	public Texture winTex;
	
	//the loose texture
	public Texture looseTex;

	// Use this for initialization
	void Start () {
		//get the player dino and store in player
		player = GameObject.FindGameObjectWithTag("Player");
		
		//get the cpu dino and store in cpu
		cpu = GameObject.FindGameObjectWithTag("Racer");
		
		//set the motioncontroller scripts from the player and the cpu
		playerMotion = player.GetComponent<MotionController>();
		cpuMotion = cpu.GetComponent<MotionController>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//if the player's lap is greater then 3 and greater then the cpu lap
		if(playerMotion.GetLap() > 3 && playerMotion.GetLap() > cpuMotion.GetLap())
		{
			winRace = true;
		}
		//else
		else if(playerMotion.GetLap() > 3 && playerMotion.GetLap() < cpuMotion.GetLap())
		{
			looseRace = true;
		}
	
	}
	
	void OnGUI()
	{
		//if you won the race display the text
		if(winRace == true)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), winTex, ScaleMode.ScaleToFit, true, 0);	
		}
		//else if you loose say so
		else if(looseRace == true)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), looseTex, ScaleMode.ScaleToFit, true, 0);
		}
	}
}
