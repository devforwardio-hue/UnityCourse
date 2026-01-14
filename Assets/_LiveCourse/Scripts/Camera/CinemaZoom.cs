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

        float scroll = Input.GetAxis("Mouse ScrollWheel");//normalization of 0-1 based on scroll input
        if (!Mathf.Approximately(scroll, 0f))
        {
        //baseDistance = 1, - inward = 0, 
            float min = baseDistance - inwardRange;
            float max = baseDistance + outwardRange;
            float activeValue = targetDistance - scroll * scrollSpeed;
            targetDistance = Mathf.Clamp(activeValue, min, max);
            Debug.Log(targetDistance + "Target Clamp");
        }

        float current = tpf.CameraDistance;
        float next = Mathf.SmoothDamp(current, targetDistance, ref velocity, smoothTime);
        tpf.CameraDistance = next;
    //Debug.Log(next + "Current movement towards reaching targetDistance");
    }
}
