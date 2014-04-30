using UnityEngine;
using System.Collections;

public class PrefabsFactory : MonoBehaviour {

	public GameObject shipPrefab;
	public GameObject enemiePrefab;
	public GameObject bulletPrefab;

	public GameObject BulletPrefab {
		get {
			return this.bulletPrefab;
		}
		set {
			bulletPrefab = value;
		}
	}

	public GameObject EnemiePrefab {
		get {
			return this.enemiePrefab;
		}
		set {
			enemiePrefab = value;
		}
	}

	public GameObject ShipPrefab {
		get {
			return this.shipPrefab;
		}
		set {
			shipPrefab = value;
		}
	}
	
	// Use this for initi	alization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
