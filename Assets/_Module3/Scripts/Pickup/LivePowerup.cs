using UnityEngine;

public class LivePowerup : MonoBehaviour
{
  public float powerSpeed = 100f;
  public float powerTimeMax = 10f;
  public float currentTime = 0f;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    
  }

  private void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.CompareTag("Player"))
    {
      //control flat value. Time Delta time is controlled in the movement script instead. 
      col.gameObject.GetComponent<PlayerMovementOld>().moveSpeed += powerSpeed;
      Destroy(this.gameObject);
    }
  }



}
