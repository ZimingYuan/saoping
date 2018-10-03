using System.Collections;
using UnityEngine;

public class thunder : MonoBehaviour {

    private bool isdetroyed;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        if ((collider.name == "player1" && name == "redthunder")
         || (collider.name == "player2" && name == "bluethunder")) {
            collider.gameObject.GetComponent<player>().injured();
        }
    }

}