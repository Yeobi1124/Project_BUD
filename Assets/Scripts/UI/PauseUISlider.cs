using UnityEngine;
using System.Collections;

public class PauseUISlider : MonoBehaviour
{
    private Vector2 hiddenPosition;
    private Vector2 showPosition;
    private RectTransform rectTransform;
    private UIController uIController;
    [SerializeField] private float duration;

    public void Initialize(GameObject pauseMenu)
    {
        hiddenPosition = new Vector2(-1100, 0);
        showPosition = new Vector2(-825, 0);
        rectTransform = pauseMenu.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = hiddenPosition;
        duration = 0.5f;
    }

    public void UIShow()
    {
        StartCoroutine(UIMenuShow());
    }

    public void UIHide()
    {
        StartCoroutine(UIMenuHide());
    }

    IEnumerator UIMenuHide()
    {
        float nowTime = 0.0f;
        
        while(nowTime<=duration)
        {
            nowTime += Time.deltaTime;
            float progress = Mathf.Clamp01(nowTime / duration);
            rectTransform.anchoredPosition = Vector2.Lerp(showPosition,hiddenPosition,progress);
            yield return null;
        }
        rectTransform.gameObject.SetActive(false); 
    }

    IEnumerator UIMenuShow()
    {
        rectTransform.gameObject.SetActive(true);
        float nowTime = 0.0f;

        while (nowTime <= duration)
        {
            nowTime += Time.deltaTime;
            float progress = Mathf.Clamp01(nowTime / duration);
            rectTransform.anchoredPosition = Vector2.Lerp(hiddenPosition, showPosition, progress);
            yield return null;
        }
    }
}
