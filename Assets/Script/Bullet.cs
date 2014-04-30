using UnityEngine;
using System;
using System.Collections;

public class Bullet : MonoBehaviour
{
	
	public const String BULLET_FROM_ENEMIE = "FromEnemieBullet";
	public const String BULLET_FROM_SHIP = "FromShipBullet";
	
	private Vector3 moveDirection;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine("BulletDelayDestroy"); // Destroy bullet after X seconds
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (moveDirection * Time.deltaTime * 10);
	}
    
    IEnumerator BulletDelayDestroy () {
    
    	yield return new WaitForSeconds(2.5f);
    	Destroy(this.gameObject);
    }
    
    public void setMoveDirection(Vector3 v) {
    	moveDirection = v;
    }
    
    void OnTriggerEnter(Collider other) {
		
		// destroy other side bullet
		if(other.name.Equals("Bullet")) { 
			Destroy(other.gameObject);
		}
	
		                    
    }
    
   
}
