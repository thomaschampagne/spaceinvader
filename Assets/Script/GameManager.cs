using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	private Context ctx;
	
	
	public List<GameObject> enemiesList;
	private float nextEnemieFire;
	private System.Random random;
	
	public bool paused;

	void Awake ()
	{

		ctx = GetComponent<Context>();
		enemiesList = new List<GameObject> ();
		
		random = new System.Random ();
		
	}


	// Use this for initialization
	void Start ()
	{
		//setupGame ();
		
		
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (Time.time > nextEnemieFire) {
			
			if (enemiesList.Count > 1) {
				GameObject g = enemiesList[random.Next (0, enemiesList.Count)].gameObject;
				
				if(g != null) {
					g.SendMessage ("Fire");	
					nextEnemieFire = Time.time + 0.8f;
				}
	
				
			} else {
				// Game finish, reload enemies
				restartGame ();
			}
			
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)) {			
			if (!paused) {
				OnPauseGame ();
			} else {
				OnResumeGame ();
			}

		}
	}		
	
	public void setupGame ()
	{
		setupShip ();
		populateEnemies (new Vector3 (-10, 16, 0), new Vector2 (10, 3), new Vector2 (2, 2));
	}

	void restartGame ()
	{
		
		// Clean enemies
		foreach (GameObject e in enemiesList) {
			Destroy (e);
			enemiesList = new List<GameObject> ();
		}
		
		// Clean ship
		Destroy (GameObject.Find ("Ship"));
		setupGame ();
	}

	public void OnPauseGame ()
	{
		paused = true;
		Time.timeScale = 0;
	}

	public void OnResumeGame ()
	{
		paused = false;
		Time.timeScale = 1;
	}

	public void setupShip ()
	{
		GameObject s = (GameObject)Instantiate (ctx.PrefabsFactory.ShipPrefab, Vector3.zero, Quaternion.identity);
		s.name = "Ship";
	}

	public void populateEnemies (Vector3 startPoint, Vector2 matrixSize, Vector2 padding)
	{
		
		if(ctx.PrefabsFactory.EnemiePrefab == null) {
			Debug.Log("factory is null");
		}
		
		float enemiePosX = startPoint.x;
		float enemiePosY = startPoint.y;
		
		GameObject enemieRoot = new GameObject("enemieRoot");
		
		for (int i = 0; i < matrixSize.x; i++) {
			
			enemiePosY = startPoint.y;
			
			for (int j = 0; j < matrixSize.y; j++) {
				
				GameObject e = (GameObject) Instantiate (ctx.PrefabsFactory.EnemiePrefab, new Vector3 (enemiePosX, enemiePosY, 0), Quaternion.identity);
				enemiePosY -= padding.y;
				enemiesList.Add (e);
				
				e.transform.parent = enemieRoot.transform;
			
			}
			enemiePosX += padding.x;
		}
		Debug.Log ("End setup enemies");
	}

	void OnApplicationQuit ()
	{
		Debug.Log ("Bye Bye: " + this.gameObject.name);
	}

	void OnGUI ()
	{
		

	}
	
}
