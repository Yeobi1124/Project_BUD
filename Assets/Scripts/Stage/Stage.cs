using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    public Vector2 StartPos => startPoint.position;

    private void Awake()
    {
        if (startPoint == null)
        {
            var children = gameObject.GetComponentsInChildren<Transform>();

            foreach (var child in children)
            {
                if (child.name == "StartPoint")
                {
                    startPoint = child;
                    break;
                }
            }
        }
    }
}   
