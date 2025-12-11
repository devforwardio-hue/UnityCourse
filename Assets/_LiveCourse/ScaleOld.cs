using UnityEngine;

public class ScaleOld : MonoBehaviour
{
    public Rigidbody rb;
    public float scaleSize = 1f;
    public float defaultSize = 1f;
    public float growthRate = 1f;    // how fast it grows
    public bool isGrowing = false;   // set true when powerup triggers
    private float targetSize;        // final size after powerup

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = Vector3.one * defaultSize;
        targetSize = defaultSize;
    }

    // Update is called once per frame
    void Update()
    {
        ScaleSystem();
    }

    public void ScaleSystem()
    {
       if (!isGrowing)
            return;

        // Grow smoothly toward target size
        scaleSize = Mathf.MoveTowards(scaleSize, targetSize, growthRate * Time.deltaTime);
        transform.localScale = Vector3.one * scaleSize;

        // Stop once target reached
        if (Mathf.Approximately(scaleSize, targetSize))
            isGrowing = false;
    }

    // Called by your Powerup script
    public void TriggerGrowth(float newSize)
    {
        targetSize = newSize;
        isGrowing = true;
    }
}
