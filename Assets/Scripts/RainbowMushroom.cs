using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowMushroom : MonoBehaviour {

	public GameObject Ending;

	void OnCollisionEnter2D (Collision2D col2D) {
		if (col2D.gameObject.name == "Player") {
			StartEnding();
		}
	}

	void StartEnding () {
		Ending.SetActive(true);
	}
}
