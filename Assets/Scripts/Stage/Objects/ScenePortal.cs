using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class ScenePortal : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private bool isEndingPortal;
    [SerializeField]
    private UIController uiController;
    private float waitingTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            waitingTime = 0;
            if (isEndingPortal)
            {
                waitingTime = 1.5f;
                uiController.FadeOut();
                EndingCheck.EndingAchieved = true;
            }
            StartCoroutine(ChangeScene(waitingTime));
        }
    }

    IEnumerator ChangeScene(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene(_sceneName);
    }
}
