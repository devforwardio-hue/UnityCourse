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
        EWelch
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
}
