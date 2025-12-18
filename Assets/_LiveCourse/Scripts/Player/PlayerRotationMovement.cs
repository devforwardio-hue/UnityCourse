using UnityEngine;
public class PlayerRotationMovement : MonoBehaviour
{
    public Transform forwardRef;           
    public float turnSpeed = 360f;         
    public float turnStartDelay = 0.1f;    
    public float startTurnThreshold = 3f;  

    private float delayTimer;
    private bool turningActive;

    void FixedUpdate()
    {
        AlignToHeading();
    }

    private void AlignToHeading()
    {
        if (forwardRef == null)
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

        Vector3 heading = Vector3.ProjectOnPlane(forwardRef.forward, Vector3.up);//
        if (heading.sqrMagnitude < 1e-6f)
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

        Quaternion targetRot = Quaternion.LookRotation(heading, Vector3.up);
        float currentYaw = transform.eulerAngles.y;
        float targetYaw = targetRot.eulerAngles.y;
        float angleDelta = Mathf.DeltaAngle(currentYaw, targetYaw);
        float absDelta = Mathf.Abs(angleDelta);

        if (absDelta < startTurnThreshold)
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

        if (!turningActive)
        {
            delayTimer += Time.fixedDeltaTime;
            if (delayTimer < turnStartDelay)
            {
                return;
            }
            turningActive = true;
        }

        float maxStep = turnSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxStep);

        float remaining = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetYaw));
        if (remaining < startTurnThreshold * 0.5f)
        {
            turningActive = false;
            delayTimer = 0f;
        }
    }
}
