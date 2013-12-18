using UnityEngine;
using System.Collections;

public class DinoSelect : MonoBehaviour {
	
	//array for the rect
	private Rect[] selectRect = new Rect[9];
	public Texture[] fxPics = new Texture[9];
	
	//array for the back button
	private Rect backRect;
	
	//get the menu move script
	private MenuMove menu;

	// Use this for initialization
	void Start () 
	{
		
		menu = GetComponent<MenuMove>();
		
		selectRect[0].x = Screen.width / 2;
		selectRect[0].y = 10;
		
		//in a loop set up the button Rect
		for(int i = 1; i < 9; i++)
		{
			selectRect[i].width = 120;
			selectRect[i].height = 80;
			
			//if i is less than 4
			if(i < 5)
			{
				selectRect[i].x = (i + 1) * 150;
				selectRect[i].y = 90;
			}
			else
			{
				selectRect[i].x = (i - 3) * 150;
				selectRect[i].y = 180;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.Label(selectRect[0], fxPics[0]);
			
		if(GUI.Button(selectRect[1], fxPics[1]))
		{
			menu.MenuSwitch("LevelSelect");
		}
		
		if(GUI.Button(selectRect[2], "Empty"))
		{
			
		}
		
		if(GUI.Button(selectRect[3], "Empty"))
		{
			
		}
		
		if(GUI.Button(selectRect[4], "Empty"))
		{
			
		}
		
		if(GUI.Button(selectRect[5], "Empty"))
		{
			
		}
		
		if(GUI.Button(selectRect[6], "Empty"))
		{
			
		}
		
		if(GUI.Button(selectRect[7], "Empty"))
		{
			
		}
		
		if(GUI.Button(selectRect[8], "Empty"))
		{
			
		}
	}
}
