using UnityEngine;
using UnityEngine.SceneManagement;

public class menuevent : MonoBehaviour {

	public void play() {
        SceneManager.LoadScene("game");
    }

    public void settings() {
        SceneManager.LoadScene("settings");
    }

    public void exit() {
        Application.Quit();
    }

}
