using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject gameInfoUI;
    [SerializeField] GameObject gameStartFolder;
    [SerializeField] GameObject gameEndingSaveIcon;
    private Animator gameStartAnimator;
    private Animator gameEndingAnimator;
    [SerializeField] private float waitTime;


    private void Awake()
    {
        ClearScreen();
        gameStartAnimator = gameStartFolder.GetComponent<Animator>();
        gameEndingAnimator = gameEndingSaveIcon.GetComponent<Animator>();
        if (EndingCheck.EndingAchieved)
        {
            Debug.Log("Ending");
            gameEndingSaveIcon.SetActive(true);
            gameEndingAnimator.SetTrigger("Ending");
        }

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
        SceneManager.LoadScene("1");
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
        gameEndingSaveIcon.SetActive(false);
        gameStartFolder.SetActive(false);
        gameInfoUI.SetActive(false);
    }
}
