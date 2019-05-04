using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidvaniaCamera : MonoBehaviour {

	BoxCollider2D cameraBox;
    Transform player;

    void Start () {
 
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
     
 
    }
 
	void Update () {
        FollowPlayer();
     
    }

    void FollowPlayer() {
        if (GameObject.Find("Boundary")) {
            transform.position = new Vector3(Mathf.Clamp(player.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2),
        	Mathf.Clamp(player.position.y, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2),
            transform.position.z);
         
        }
    }

	
}
