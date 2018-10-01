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
        if (collider.gameObject.name == "wall") GameObject.Destroy(gameObject, 0.1f);
        if ((collider.gameObject.name == "player1" && gameObject.name == "redbullet")
         || (collider.gameObject.name == "player2" && gameObject.name == "bluebullet")) {
            collider.gameObject.GetComponent<player>().injured();
            GameObject.Destroy(gameObject, 0.1f);
        }
    }

}
