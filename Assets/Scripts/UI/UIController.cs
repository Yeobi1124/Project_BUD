using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject infoUI;
    private PauseUISlider pauseUISlider;

    public void Awake()
    {
        pauseUISlider = GetComponent<PauseUISlider>();
        pauseUISlider.Initialize(pauseMenu);
        InitUI();
    }

    private void InitUI()
    {
        pause.SetActive(true);
        pauseMenu.SetActive(false);
        infoUI.SetActive(false);
    }

    public void ClickOpenMenu(){
        pause.SetActive(false);
        pauseUISlider.UIShow();
    }

    public void ClickResume(){
        pause.SetActive(true);
        pauseUISlider.UIHide();
    }

    public void ClickInfoUI()
    {
        infoUI.SetActive(true);
    }

    public void ClickInfoOff()
    {
        infoUI.SetActive(false);
    }

    public void ClickExit(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickRestart(){
        pauseUISlider.UIHide();
        InitUI();
        StageManager.Instance.Restart();
    }
}
