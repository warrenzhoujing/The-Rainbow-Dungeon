using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroidvaniaCamera : MonoBehaviour {

	BoxCollider2D cameraBox;
    Transform player;
    Player playerScript;
    SpriteRenderer playerSpriteR;
    public GameObject coin;
    float spawnsMade;
    public CoinManager coinManager;
    public Sprite Man;

    void Start () {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerScript = player.gameObject.GetComponent<Player>();
        playerSpriteR = player.gameObject.GetComponent<SpriteRenderer>();

        spawnsMade = 0;
    }
 
	void Update () {
        FollowPlayer();
    }

    void FollowPlayer() {
        if (GameObject.Find("Boundary")) {
            Vector3 newCamPosition = new Vector3(Mathf.Clamp(player.position.x, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2),
        	Mathf.Clamp(player.position.y, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2),
            transform.position.z);
            
            if (newCamPosition != transform.position) {
                playerScript.startPosition = playerScript.gameObject.transform.position;
                spawnsMade ++;

                if (spawnsMade > 0) {
                    playerScript.coin = null;
                    Destroy(coin);
                    coinManager.coins ++;
                    playerSpriteR.sprite = Man;
                }
                
            }

            transform.position = newCamPosition;
         
        }
    }

	
}
