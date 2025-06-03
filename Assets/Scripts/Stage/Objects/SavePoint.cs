using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        
        enabled = false;
        
        var stageManager = StageManager.Instance;
        stageManager.StagePrefabs[stageManager.CurrentStage].UpdateStartPoint(transform);
    }
}
