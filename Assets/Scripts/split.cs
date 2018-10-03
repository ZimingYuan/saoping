using System.Collections;
using UnityEngine;

public class split : MonoBehaviour {

    [SerializeField] private GameObject bullet;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        // split into 5 bullets running towards five directions when it hits the wall
        GameObject[] spbullet = new GameObject[5];
        if (collider.name == "walllr") {
            for (int i = 0; i < 5; i++) {
                spbullet[i] = Instantiate(bullet);
                spbullet[i].name = bullet.name;
                spbullet[i].transform.position = transform.position;
            }
            Vector3 v = GetComponent<Rigidbody2D>().velocity;
            if(v.x >= 0) {
                for(int i = 0; i < 5; i++) {
                    spbullet[i].transform.Translate(new Vector3(-0.5f, 0));
                    //prevent the bullet from being destroyed at once because it is next to the wall 
                    //Cautious: translating should be before rotating because translating is according to the local coordinate in spite of global coordinate.
                    Quaternion q = new Quaternion();
                    q.eulerAngles = new Vector3(0, 0, 90 + i * 45);
                    spbullet[i].transform.rotation = q;
                    spbullet[i].GetComponent<Rigidbody2D>().velocity = q * new Vector3(12, 0);
                }
            }
            else {
                for (int i = 0; i < 5; i++) {
                    spbullet[i].transform.Translate(new Vector3(0.5f, 0));
                    Quaternion q = new Quaternion();
                    q.eulerAngles = new Vector3(0, 0, -90 + i * 45);
                    spbullet[i].transform.rotation = q;
                    spbullet[i].GetComponent<Rigidbody2D>().velocity = q * new Vector3(12, 0);
                }
            }
            Destroy(gameObject);
        }
        if (collider.name == "wallud") {
            for (int i = 0; i < 5; i++) {
                spbullet[i] = Instantiate(bullet);
                spbullet[i].name = bullet.name;
                spbullet[i].transform.position = transform.position;
            }
            Vector3 v = GetComponent<Rigidbody2D>().velocity;
            if (v.y >= 0) {
                for (int i = 0; i < 5; i++) {
                    spbullet[i].transform.Translate(new Vector3(0, -0.5f));
                    Quaternion q = new Quaternion();
                    q.eulerAngles = new Vector3(0, 0, 180 + i * 45);
                    spbullet[i].transform.rotation = q;
                    spbullet[i].GetComponent<Rigidbody2D>().velocity = q * new Vector3(12, 0);
                }
            }
            else {
                for (int i = 0; i < 5; i++) {
                    spbullet[i].transform.Translate(new Vector3(0, 0.5f));
                    Quaternion q = new Quaternion();
                    q.eulerAngles = new Vector3(0, 0, i * 45);
                    spbullet[i].transform.rotation = q;
                    spbullet[i].GetComponent<Rigidbody2D>().velocity = q * new Vector3(12, 0);
                }
            }
            Destroy(gameObject);
        }
        if ((collider.name == "player1" && name == "redsplit")
         || (collider.name == "player2" && name == "bluesplit")) {
            collider.gameObject.GetComponent<player>().injured();
            collider.gameObject.GetComponent<Rigidbody2D>().velocity += GetComponent<Rigidbody2D>().velocity / 4;
            Destroy(gameObject);
        }
    }

}