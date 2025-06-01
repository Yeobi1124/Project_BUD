using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Pause;
    public GameObject PauseMenu;

    public void ClickOpenMenu(){
        Pause.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void ClickResume(){
        Pause.SetActive(true);
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
