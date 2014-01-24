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
			
			GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), "Name:");
			playerName = GUI.TextField(new Rect (boxLeft + border, boxTop + border + lineHeight, boxWidth - border*2, lineHeight), playerName);
			
			if(GUI.Button (new Rect(boxLeft, boxTop + boxHeight + border, 200, 50), "Host Game")) {	
				menu = Menu.HostGame;
			}
			
			if(GUI.Button (new Rect(boxLeft, boxTop + boxHeight + border + 60, 200, 50), "Join Game")) {
				menu = Menu.JoinGame;
			}

		}

		else if(menu == Menu.HostGame) {

			int boxWidth = 200;
			int boxHeight = 80;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;
			int border = 10;
			int lineHeight = 24;
			
			GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), "Game Name:");
			gameName = GUI.TextField(new Rect (boxLeft + border, boxTop + border + lineHeight, boxWidth - border*2, lineHeight), gameName);
			
			if(GUI.Button (new Rect(boxLeft, boxTop + boxHeight + border, 200, 50), "Create Game")) {	
				menu = Menu.Lobby;
				networkHandler.HostGame(gameName, playerName);
			}

		}

		else if(menu == Menu.JoinGame) {

			int boxWidth = 200;
			int boxHeight = 80;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;
			int border = 10;
			int lineHeight = 24;
			
			GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), "Game Name:");
			gameName = GUI.TextField(new Rect (boxLeft + border, boxTop + border + lineHeight, boxWidth - border*2, lineHeight), gameName);
			
			if(GUI.Button (new Rect(boxLeft, boxTop + boxHeight + border, 200, 50), "Join Game")) {	
				menu = Menu.Connecting;
				networkHandler.JoinGame(gameName, playerName);
			}
			
			if(GUI.Button (new Rect(boxLeft, boxTop + boxHeight + border + 60, 200, 50), "Random")) {
				menu = Menu.Connecting;
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
			
			GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), "Finding Game");
			
			GUI.Label(new Rect(boxLeft + border, boxTop + lineHeight*2, boxWidth - border*2, lineHeight), GetConnectionState());
			
			if (GUI.Button (new Rect(boxLeft + boxWidth/2 - buttonWidth/2, boxTop + boxHeight - buttonHeight - border, buttonWidth, buttonHeight), "Cancel")) {
				networkHandler.LeaveGame();
				menu = Menu.Main;
			}
			
			if(networkHandler.GetConnectionStatus() == NetworkGameHandler.ConnectionState.InLobby) {
				menu = Menu.Lobby;
			}
		}

		else if(menu == Menu.Lobby) {

			int boxWidth = 200;
			int boxHeight = 80;
			int boxLeft = Screen.width/2 - boxWidth/2;
			int boxTop = Screen.height/2 - boxHeight/2;
			int border = 10;
			int lineHeight = 24;

			GUI.Box(new Rect(boxLeft, boxTop - 180, boxWidth, boxHeight), networkHandler.GetPlayerName(0));
			GUI.Box(new Rect(boxLeft, boxTop - 90, boxWidth, boxHeight), networkHandler.GetPlayerName(1));
			GUI.Box(new Rect(boxLeft, boxTop, boxWidth, boxHeight), networkHandler.GetPlayerName(2));
			GUI.Box(new Rect(boxLeft, boxTop + 90, boxWidth, boxHeight), networkHandler.GetPlayerName(3));
			GUI.Box(new Rect(boxLeft, boxTop + 180, boxWidth, boxHeight), networkHandler.GetPlayerName(4));
			GUI.Box(new Rect(boxLeft, boxTop + 270, boxWidth, boxHeight), networkHandler.GetPlayerName(5));
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
