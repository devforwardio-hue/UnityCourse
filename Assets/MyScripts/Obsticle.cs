using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float minDistance = 1f;
    public float maxDistance = 5f;
    public Transform obsticleTransform;
    public Vector3 startPoint;
    public float moveSpeed = 1f;

    void Start()
    {
        obsticleTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ObsticleMovement();
    }

    public void ObsticleMovement()
    {
        //Challenge:
        //RESEARCH: Vector3.Distance
        //RESEARCH: VECTOR3.Normalize
        //RESEARCH: OBJECT MOVE LEFT TO RIGHT
        //RESEARCH: PingPong?

        //FIX THE CODE...
        //NO EXTRA SHIT...

        
        //If I can find the maxDistance
        //IT A VARRIABLE
        //
        //by calculating the startingPoint with the max distance when it is at maxDistance...
        //startingPoint + maxDistance >= maxDistance?????
        //
        //Then go back if not then go forward <---> 
        //Might only fix one way idk...

        if (obsticleTransform.position.x + startPoint.x + maxDistance >= maxDistance)
        {
            obsticleTransform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
            Debug.Log(obsticleTransform.position.x);
        }
        else
        {
            obsticleTransform.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }
        
    }


}
