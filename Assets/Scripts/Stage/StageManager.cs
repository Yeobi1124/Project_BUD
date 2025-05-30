using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;
    
    [SerializeField]
    private List<Stage> stages = new List<Stage>();

    public void MoveToNextStage()
    {
    }

    public void Restart(){}
}  
