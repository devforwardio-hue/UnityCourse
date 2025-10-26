using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //public float minDistance = 1f;
    public float maxDistance = 5f;
    public Transform obstacleOrigin;
    public Vector3 obstacleDirection;

    public float moveSpeed = 1f;


    //Challenge:
    //RESEARCH: Vector3.Distance
    //RESEARCH: VECTOR3.Normalize
    //RESEARCH: OBJECT MOVE LEFT TO RIGHT
    //RESEARCH: PingPong?


    //FUNCTION:
    //Obsticle Moves left and right controled by its max distance.
    //The script must display the distance and update the obsticle distance.
    //The max distance should control both the min and max distance. 
    //

    void Start()
    {
        GetObstacleTransform();
    }

    // Update is called once per frame
    void Update()
    {
        ObsticleMovement();
        //ImprovedOpstacleMovement();
    }


    public void ImprovedOpstacleMovement()
    {
        //CURRENT:
        // Work in progress... 
        // Things had:
        // Direciton, Transform (Axises), Distance, Time and Speed....
        // -----------------------------------------------------------------------------------------
        //
        // Currently wanting to impliment new methods to resolve obstacle moving left and right...
        // State how far the Obstacle is to go...(Ryan said potintally use Distance... I am thinking Range??)
        // apply the diference using distance and add that to the obsticles transform...
        // 


        if (obstacleOrigin == null)
        {
            return;
        }

        if (obstacleDirection != null)
        {
            //Normalize the Origin 
            // With vector math Distance... update the direction..
            //new variable needed for translating direction
            
            //
            obstacleDirection.x += obstacleOrigin.position.x;

            // This applys the distance however create a better variable for distance!
            // Use that in the place of maxDistance 
            if (obstacleDirection.x <= maxDistance)
            {
                obstacleOrigin.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            else if (obstacleDirection.x >= -maxDistance)
            {
                obstacleOrigin.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

        }
    }

    public void ObsticleMovement()
    {
        //FUNCTION:
        //Obsticle Moves left and right controled by its max distance.
        //The script must display the distance and update the obsticle distance.
        //The max distance should control both the min and max distance. 
        //

        //CURRENT:
        //A Variable is created for the startPosition and the obsticlesOrigin.

        //Getting the Transform at the start for updating the obstaclesOrigin.

        //The chosen direction for the obstacleOrigin must tell the obstacleOrigin to go in said direction.

        //If the Origin even exists...
        // While it exitst...

        // The startingPostion must send the data to the Origin for transform updates

        // If the Obstacles direction is less than max distace
        // control how far and move it...
        // Update the Origin position using the new direction
        // Apply the directions for left and right.
        // Apply the speed and time.
        //

        if (obstacleOrigin == null)
        {
            return;
        }

        if (obstacleDirection != null)
        {
            obstacleDirection.x += obstacleOrigin.position.x;

            if (obstacleDirection.x <= maxDistance)
            {
                obstacleOrigin.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            else if (obstacleDirection.x >= -maxDistance)
            {
                obstacleOrigin.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

        }

    }

    public void GetObstacleTransform() 
    {
        if (obstacleOrigin == null)
        {
            obstacleOrigin = GetComponent<Transform>();
        }
    }


}

