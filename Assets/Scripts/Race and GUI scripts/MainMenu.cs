﻿// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/20/2013
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	//an array to hold the button graphics
	public Texture[] menuGraphics;
	
	//an array to hold the button game objects
	private GameObject[] buttons = new GameObject[4];
	
	//a float to hold the y position of the buttons
	private float posY = 0;
	
	//get the menu move script
	private MenuMove menu;
	
	//floats to hold the button information
	private float textureY = 0.0f;
	private float textureX = 0.0f;
	private float buttonSizeY = 0.0f;
	private float buttonSizeX = 0.0f;
	private float buttonRatio = 0.0f;
	public float sizeSetter = .0015f;
	
	// Use this for initialization
	void Start () 
	{
		menu = GetComponent<MenuMove>();
		
		//in a loop create the buttons
		for(int i = 0; i < buttons.Length; i++)
		{
			//fill the array with game objects
			buttons[i] = new GameObject("button" + i);
			
			//add the guitexture component to it
			buttons[i].AddComponent("GUITexture");
			
			//assign the graphics
			buttons[i].guiTexture.texture = menuGraphics[i];
			
			//gets the width and height of the texture graphic
			textureY = buttons[i].guiTexture.texture.height;	
			textureX = buttons[i].guiTexture.texture.width;
			
			//change the height to the texture graphic ratio
			buttonRatio = Screen.height / (textureX / textureY);
				
			//get the pixel size for the button
			buttonSizeY = textureY * (buttonRatio * sizeSetter);
			buttonSizeX = textureX * (buttonRatio * sizeSetter);
			
			//start off the resizing from zero
			buttons[i].transform.localScale = new Vector3(0, 0, 0);
			
			//set the position of the button
			posY += buttonSizeY;
			
			//set the rect position and size
			menu.buttonPos[i] = new Rect(Screen.width / 2, (Screen.height - (Screen.height * 0.01f)) - posY, buttonSizeX, buttonSizeY);

			//set the inset to equal the menu rect
			buttons[i].guiTexture.pixelInset = menu.buttonPos[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*for(int i = 0; i < Input.touchCount; i++)
		{
			//do this for the current touch on the screen
			if(this.guiTexture.HitTest(Input.GetTouch(i).position))
			{
				//if it is hit
				if(Input.GetTouch(i).phase == TouchPhase.Began)
				{
					Debug.Log(this.name);
				}
			}
		}*/
		
		if(Input.GetMouseButtonDown(0))
		{
			if(buttons[1].guiTexture.HitTest(Input.mousePosition))
			{
				menu.MenuSwitch("SinglePlayer");
			}
			
			if(buttons[2].guiTexture.HitTest(Input.mousePosition))
			{
				Debug.Log(");
			}
		}
		
	}
	
/*	void OnGUI()
	{
		GUI.DrawTexture(menu.buttonPos[0], menuGraphics[0]);
		
		//display the buttons
		if(GUI.Button(menu.buttonPos[1], menuGraphics[1]))
		{
			menu.MenuSwitch("test");
		}
		
		if(GUI.Button(menu.buttonPos[2], menuGraphics[2]))
		{
			//menu.MoveOnLeft(1);
		}
		
		if(GUI.Button(menu.buttonPos[3], menuGraphics[3]))
		{
			//menu.MoveOnLeft(1);
		}
	}*/
	
	/*void OnMouseDown()
	{
		Debug.Log(this.name);	
	}*/
	
	public void DisableButtons()
	{
		for(int i = 0; i < buttons.Length; i++)
		{	
			buttons[i].guiTexture.enabled = false;
			this.enabled = false;
		}
	}
	
	public void EnableButtons()
	{
		for(int i = 0; i < buttons.Length; i++)
		{	
			buttons[i].SetActive(false);	
		}
	}
}
