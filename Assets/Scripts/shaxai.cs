using UnityEngine;

public class shaxai : MonoBehaviour {

    public bool airun;
    [SerializeField] GameObject aiplayer, hmplayer;

    void Start () {
        airun = false;
	}
	
	void Update () {
        if (aiplayer != null) {
            if (aiplayer.GetComponent<Rigidbody2D>().angularVelocity < 15) {
                airun = true;
            }
            float a = Vector3.Angle(hmplayer.transform.position - aiplayer.transform.position, aiplayer.transform.rotation * new Vector3(1, 0));
            if (a < 10 || a > 170) airun = true;
        }
	}
}
