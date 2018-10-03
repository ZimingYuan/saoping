using UnityEngine;
using UnityEngine.SceneManagement;

public class menuevent : MonoBehaviour {

    public static bool isbgmspawned = false;
    [SerializeField] private GameObject bgmprefab;
    public static AudioSource bgm;

    void Start() {
        if (!isbgmspawned) {
            isbgmspawned = true;
            bgm = Instantiate(bgmprefab).GetComponent<AudioSource>();
            bgm.volume = PlayerPrefs.GetFloat("volume");
            bgm.Play();
            DontDestroyOnLoad(bgm);
        }
    }

    public void single() {
        SceneManager.LoadScene("single");
    }

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
