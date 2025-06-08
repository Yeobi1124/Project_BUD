using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class ScenePortal : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private bool isEndingPortal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isEndingPortal)
                EndingCheck.EndingAchieved = true;
            SceneManager.LoadScene(_sceneName);
        }
    }
}
