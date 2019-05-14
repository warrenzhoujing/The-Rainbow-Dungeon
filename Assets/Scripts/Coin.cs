using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public SpriteRenderer playerSR;
	public Player playerScript;
	public Sprite ManWithCoin;
	public MetroidvaniaCamera mc;

	void Start () {
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		playerSR = GameObject.Find("Player").GetComponent<SpriteRenderer>();
		mc = GameObject.Find("Main Camera").GetComponent<MetroidvaniaCamera>();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "Player") {
			playerSR.sprite = ManWithCoin;
			gameObject.SetActive(false);
			playerScript.coin = gameObject;
			mc.coin = gameObject;
		}
	}

}
