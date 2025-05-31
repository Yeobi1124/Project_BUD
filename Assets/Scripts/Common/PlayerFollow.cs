using System;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = PlayerManager.Instance.Player.transform.position;
    }
}
