using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    public Light lightSource;      // The light we want to flash
    public float strobeSpeed = 0.1f; // How fast it flashes (seconds)
    public float minIntensity = 0f;  // Light off value
    public float maxIntensity = 2f;  // Light on value

    private float timer;
    private bool lightIsOn = false;

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        // Start with the light turned off
        lightSource.intensity = minIntensity;
        lightIsOn = false;
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // When timer reaches the strobe speed, toggle light
        if (timer >= strobeSpeed)
        {
            timer = 0f;

            // Flip light on/off
            lightIsOn = !lightIsOn;

            if (lightIsOn)
            {
                lightSource.intensity = maxIntensity;
            }
            else
            {
                lightSource.intensity = minIntensity;
            }
        }
    }
}
