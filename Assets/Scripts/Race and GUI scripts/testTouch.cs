using UnityEngine;
using System.Collections;

public class testTouch : MonoBehaviour 
{
	public Texture testTexture;
	private GameObject testGUITexture;
	private Rect testRect = new Rect(200, 200, 1, 1);
	
	// Use this for initialization
	void Start () 
	{
		testGUITexture = new GameObject("testObject");
		testGUITexture.AddComponent("GUITexture");
		testGUITexture.guiTexture.texture = testTexture;
		testGUITexture.transform.localScale = new Vector3(.2f, .2f, .2f);
		testGUITexture.guiTexture.pixelInset = testRect;
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
			if(testGUITexture.guiTexture.HitTest(Input.mousePosition))
			{
				Debug.Log(testGUITexture.name);
			}
		}
	}
	
	/*void OnMouseDown()
	{
		Debug.Log(this.name);	
	}*/
}
