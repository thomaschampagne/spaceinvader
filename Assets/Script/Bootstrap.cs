using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour {

	public GameObject context;
	
	// Use this for initialization
	void Start () {
		context = (GameObject) Instantiate(context);
		context.name = "Context";
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
