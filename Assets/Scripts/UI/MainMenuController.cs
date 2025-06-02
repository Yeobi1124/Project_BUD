using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ClickStart(){
        SceneManager.LoadScene("Stage");
    }

    public void ClickQuit(){
        Application.Quit();
    }
}
