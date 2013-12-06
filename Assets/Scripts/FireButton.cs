﻿// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/03/2013

using UnityEngine;
using System.Collections;

public class FireButton : MachineGun {

	// Use this for initialization
	void Start () 
	{
		RWStart();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.touches.Length > 0)
		{
			//loop through the touches 
			for(int i = 0; i < Input.touchCount; i++)
			{
				//do this for the current touch on the screen
				if(this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					//if it is hit
					if(Input.GetTouch(i).phase == TouchPhase.Stationary)
					{
						Debug.Log("hello");
						FireFunc();
					}
				}
			}
		}
	}
}


