using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Transform networkHandlerObject;
	private NetworkGameHandler networkHandler;

	// Menu states
	enum Menu { Main, HostGame, JoinGame, Connecting, Lobby, InGame };
	private Menu menu = Menu.Main;
	
	private string playerName = "";
	private string gameName = "";

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		networkHandler = networkHandlerObject.GetComponent("NetworkGameHandler") as NetworkGameHandler;
	}
	
	// Update is called once per frame
	void Update () {
		if (menu != Menu.Main && menu != Menu.JoinGame && menu != Menu.HostGame) {
			if(networkHandler.GetConnectionStatus() == NetworkGameHandler.ConnectionState.Disconnected) {
				menu = Menu.Main;
			}
		}
	}

	// Draw GUI elements
	void OnGUI () {	

		if(menu == Menu.Main) {

			int boxWidth = 200;
			int boxHeight = 80;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;
			int border = 10;
			int lineHeight = 24;
			
			GUI.Box(new Rect(boxLeft, boxTop - boxHeight, boxWidth, boxHeight), "Name:");
			playerName = GUI.TextField(new Rect (boxLeft + border, boxTop - boxHeight + border + lineHeight, boxWidth - border*2, lineHeight), playerName);
			
			if(GUI.Button (new Rect(boxLeft, boxTop + border, 200, 50), "Host Game")) {	
				if(playerName != ""){
					menu = Menu.HostGame;
				}
			}
			
			if(GUI.Button (new Rect(boxLeft, boxTop + border + 60, 200, 50), "Join Game")) {
				if(playerName != ""){
					menu = Menu.JoinGame;
				}
			}

		}

		else if(menu == Menu.HostGame) {

			int boxWidth = 200;
			int boxHeight = 80;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;
			int border = 10;
			int lineHeight = 24;
			
			GUI.Box(new Rect(boxLeft, boxTop - boxHeight, boxWidth, boxHeight), "Game Name:");
			gameName = GUI.TextField(new Rect (boxLeft + border, boxTop - boxHeight + border + lineHeight, boxWidth - border*2, lineHeight), gameName);
			
			if(GUI.Button (new Rect(boxLeft, boxTop + border, 200, 50), "Create Game")) {
				if(gameName != ""){
					networkHandler.HostGame(gameName, playerName);
					menu = Menu.Lobby;
				}
			}

			if(GUI.Button (new Rect(border, Screen.height - 50 - border, boxWidth, 50), "Back")) {
				menu = Menu.Main;
			}

		}

		else if(menu == Menu.JoinGame) {

			int boxWidth = 200;
			int boxHeight = 80;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;
			int border = 10;
			int lineHeight = 24;
			
			GUI.Box(new Rect(boxLeft, boxTop - boxHeight, boxWidth, boxHeight), "Game Name:");
			gameName = GUI.TextField(new Rect (boxLeft + border, boxTop - boxHeight + border + lineHeight, boxWidth - border*2, lineHeight), gameName);
			
			if(GUI.Button (new Rect(boxLeft, boxTop + border, 200, 50), "Join Game")) {	
				menu = Menu.Connecting;
				networkHandler.JoinGame(gameName, playerName);
			}
			
			//if(GUI.Button (new Rect(boxLeft, boxTop + border + 60, 200, 50), "Join Random Game")) {
			//	menu = Menu.Connecting;
			//}

			if(GUI.Button (new Rect(border, Screen.height - 50 - border, boxWidth, 50), "Back")) {
				menu = Menu.Main;
			}
		}

		else if(menu == Menu.Connecting) {
			int boxWidth = 200;
			int boxHeight = 100;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;		
			int border = 10;	
			
			int lineHeight = 22;
			int buttonWidth = 80;
			int buttonHeight = 20;
			
			GUI.Box(new Rect(boxLeft, boxTop - 80, boxWidth, boxHeight), "Finding Game");
			
			GUI.Label(new Rect(boxLeft + border, boxTop - 80 + lineHeight*2, boxWidth - border*2, lineHeight), GetConnectionState());
			
			if (GUI.Button (new Rect(boxLeft + boxWidth/2 - buttonWidth/2, boxTop - 80 + boxHeight - buttonHeight - border, buttonWidth, buttonHeight), "Cancel")) {
				networkHandler.LeaveGame();
				menu = Menu.Main;
			}
			
			if(networkHandler.GetConnectionStatus() == NetworkGameHandler.ConnectionState.InLobby) {
				menu = Menu.Lobby;
			}
		}

		else if(menu == Menu.Lobby) {

			float boxWidth = Screen.width*.4f;
			float boxHeight = Screen.height*.125f;
			float boxTop = Screen.height/2 - boxHeight/2;
			float borderVertical = Screen.height*.015f;
			float borderHorizontal = Screen.width*.015f;
			int lineHeight = 24;

			GUI.Box(new Rect(Screen.width - boxWidth - borderHorizontal, Screen.height - boxHeight*5 - borderVertical*5, boxWidth, boxHeight), networkHandler.GetPlayerName(1));
			GUI.Box(new Rect(Screen.width - boxWidth - borderHorizontal, Screen.height - boxHeight*4 - borderVertical*4, boxWidth, boxHeight), networkHandler.GetPlayerName(2));
			GUI.Box(new Rect(Screen.width - boxWidth - borderHorizontal, Screen.height - boxHeight*3 - borderVertical*3, boxWidth, boxHeight), networkHandler.GetPlayerName(3));
			GUI.Box(new Rect(Screen.width - boxWidth - borderHorizontal, Screen.height - boxHeight*2 - borderVertical*2, boxWidth, boxHeight), networkHandler.GetPlayerName(4));
			GUI.Box(new Rect(Screen.width - boxWidth - borderHorizontal, Screen.height - boxHeight - borderVertical, boxWidth, boxHeight), networkHandler.GetPlayerName(5));

			if(GUI.Button (new Rect(Screen.width - boxWidth*1.5f - borderHorizontal, Screen.height*.02f, boxWidth*1.5f, boxHeight*2.1f), networkHandler.GetPlayerName(0))){

			}

			if(Network.isServer){
				if(GUI.Button (new Rect(borderHorizontal, Screen.height*.3f, Screen.width*.56f, Screen.height*.55f), "Map Select")){

				}
			}

			else{
				GUI.Box (new Rect(borderHorizontal, Screen.height*.3f, Screen.width*.56f, Screen.height*.55f), "Map Select");
			}

			if(GUI.Button (new Rect(borderHorizontal, Screen.height - Screen.height*.1f - borderVertical, Screen.width*.15f, Screen.height*.1f), "Leave Game")) {
				networkHandler.LeaveGame();
				menu = Menu.Main;
			}
		}

		else if(menu == Menu.InGame) {
		}

	}

	string GetConnectionState() {
		string connectionStatusString = "";
		var connectionStatus = networkHandler.GetConnectionStatus();
		if(connectionStatus == NetworkGameHandler.ConnectionState.Disconnected)
			connectionStatusString = "Disconnected";
		else if(connectionStatus == NetworkGameHandler.ConnectionState.Connecting)
			connectionStatusString = "Joining Game";
		else if(connectionStatus == NetworkGameHandler.ConnectionState.Looking)
			connectionStatusString = "Looking for game";
		return connectionStatusString;
	}
}
