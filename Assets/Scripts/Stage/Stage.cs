using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    
    [Header("Camera Settings")]
    [SerializeField] private Collider2D cameraBorder;
    [SerializeField] private float lens;
    
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
            
            foreach (var child in children)
            {
                if (child.name == "CameraBorder")
                {
                    startPoint = child;
                    break;
                }
            }
        }
    }

    public void Enter(GameObject player, CinemachineCamera camera)
    {
        player.transform.position = startPoint.position;
        var rigidBody = player.GetComponent<Rigidbody2D>();
        rigidBody.linearVelocity = Vector2.zero;
        
        // Camera
        var cinemachine = camera.GetComponent<CinemachineCamera>();
        var confiner = camera.GetComponent<CinemachineConfiner2D>();
        
        confiner.BoundingShape2D = cameraBorder;
        confiner.InvalidateBoundingShapeCache();

        cinemachine.Lens.OrthographicSize = lens;
        Camera.main.transform.position = startPoint.position;
    }
    
    public void UpdateStartPoint(Transform startPoint) => this.startPoint = startPoint;
}   
