using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject gameInfoUI;
    [SerializeField] GameObject gameStartFolder;
    private Animator gameStartAnimator;
    [SerializeField] private float waitTime;
    private void Awake()
    {
        ClearScreen();
        gameStartAnimator = gameStartFolder.GetComponent<Animator>();
    }

    public void GameStartAnim()
    {
        gameStartFolder.SetActive(true);
        gameStartAnimator.SetTrigger("GameStart");
        StartCoroutine(WaitAndStartFirstScene(waitTime));
    }

    IEnumerator WaitAndStartFirstScene(float time)
    {
        yield return new WaitForSeconds(time);
        ClickStart();
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
        gameStartFolder.SetActive(false);
        gameInfoUI.SetActive(false);
    }
}
