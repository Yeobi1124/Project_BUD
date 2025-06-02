using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private PauseUISlider pauseUISlider;

    public void Awake()
    {
        pauseUISlider.Initialize();
    }

    public void ClickOpenMenu(){
        Pause.SetActive(false);
        PauseMenu.SetActive(true);
        pauseUISlider.UIShow();
    }

    public void ClickResume(){
        Pause.SetActive(true);
        pauseUISlider.UIHide();
        PauseMenu.SetActive(false);
    }

    public void ClickExit(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickRestart(){

    }

    public void ClickStart(){
        SceneManager.LoadScene("Stage");
    }

    public void ClickQuit(){
        Application.Quit();
    }
}
