using UnityEngine;
using System.Collections;

public class gamelogic : MonoBehaviour {

    public bool resisdestroyed;
    private bool shouldspawn;
    [SerializeField] private GameObject bomb, recover, split, thunder, walll, wallr;
    private GameObject temp;
    private System.Random rnd;
    [SerializeField] public AudioSource eat, impact, shoot, explode, collision;

    void Start () {
        Time.timeScale = 1;
        resisdestroyed = true;
        shouldspawn = false;
        rnd = new System.Random();
        StartCoroutine(prespawn());
        StartCoroutine(wallmove());
        eat.volume = impact.volume = shoot.volume = explode.volume = collision.volume = PlayerPrefs.GetFloat("volume");
    }
	
	void Update () {
        if (shouldspawn) {
            resisdestroyed = false;
            shouldspawn = false;
            int a = 0; // rnd.Next(4);
            switch (a) {
                case 0:
                    temp = Instantiate(bomb);
                    temp.name = "0bomb";
                    break;
                case 1:
                    temp = Instantiate(split);
                    temp.name = "0split";
                    break;
                case 2:
                    temp = Instantiate(thunder);
                    temp.name = "0thunder";
                    break;
                case 3:
                    temp = Instantiate(recover);
                    temp.name = "recover";
                    break;
            }
            StartCoroutine(prespawn());
        }
        if (walll.transform.position.x > -3 || wallr.transform.position.x < 3)
            walll.GetComponent<Rigidbody2D>().velocity = wallr.GetComponent<Rigidbody2D>().velocity = new Vector3();
    }

    private IEnumerator prespawn() {
        yield return new WaitForSeconds(5);
        if (! resisdestroyed) {
            resisdestroyed = true;
            Destroy(temp);
        }
        shouldspawn = true;
    }

    private IEnumerator wallmove() {
        yield return new WaitForSeconds(60);
        walll.GetComponent<Rigidbody2D>().velocity = new Vector3(0.1f, 0);
        wallr.GetComponent<Rigidbody2D>().velocity = new Vector3(-0.1f, 0);
    }

}
