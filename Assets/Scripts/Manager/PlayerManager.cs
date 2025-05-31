using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    [SerializeField]
    private PlayerController player;
    public PlayerController Player => player;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    
    private void OnDestroy()
    {
        if(Instance == this)
            Instance = null;
    }
}
