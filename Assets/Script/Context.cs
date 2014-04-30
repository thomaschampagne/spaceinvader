using UnityEngine;
using System.Collections;

public class Context : MonoBehaviour {
	
	public enum GameState {
		MainMenu,
		InGame
	}
	
	private PrefabsFactory prefabsFactory;
	private GameManager gameManager;
	public static GameState gameState;
	
	void Awake () {
		
		Application.targetFrameRate = 100;
		Debug.Log ("Starting game, framerate: " + Application.targetFrameRate + ", unityVersion: " + Application.unityVersion + ", running plateform:" + Application.platform);
		
		prefabsFactory = GetComponent<PrefabsFactory>();
		gameManager = GetComponent<GameManager>();
		
		gameState = GameState.MainMenu;
		
		DontDestroyOnLoad(this);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public PrefabsFactory PrefabsFactory {
		get {
			return this.prefabsFactory;
		}
		set {
			prefabsFactory = value;
		}
	}	

	public GameManager GameManager {
		get {
			return this.gameManager;
		}
		set {
			gameManager = value;
		}
	}
	
	void startTheGame () {
		Application.LoadLevel("Main");
	} 

	void OnLevelWasLoaded(int level) {
		
		Debug.Log(level + " loadded");
		
		if(level == 1) {
			gameManager.setupGame();
			gameState = GameState.InGame;	
		} else if (level == 2) {
			gameState = GameState.MainMenu;
		}
	}
	
	// Le context gere pour le moment les aspect de GUI
	
	void OnGUI () {
	/*
			if (GUI.Button (new Rect (25, 200, 100, 30), "go main")) {
				// This code is executed when the Button is clicked
				Application.LoadLevel("Main");
			}
					if (GUI.Button (new Rect (25, 250, 100, 30), "go Bootstrap")) {
				// This code is executed when the Button is clicked
				Application.LoadLevel("Menu");
			}*/
		
		if (gameManager.paused) {
			
			if (GUI.Button (new Rect (25, 20, 100, 30), "Resume game")) {
				// This code is executed when the Button is clicked
				gameManager.OnResumeGame();
			}
			
			if (GUI.Button (new Rect (25, 60, 100, 30), "Main menu")) {
				// This code is executed when the Button is clicked
				gameManager.OnResumeGame();
				Application.LoadLevel ("Menu");
				
			}
			
			if (GUI.Button (new Rect (25, 100, 100, 30), "Quit")) {
				// This code is executed when the Button is clicked
				Application.Quit ();
			}
		}
		
		if(gameState == Context.GameState.MainMenu) {
			
			if (GUI.Button (new Rect (25, 25, 100, 30), "Start")) {
				// This code is executed when the Button is clicked
				startTheGame();
			}
			
			if (GUI.Button (new Rect (25, 100, 100, 30), "Quit")) {
				// This code is executed when the Button is clicked
				Application.Quit();
			}
		}
	}
}
