using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject PauseMenu;
    private PauseUISlider pauseUISlider;

    public void Awake()
    {
        pauseUISlider = GetComponent<PauseUISlider>();
        pauseUISlider.Initialize(PauseMenu);
    }

    public void ClickOpenMenu(){
        Pause.SetActive(false);
        pauseUISlider.UIShow();
    }

    public void ClickResume(){
        Pause.SetActive(true);
        pauseUISlider.UIHide();
    }

    public void ClickExit(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickRestart(){
        StageManager.Instance.Restart();
    }
}
