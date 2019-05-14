using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public LayerMask destroyAt;

	void Start () {
		if (speed > 10000) {
			speed = 10000;
		}
	}
	
	void Update () {
		transform.Translate(speed * -Vector3.right * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (destroyAt == (destroyAt | (1 << col.gameObject.layer))){
			Destroy(gameObject);
		}
	}
}
