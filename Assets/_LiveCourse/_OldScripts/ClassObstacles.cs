using UnityEngine;
using TMPro;

public class ClassObstacles : MonoBehaviour
{
    public enum StudentName
    {
        MStevenson,
        GScott,
        TMcGee,
        TChisam,
        EWelch,
        KStidham,
        SStidham
    }

    [Header("Student Selection")]
    public StudentName selectedStudent = StudentName.MStevenson;

    [Header("Movement Settings")]
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float moveSpeed = 2.0f;

    [Header("UI")]
    public TMP_Text studentNameText;

    private Transform obstacleTransform;
    private Vector3 startPosition;
    private int obstacleDirection = 1;
    private int switchCount = 0;
    private bool tchisamMovingRight = true;

    private void Awake()
    {
        obstacleTransform = GetComponent<Transform>();
        startPosition = obstacleTransform.position;
    }

    private void Start()
    {
        UpdateStudentNameDisplay();
    }

    private void Update()
    {
        ExecuteSelectedMovement();
    }

    private void UpdateStudentNameDisplay()
    {
        if (studentNameText != null)
        {
            studentNameText.text = selectedStudent.ToString();
        }
    }

    private void ExecuteSelectedMovement()
    {
        switch (selectedStudent)
        {
            case StudentName.MStevenson:
                MStevenson_Movement();
                break;
            case StudentName.GScott:
                GScott_Movement();
                break;
            case StudentName.TMcGee:
                TMcGee_Movement();
                break;
            case StudentName.TChisam:
                TChisam_Movement();
                break;
            case StudentName.EWelch:
                EWelch_Movement();
                break;
            case StudentName.KStidham:
                KStidham_Movement();
                break;
            case StudentName.SStidham:
                SStidham_Movement();
                break;
        }
    }

    #region MStevenson Movement
    /*
     * Absolute Position Comparison - Checks raw world position against fixed boundaries.
     * Movement is smooth and consistent. Direction flips instantly at boundaries.
     * Physics: Constant velocity with instant direction reversal (no acceleration curve).
     */
    private void MStevenson_Movement()
    {
        obstacleTransform.position += new Vector3(moveSpeed * obstacleDirection * Time.deltaTime, 0f, 0f);

        if (obstacleTransform.position.x >= maxDistance)
        {
            obstacleDirection = -1;
        }
        else if (obstacleTransform.position.x <= minDistance)
        {
            obstacleDirection = 1;
        }
    }
    #endregion

    #region GScott Movement
    /*
     * Mathf.PingPong - Uses Unity's built-in oscillation function with Time.time.
     * Movement creates a smooth sine-wave-like motion pattern automatically.
     * Physics: Non-linear velocity - naturally slows at peaks, accelerates through center.
     * Position is recalculated entirely each frame rather than incrementally moved.
     */
    private void GScott_Movement()
    {
        obstacleTransform.position = new Vector3(
            Mathf.PingPong(moveSpeed * Time.time, minDistance), 
            obstacleTransform.position.y, 
            obstacleTransform.position.z
        );
    }
    #endregion

    #region TMcGee Movement
    /*
     * Switch-State Machine - Uses explicit states (case 0/1) to control direction.
     * Movement is incremental with clear state transitions at boundaries.
     * Physics: Constant velocity with state-based instant direction reversal.
     * Demonstrates state pattern - each direction is a discrete "mode" of operation.
     */
    private void TMcGee_Movement()
    {
        switch (switchCount)
        {
            case 0:
                obstacleTransform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                if (transform.position.x >= maxDistance)
                {
                    switchCount = 1;
                }
                break;

            case 1:
                obstacleTransform.position -= new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                if (transform.position.x <= minDistance)
                {
                    switchCount = 0;
                }
                break;
        }
    }
    #endregion

    #region TChisam Movement
    /*
     * Relative Position with Boolean State - Tracks distance from origin, uses bool for direction.
     * Movement is smooth and relative to starting position (works anywhere in scene).
     * Physics: Constant velocity with instant direction flip at calculated offset boundaries.
     * Most flexible - object can start at any position and maintain proper oscillation range.
     */
    private void TChisam_Movement()
    {
        float currentDistance = obstacleTransform.position.x - startPosition.x;

        if (tchisamMovingRight)
        {
            obstacleTransform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (currentDistance >= maxDistance)
            {
                tchisamMovingRight = false;
            }
        }
        else
        {
            obstacleTransform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (currentDistance <= -maxDistance)
            {
                tchisamMovingRight = true;
            }
        }
    }
    #endregion

    #region EWelch Movement
    /*
     * Start Position Offset with Direction Multiplier - Stores origin, uses int multiplier (-1/1).
     * Movement is relative to stored starting point with simple multiplication for direction.
     * Physics: Constant velocity with instant direction reversal via sign flip.
     * Most readable - clearly shows "start position + offset" boundary logic.
     */
    private void EWelch_Movement()
    {
        obstacleTransform.position += new Vector3(obstacleDirection, 0, 0) * moveSpeed * Time.deltaTime;

        if (obstacleTransform.position.x >= startPosition.x + maxDistance)
        {
            obstacleDirection = -1;
        }
        else if (obstacleTransform.position.x <= startPosition.x - maxDistance)
        {
            obstacleDirection = 1;
        }
    }
    #endregion

    #region KStidham Movement
    /*
     * Vector3.Distance Calculation - Uses Unity's distance function to measure from origin.
     * Movement uses distance measurement rather than position comparison for boundaries.
     * Physics: Constant velocity with instant direction reversal based on calculated distance.
     * Unique approach - distance is magnitude-based (always positive), checks actual travel distance.
     */
    private void KStidham_Movement()
    {
        float distanceFromStart = Vector3.Distance(obstacleTransform.position, startPosition);
        obstacleTransform.position += Vector3.right * obstacleDirection * moveSpeed * Time.deltaTime;

        if (distanceFromStart >= maxDistance)
        {
            obstacleDirection = -1;
        }
        else if (distanceFromStart <= minDistance)
        {
            obstacleDirection = 1;
        }
    }
    #endregion

    #region SStidham Movement
    /*
     * Advanced PingPong with Range Calculation - Refines GScott's approach with proper min/max handling.
     * Validates range before execution, uses offset math to map PingPong output to custom range.
     * Physics: Non-linear velocity (same as GScott), but oscillates between minDistance and maxDistance.
     * Key improvement: PingPong range is calculated (max - min), then min is added as offset.
     * Most mathematically correct PingPong implementation - handles arbitrary min/max values properly.
     */
    private void SStidham_Movement()
    {
        float range = maxDistance - minDistance;
        if (range <= 0f)
            return;

        //My understanding is that we will move from one position to the otheer, based on blay blah blah transform.positon blah blah blah
        float offset = Mathf.PingPong(Time.time * moveSpeed, range) + minDistance;
        Vector3 pos = startPosition;
        pos.x = startPosition.x + offset;
        obstacleTransform.position = pos;
        //comment your full undestanding of how this works, in as much long form as possible.
  }
  #endregion
}
