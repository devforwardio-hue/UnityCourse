using UnityEngine;

public class SimpleObstacle : MonoBehaviour
{
  public Vector3 direction = Vector3.forward;
  public Vector3 rotationDirection = Vector3.up;
  private Vector3 startPosition;
  
  public float speed = 1f;
  public float rotationSpeed = 1f;
  public float maxMoveDistance = 5f;
  private float moveDirection = 1f;


  void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {

    TranslateObstacle();
    }

  #region TranslateObstacle - Instructor Method
  /*
   * COMPARISON TO STUDENT METHODS:
   * 
   * This method demonstrates several advanced concepts you can learn, see advantage for reason of my  methods.
   * 
   * 1. Vector3.normalized - Ensures consistent speed regardless of direction input.
   *    Student methods: Hard-coded to single axis (Vector3.right/left), no normalization needed.
   *    Advantage: Works with ANY direction (diagonal, vertical, custom angles).
   * 
   * 2. Direction multiplier (-1f) - Similar to EWelch's approach but with float precision.
   *    Student methods: MStevenson, EWelch, KStidham use int direction, TMcGee uses switch states.
   *    Advantage: Smoother multiplication, can extend to fractional speeds later.
   * 
   * 3. Vector3.Distance for boundaries - Same concept as KStidham's approach.
   *    Student methods: Most use position comparison (MStevenson, TMcGee), TChisam uses offset calc.
   *    Advantage: Magnitude-based, works with multi-axis movement.
   * 
   * 4. Rotation integration - Combines translation AND rotation in one method.
   *    Student methods: None include rotation, only single-axis translation.
   *    Advantage: Demonstrates multiple transformations working together.
   * 
   * 5. Public direction fields - Allows designer to set ANY direction in inspector.
   *    Student methods: All hard-coded to X-axis movement only (Vector3.right/left).
   *    Advantage: Reusable for vertical, diagonal, or 3D space movement patterns.
   * 
   * KEY DIFFERENCE: This is a GENERAL SOLUTION, student methods are SPECIFIC SOLUTIONS.
   * Both are valid - specific solutions are simpler to understand, general solutions are more reusable.
   */
  public void TranslateObstacle()
  {
    transform.position += direction.normalized * speed * moveDirection * Time.deltaTime;
    transform.Rotate(rotationDirection.normalized * rotationSpeed * Time.deltaTime);
    if (Vector3.Distance(startPosition, transform.position) >= maxMoveDistance)
    {
      moveDirection *= -1f;
    }
  }
  #endregion
}
