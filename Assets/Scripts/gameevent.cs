using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class gameevent : MonoBehaviour {

    [SerializeField] private GameObject pmenu;
    [SerializeField] private GameObject pausebtn, continuebtn;
    [SerializeField] private Text win;

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

    public IEnumerator gameover(string winplayer) {
        yield return new WaitForSeconds(1.4f);
        pmenu.SetActive(true);
        pausebtn.SetActive(false);
        Time.timeScale = 0;
        continuebtn.SetActive(false);
        win.text = winplayer + "胜利！";
    }

}
