using System;
using System.Collections.Generic;
using Unity.Cinemachine;
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
            // stages.Add(Instantiate(stage));
            stage.gameObject.SetActive(false);
        }

        _currentStage = 0;

        var startStage = Instantiate(stagePrefabs[_currentStage]);
        startStage.gameObject.SetActive(true);
        stages.Add(startStage);
        
        PlayerManager.Instance.Player.transform.position = startStage.StartPos;
    }

    private void Start()
    {
        var player = PlayerManager.Instance.Player;
        
        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
        stages[_currentStage].Enter(player.gameObject, brain.ActiveVirtualCamera as CinemachineCamera);   
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void MoveToNextStage()
    {
        if (stagePrefabs.Length <= _currentStage + 1) return;
        var player = PlayerManager.Instance.Player;

        var nextStage = Instantiate(stagePrefabs[++_currentStage]);
        nextStage.gameObject.SetActive(true);
        stages.Add(nextStage);
        
        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
        nextStage.Enter(player.gameObject, brain.ActiveVirtualCamera as CinemachineCamera);
    }

    public void Restart()
    {
        var newStage = Instantiate(stagePrefabs[_currentStage]);
        newStage.gameObject.SetActive(true);
        
        var oldStage = stages[_currentStage];
        stages[_currentStage] = newStage;
        
        newStage.Enter(PlayerManager.Instance.Player.gameObject, Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineCamera);
        
        Destroy(oldStage.gameObject);
    }
}  
