using UnityEngine;

public class SmoothStrobe : MonoBehaviour
{
    public Light lightSource;          // The light we are fading
    public float fadeSpeed = 2f;       // How fast it fades
    public float minIntensity = 0f;    // Lowest light strength
    public float maxIntensity = 2f;    // Brightest light strength

    private bool fadeUp = true;        // Are we brightening or dimming?

    void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        // Start at minimum intensity
        lightSource.intensity = minIntensity;
        fadeUp = true;
    }

    void Update()
    {
        // If fading up (getting brighter)
        if (fadeUp)
        {
            lightSource.intensity += fadeSpeed * Time.deltaTime;

            // Once we reach max, switch to fade down
            if (lightSource.intensity >= maxIntensity)
            {
                lightSource.intensity = maxIntensity;
                fadeUp = false;
            }
        }
        else
        {
            // Fading down (getting dimmer)
            lightSource.intensity -= fadeSpeed * Time.deltaTime;

            // Once we reach min, switch to fade up
            if (lightSource.intensity <= minIntensity)
            {
                lightSource.intensity = minIntensity;
                fadeUp = true;
            }
        }
    }
}
