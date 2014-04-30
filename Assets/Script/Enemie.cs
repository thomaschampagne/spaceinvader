using UnityEngine;
using System.Collections;

public class Enemie : MonoBehaviour {
	
	private Context ctx;
	
	void Awake ()
	{
		ctx = GameObject.Find ("Context").GetComponent<Context>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other) {
	
		if(!other.tag.Equals(Bullet.BULLET_FROM_ENEMIE)) {
			
			Destroy(this.gameObject); // Delete myself as enemie
			Destroy(other.gameObject); // Delete bullet
			
			ctx.GameManager.enemiesList.Remove(this.gameObject); // delete enemie from list
			
		}
    }
    
    public void Fire() {
 
			GameObject bullet = (GameObject) Instantiate (	ctx.PrefabsFactory.BulletPrefab,
															transform.position,
															Quaternion.identity);
														
			bullet.tag = Bullet.BULLET_FROM_ENEMIE;
			bullet.name = "Bullet";
			bullet.GetComponent<Bullet>().setMoveDirection(Vector3.down);	// Or bullet.BroadcastMessage("setMoveDirection", Vector3.down);
    
    }
}
