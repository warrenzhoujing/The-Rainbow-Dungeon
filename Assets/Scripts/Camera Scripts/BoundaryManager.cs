using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour {

	BoxCollider2D managerBox;
	Transform player;
	public GameObject Boundary;

	void Start () {
		managerBox = GetComponent<BoxCollider2D>();
		player = GameObject.Find("Player").GetComponent<Transform>();
	}

	void Update () {
		ManageBoundary();
	}

	void ManageBoundary () {
		if (managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x 
		&& managerBox.bounds.min.y < player.position.y && player.position.y< managerBox.bounds.max.y) {
			Boundary.SetActive(true);
		} else {
			Boundary.SetActive(false);
		}
	}
}
