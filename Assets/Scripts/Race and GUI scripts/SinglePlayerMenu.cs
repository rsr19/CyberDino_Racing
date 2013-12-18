using UnityEngine;
using System.Collections;

public class SinglePlayerMenu : MonoBehaviour
{
	//an array to hold the button graphics
	public Texture[] menuGraphics;
	
	//get the menu move script
	private MenuMove menu;

	// Use this for initialization
	void Start () 
	{
		menu = GetComponent<MenuMove>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(menu.buttonPos[0], menuGraphics[0]);
		
		//display the buttons
		if(GUI.Button(menu.buttonPos[1], menuGraphics[1]))
		{
			menu.MenuSwitch("CharSelect");
		}
		
		if(GUI.Button(menu.buttonPos[2], menuGraphics[2]))
		{
			//menu.MoveOnLeft(1);
		}
		
		if(GUI.Button(menu.buttonPos[3], menuGraphics[3]))
		{
			//menu.MoveOnLeft(1);
		}
	}
}
