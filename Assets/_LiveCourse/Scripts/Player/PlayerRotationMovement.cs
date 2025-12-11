using UnityEngine;
<<<<<<< HEAD

// Align the player's forward away from the orbiter with controllable, smooth turning.
public class PlayerRotationMovement : MonoBehaviour
{
    public Transform orbiterRef;

    public float turnSpeed = 360f;
    public float turnStartDelay = 0.1f;
    public float startTurnThreshold = 2f;

    public float turnSmoothTime = 0.0f; 
    private float yawVelocity;          
=======
public class PlayerRotationMovement : MonoBehaviour
{
    public Transform forwardRef;           
    public float turnSpeed = 360f;         
    public float turnStartDelay = 0.1f;    
    public float startTurnThreshold = 3f;  
>>>>>>> main

    private float delayTimer;
    private bool turningActive;

    void FixedUpdate()
    {
<<<<<<< HEAD
        AlignBackToOrbiter();
    }

    private void AlignBackToOrbiter()
    {
        if (orbiterRef == null)
=======
        AlignToHeading();
    }

    private void AlignToHeading()
    {
        if (forwardRef == null)
>>>>>>> main
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

<<<<<<< HEAD
        Vector3 toOrbiter = orbiterRef.position - transform.position;
        Vector3 desiredForward = Vector3.ProjectOnPlane(-toOrbiter, Vector3.up);
        if (desiredForward.sqrMagnitude < 1e-6f)
=======
        Vector3 heading = Vector3.ProjectOnPlane(forwardRef.forward, Vector3.up);//
        if (heading.sqrMagnitude < 1e-6f)
>>>>>>> main
        {
            turningActive = false;
            delayTimer = 0f;
            return;
        }

<<<<<<< HEAD
        Quaternion targetRot = Quaternion.LookRotation(desiredForward, Vector3.up);
        float currentYaw = transform.eulerAngles.y;
        float targetYaw = targetRot.eulerAngles.y;
        float angle = Mathf.DeltaAngle(currentYaw, targetYaw);
        float absAngle = Mathf.Abs(angle);

        if (absAngle < startTurnThreshold)
=======
        Quaternion targetRot = Quaternion.LookRotation(heading, Vector3.up);
        float currentYaw = transform.eulerAngles.y;
        float targetYaw = targetRot.eulerAngles.y;
        float angleDelta = Mathf.DeltaAngle(currentYaw, targetYaw);
        float absDelta = Mathf.Abs(angleDelta);

        if (absDelta < startTurnThreshold)
>>>>>>> main
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
<<<<<<< HEAD
            yawVelocity = 0f; 
        }

        
        if (turnSmoothTime > 0f)
        {
            float smoothedYaw = Mathf.SmoothDampAngle(currentYaw, targetYaw, ref yawVelocity, turnSmoothTime, Mathf.Infinity, Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0f, smoothedYaw, 0f);
        }
        else
        {
            float maxStep = turnSpeed * Time.fixedDeltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxStep);
        }
=======
        }

        float maxStep = turnSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxStep);
>>>>>>> main

        float remaining = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetYaw));
        if (remaining < startTurnThreshold * 0.5f)
        {
            turningActive = false;
            delayTimer = 0f;
        }
    }
}
