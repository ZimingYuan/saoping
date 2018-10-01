using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    [SerializeField] private KeyCode shoot;
    [SerializeField] private GameObject mybullet;
    private int lives;

    void Start () {
        lives = 3;
	}
	
	void Update () {
        if (Input.GetKeyDown(shoot)) {
            Quaternion q = transform.rotation;
            Vector3 v = q * (new Vector3(1, 0, 0));
            GetComponent<Rigidbody2D>().velocity = - 3 * v;
            GetComponent<Rigidbody2D>().angularVelocity = 90;
            GameObject newbullet = Instantiate(mybullet);
            newbullet.name = mybullet.name;
            newbullet.transform.position = transform.position;
            newbullet.transform.rotation = transform.rotation;
            newbullet.GetComponent<Rigidbody2D>().velocity = 12 * v;
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "net") {
            GetComponent<Rigidbody2D>().drag = 1.5f;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.name == "net") {
            GetComponent<Rigidbody2D>().drag = 0.4f;
        }
    }

    public void injured() {

    }

}
