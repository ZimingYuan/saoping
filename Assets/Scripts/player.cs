using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    [SerializeField] private KeyCode shoot;
    [SerializeField] private GameObject mybullet, mybomb, gamelogic, explode;
    [SerializeField] private gameevent gameevent;
    private int lives, tdrem, sprem;
    private string state;

    void Start () {
        lives = 3;
        state = "0normal";
        tdrem = 3;
        sprem = 2;
	}
	
	void Update () {
        if (Input.GetKeyDown(shoot)) {
            Quaternion q = transform.rotation;
            Vector3 v = q * (new Vector3(1, 0)); //direction vector
            GetComponent<Rigidbody2D>().velocity = - 4 * v; // contract direction force
            GetComponent<Rigidbody2D>().angularVelocity = 90; // change angel
            gamelogic.GetComponent<gamelogic>().shoot.Play();
            if (state == "0normal") {
                GameObject newbullet = Instantiate(mybullet);
                newbullet.name = mybullet.name;
                newbullet.transform.position = transform.position;
                newbullet.transform.rotation = transform.rotation;
                newbullet.GetComponent<Rigidbody2D>().velocity = 12 * v;
            }
            if (state == "0bomb") {
                GameObject newbomb = Instantiate(mybomb);
                newbomb.name = mybomb.name;
                newbomb.transform.position = transform.position;
                newbomb.GetComponent<Rigidbody2D>().velocity = 12 * v;
                state = "0normal";
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "net") {
            GetComponent<Rigidbody2D>().drag = 1.5f;
        }
        if (collider.name[0] == '0') { // eat buff(not including recover)
            state = collider.name;
            gamelogic.GetComponent<gamelogic>().resisdestroyed = true;
            Destroy(collider.gameObject);
            gamelogic.GetComponent<gamelogic>().eat.Play();
        }
        if (collider.name == "recover") {
            gamelogic.GetComponent<gamelogic>().resisdestroyed = true;
            Destroy(collider.gameObject);
            recover();
            gamelogic.GetComponent<gamelogic>().eat.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.name == "net") {
            GetComponent<Rigidbody2D>().drag = 0.3f;
        }
    }

    void OnCollisionEnter2D(Collision2D collider) {
        if(collider.gameObject.name == "walllr" || collider.gameObject.name == "wallud")
            gamelogic.GetComponent<gamelogic>().collision.Play();
    }

    public void recover() {
        if(lives < 3) {
            lives++;
            Color c = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, c.a + 0.333f);
        }
    }

    public void injured() {
        lives--;
        Color c = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, c.a - 0.333f);
        if(lives == 0) {
            Instantiate(explode, transform);
            StartCoroutine(gameevent.gameover(name == "player1" ? "红瓶" : "蓝瓶"));
            gamelogic.GetComponent<gamelogic>().explode.Play();
        }else gamelogic.GetComponent<gamelogic>().impact.Play();
    }

}
