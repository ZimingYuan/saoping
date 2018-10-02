using System.Collections;
using UnityEngine;

public class bomb : MonoBehaviour {

    private bool isdetroyed;
    
    // Use this for initialization
    void Start() {
        isdetroyed = false;
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        //Since this is a trigger, I have to write the bounce method by myself.
        if (collider.name == "walllr") {
            Vector3 v = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector3(-v.x, v.y);
        }
        if (collider.name == "wallud") {
            Vector3 v = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector3(v.x, -v.y);
        }
        if ((collider.name == "player1" && name == "redbomb")
         || (collider.name == "player2" && name == "bluebomb")) {
            collider.gameObject.GetComponent<player>().injured();
            collider.gameObject.GetComponent<Rigidbody2D>().velocity += GetComponent<Rigidbody2D>().velocity / 4;
            isdetroyed = true;
            Destroy(gameObject);
        }
    }

    private IEnumerator destroy() {
        yield return new WaitForSeconds(3);
        if (!isdetroyed) {
            isdetroyed = true;
            Destroy(gameObject);
        }
    }

}