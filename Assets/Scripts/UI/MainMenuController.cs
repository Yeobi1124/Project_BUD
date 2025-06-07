using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject gameInfoUI;

    private void Awake()
    {
        ClearScreen();
    }

    public void ClickStart(){
        SceneManager.LoadScene("Stage");
    }

    public void ClickInfo()
    {
        gameInfoUI.SetActive(true);
    }

    public void ClickQuit(){
        ClearScreen();
        Application.Quit();
    }

    public void ClearScreen()
    {
        gameInfoUI.SetActive(false);
    }
}
