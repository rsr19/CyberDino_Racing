// Name: Robert Reed
// Project: Cyber-Dino Racing
// Date: 12/011/2013

using UnityEngine;
using System.Collections;

public class FireButton : MonoBehaviour
{
	public delegate void WeaponShoot();
	public static event WeaponShoot shoot;

	// Use this for initialization
	void Start () 
	{
		//RWStart();
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
					if(Input.GetTouch(i).phase == TouchPhase.Began)
					{
						if(shoot != null)
						{
							shoot();
						}
					}
				}
			}
		}
	}
}


