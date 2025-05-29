using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed;
    //���ν� ī�޶�ũ��
    [SerializeField] private float minZoom = 5f;
    //�ܾƿ��� ī�޶�ũ��
    [SerializeField] private float maxZoom = 10f;
    private Camera cam;
    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void ZoomIn(Vector2 target)
    {
        StartCoroutine(ZoomInCoroutine(target));
;    }

    private IEnumerator ZoomInCoroutine(Vector2 targetPos)
    {
        yield return new WaitForSeconds(1);
        while(cam.orthographicSize != minZoom) { 
            
            cam.orthographicSize -= zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
            yield return new WaitForFixedUpdate();
        }
    }    
    
}
