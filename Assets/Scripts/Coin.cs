using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public SpriteRenderer playerSR;
	public Player playerScript;
	public Sprite ManWithCoin;
	public Sprite Man;

	void Start () {
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		playerSR = GameObject.Find("Player").GetComponent<SpriteRenderer>();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "Player") {
			playerSR.sprite = ManWithCoin;
			gameObject.SetActive(false);
			playerScript.coin = gameObject;
		}
	}

}
