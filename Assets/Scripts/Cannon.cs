using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public float delay;
	public float startDelay = 0;
	public float bulletSpeed;
	public GameObject Bullet;
	float delayCount;

	void Start () {
		delayCount = delay;
		Shoot();
	}

	void Update () {
		
		if (delayCount < 0) {
			Shoot();
		} 

		delayCount -= 0.1f;
	}

	void Shoot() {
		GameObject bullet = (GameObject)Instantiate(Bullet, transform.position, transform.rotation);
		Bullet bulletScript = bullet.GetComponent<Bullet>();
		bullet.transform.Translate(-Vector3.right * 0.1f);
		bulletScript.speed = bulletSpeed;
		delayCount = delay;
	}

}
