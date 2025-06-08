using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject gameInfoUI;
    [SerializeField] GameObject mainLogoFrontUI;
    [SerializeField] Animator mainLogoAnimator;
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
