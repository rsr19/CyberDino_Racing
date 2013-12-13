// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/011/2013
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuAlignment : MonoBehaviour 
{
	//if this is active or not
	//public bool activeState = false;
	
	//array of menu graphics
	GUITexture[] menuTexture = new GUITexture[5];
	
	
	//position for main menu
	private Vector2 menuPos;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if this is the current menu
		/*if(activeState == true)
		{
			//put this in the middle of the screen
			Vector2 pos = new Vector2(Screen.width * .01f, (Screen.height * .01f));
			transform.position = pos;
		}*/
		
		menuPos = new Vector2(Screen.width / 2, Screen.height / 2);
		
	}
	
	/*bool GetActiveState()
	{
		return activeState;
	}
	
	void SetActiveState(bool _state)
	{
		activeState = _state;
	}*/
	
	void OnGUI()
	{
		//if(GUI.Button(menuPos, 
	}
}
