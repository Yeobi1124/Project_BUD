using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public static CamManager Instance;
    
    [SerializeField]
    private CinemachineCamera _mainCamera;
    [SerializeField]
    private CinemachineCamera _subCamera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void UpdateCamera(float lens, Collider2D bound)
    {
        // Paste Main to Sub
        _subCamera.transform.position = _mainCamera.transform.position;
        _subCamera.Lens = _mainCamera.Lens;
        
        var mainConfiner = _mainCamera.GetComponent<CinemachineConfiner2D>();
        var subConfiner = _mainCamera.GetComponent<CinemachineConfiner2D>();
        
        subConfiner.BoundingShape2D = mainConfiner.BoundingShape2D;

        // Update Main
        _mainCamera.Lens.OrthographicSize = lens;
        mainConfiner.BoundingShape2D = bound;
        
        Debug.Log("Update Camera");
        
        // Blend Camera
        StartCoroutine(BlendCamera());
    }

    private IEnumerator BlendCamera()
    {
        _subCamera.Priority = 2;
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        // yield return new WaitForSecondsRealtime(1f);
        
        Debug.Log("Blending camera");
        _subCamera.Priority = 0;
        
        Camera.main.transform.position = _mainCamera.transform.position;
    }
}
