using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "walllr" || collider.name == "wallud") Destroy(gameObject);
        //Time.timeScale = 0;
        if ((collider.name == "player1" && name == "redbullet")
         || (collider.name == "player2" && name == "bluebullet")) {
            collider.gameObject.GetComponent<player>().injured();
            collider.gameObject.GetComponent<Rigidbody2D>().velocity += gameObject.GetComponent<Rigidbody2D>().velocity / 4;
            Destroy(gameObject);
        }
    }

}
