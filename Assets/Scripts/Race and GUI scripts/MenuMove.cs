﻿// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/011/2013
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuMove : MonoBehaviour 
{
	//The rect to be used to change the button positions
	public Rect[] buttonPos;
	
	//declare variables to access the menu scripts
	private MainMenu mMenu;
	private SinglePlayerMenu sPMenu;
	private DinoSelect charSelect;
	
	//public GameObject cam;
	
	// Use this for initialization
	void Start () 
	{
		//cam = GameObject.FindGameObjectWithTag("MainCamera");
		sPMenu = GetComponent<SinglePlayerMenu>();
		mMenu = GetComponent<MainMenu>();
		charSelect = GetComponent<DinoSelect>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
		
	}
	
	public void MoveOffLeft(int _size)
	{
		Debug.Log("it worked first");
		//in a loop
		for(int i = 0; i < _size; i++)
		{
			//position the buttons off the screen to the right
			buttonPos[i].x = Screen.width / 2;
			//buttonPos[i].y = -i;
			
			while(buttonPos[i].x < 0)
			{
				buttonPos[i].x -= 2;
			}
		}
	}
	
	public void MenuSwitch(string _name)
	{
		switch(_name)
		{
			case "SinglePlayer":
				//disable the button graphics
				mMenu.DisableButtons();
				//turn off the button functionality
				//mMenu.enabled = false;
			
				//enable the next menu
				sPMenu.enabled = true;
				break;
			case "Multiplayer":
				charSelect.enabled = true;
				sPMenu.enabled = false;
				break;
			case "Settings":
				charSelect.enabled = true;
				charSelect.enabled = false;
				break;
			default:
				Debug.Log("Nothing happened");
				break;
		}
	}
}