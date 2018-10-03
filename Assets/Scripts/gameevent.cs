using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class gameevent : MonoBehaviour {

    [SerializeField] private GameObject pmenu;
    [SerializeField] private GameObject pausebtn, continuebtn;
    [SerializeField] private GameObject player1, player2;
    [SerializeField] private Text win;
    [SerializeField] private bool issingle;

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
        if(issingle) SceneManager.LoadScene("single");
        else SceneManager.LoadScene("game");
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
        Destroy(player1);
        Destroy(player2);
        pmenu.SetActive(true);
        pausebtn.SetActive(false);
        continuebtn.SetActive(false);
        win.text = winplayer + "胜利！";
    }

}
