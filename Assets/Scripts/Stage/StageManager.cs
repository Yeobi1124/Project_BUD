using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;
    
    [SerializeField]
    private Stage[] stagePrefabs;
    private List<Stage> stages = new List<Stage>();
    
    [SerializeField]
    private int _currentStage;
    public int CurrentStage => _currentStage;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        stagePrefabs = transform.GetComponentsInChildren<Stage>();

        foreach (Stage stage in stagePrefabs)
        {
            stages.Add(Instantiate(stage));
            stage.gameObject.SetActive(false);
        }

        _currentStage = 0;
        
        PlayerManager.Instance.Player.transform.position = stages[_currentStage].StartPos;
    }

    private void OnDestroy()
    {
        if(Instance == this)
            Instance = null;
    }

    public void MoveToNextStage()
    {
        if (stages.Count <= _currentStage + 1) return;
        var player = PlayerManager.Instance.Player;
        
        player.transform.position = stages[++_currentStage].StartPos;
    }

    public void Restart(){}
}  
