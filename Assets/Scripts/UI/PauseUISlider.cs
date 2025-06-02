using UnityEngine;
using System.Collections;

public class PauseUISlider : MonoBehaviour
{
    private Vector2 hiddenPosition;
    private Vector2 showPosition;
    private RectTransform rectTransform;
    [SerializeField] private float duration;

    public void Initialize()
    {
        hiddenPosition = new Vector2(-1100, 0);
        showPosition = new Vector2(-825, 0);
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = hiddenPosition;
        duration = 0.5f;
    }

    public void UIShow()
    {
        StartCoroutine((SlideUIMenu(hiddenPosition,showPosition)));
    }
    public void UIHide()
    {
        StartCoroutine((SlideUIMenu(showPosition, hiddenPosition)));
    }

    IEnumerator SlideUIMenu(Vector2 start, Vector2 end)
    {
        float nowTime = 0.0f;
        
        while(nowTime<=duration)
        {
            nowTime += Time.deltaTime;
            float progress = Mathf.Clamp01(nowTime / duration);
            rectTransform.anchoredPosition = Vector2.Lerp(start,end,progress);
            //yield return new WaitForSeconds(Time.deltaTime);
            yield return null;
        }
        
        
    }
}
