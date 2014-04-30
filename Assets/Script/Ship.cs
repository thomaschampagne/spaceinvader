using UnityEngine;
using System.Collections;
using System;

public class Ship : MonoBehaviour
{
	public 	String h;
	public 	float speed;
	private float axisH;
	private Vector3 moveDirection;
	private static float fireTimeDeadZone = 1.0f;
	private float nextTimeFire;

	private Context ctx;
	
	void Awake ()
	{
		ctx = GameObject.Find ("Context").GetComponent<Context>();
	}
	
	// Use this for initialization
	void Start ()
	{
		moveDirection = new Vector3 (0, 0, 0);
	}

	// Update is called once per frame
	void Update ()
	{
		
		axisH = Input.GetAxis ("Horizontal");
		moveDirection.x = axisH;
		transform.Translate (moveDirection * Time.deltaTime * speed);
		
		//lastFireTime = Time.time;
		
		if (Input.GetKeyDown ("space")) { 
		
			if(Time.time > nextTimeFire) {
			
				GameObject bullet = (GameObject) Instantiate (	ctx.PrefabsFactory.BulletPrefab,
																transform.position,
																Quaternion.identity);
				
				bullet.tag = Bullet.BULLET_FROM_SHIP;
				bullet.GetComponent<Bullet>().setMoveDirection(Vector3.up);	// Or bullet.BroadcastMessage("setMoveDirection", Vector3.up);
				bullet.name = "Bullet";
				nextTimeFire = Time.time + fireTimeDeadZone;
			}
		}
	}
	
	
	void OnTriggerEnter(Collider other) {
		if(!other.tag.Equals(Bullet.BULLET_FROM_SHIP)) {
			Destroy(this.gameObject); // Delete myself as ship
			Destroy(other.gameObject); // Delete bullet
			ctx.GameManager.BroadcastMessage("restartGame");
		}
    }
}

