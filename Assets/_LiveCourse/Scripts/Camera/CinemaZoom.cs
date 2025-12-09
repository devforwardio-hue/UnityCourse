using UnityEngine;
using Unity.Cinemachine;

public class CinemaZoom : MonoBehaviour
{
    public CinemachineCamera vcam;           
    public float scrollSpeed = 1f;                  
    public float inwardRange = 1f;                 
    public float outwardRange = 5f;                 

    public float smoothTime = 0.15f;               

    private CinemachineComponentBase body;
    private float baseDistance;                     
    private float targetDistance;                   
    private float velocity;                         

    void Awake()
    {
        if (vcam == null)
        {
            vcam = GetComponent<CinemachineCamera>();
        }

        body = vcam != null ? vcam.GetCinemachineComponent(CinemachineCore.Stage.Body) : null;
        var tpf = body as CinemachineThirdPersonFollow;
        if (tpf != null)
        {
            baseDistance = tpf.CameraDistance;
            targetDistance = baseDistance;
        }
        else
        {
            Debug.LogWarning("CinemaZoom requires CinemachineThirdPersonFollow on the vcam Body.");
        }
    }

    void Update()
    {
        if (body == null) return;
        var tpf = body as CinemachineThirdPersonFollow;
        if (tpf == null) return;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (!Mathf.Approximately(scroll, 0f))
        {
            float min = baseDistance - inwardRange;
            float max = baseDistance + outwardRange;
            targetDistance = Mathf.Clamp(targetDistance - scroll * scrollSpeed, min, max);
        }

        float current = tpf.CameraDistance;
        float next = Mathf.SmoothDamp(current, targetDistance, ref velocity, smoothTime);
        tpf.CameraDistance = next;
    }
}
