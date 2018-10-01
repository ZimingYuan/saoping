using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingevent : MonoBehaviour {

    [SerializeField] private Slider volcon;

    void Start() {
        volcon.value = PlayerPrefs.GetFloat("volume", 1);
    }

    public void save() {
        PlayerPrefs.SetFloat("volume", volcon.value);
        SceneManager.LoadScene("menu");
    }

}
