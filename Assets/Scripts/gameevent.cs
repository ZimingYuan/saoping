using UnityEngine;
using UnityEngine.SceneManagement;

public class gameevent : MonoBehaviour {

    [SerializeField] private GameObject pmenu;
    [SerializeField] private GameObject pausebtn;

    public void pause() {
        pmenu.SetActive(true);
        pausebtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void _continue() {
        pmenu.SetActive(false);
        pausebtn.SetActive(true);
        Time.timeScale = 1;
    }

    public void regame() {
        SceneManager.LoadScene("game");
    }

    public void _return() {
        SceneManager.LoadScene("menu");
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space)) {
            pause();
        }
    }

}
