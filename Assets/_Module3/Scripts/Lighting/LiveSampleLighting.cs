using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LiveSampleLighting : MonoBehaviour
{
    public enum LightChoice
    {
        Light1, Light2, Light3, Light4
    }

    public LightChoice selectedLight;
    Light targetLight;
    Light flickerLight1;
    Light flickerLight2;
    Light flickerLight3;
    Light flickerLight4;
    private Light[] lights;
    public bool isOn;
    public float maxWait = 1;
    public float maxFlicker = 0.2f;

    float timer;
    float interval;
    void Awake()
    {
        // Automatically find all Light components in children
        lights = GetComponentsInChildren<Light>();
        if (lights.Length == 0)
        {
            Debug.LogWarning("No child lights found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerInterval();
    }

    void lightManagment()
    {
       targetLight = null;

        switch (selectedLight)
        {
            case LightChoice.Light1:
                targetLight = flickerLight1;
                ToggleLight(targetLight);
                break;
            case LightChoice.Light2:
                targetLight = flickerLight2;
                ToggleLight(targetLight);
                break;
            case LightChoice.Light3:
                targetLight = flickerLight3;
                ToggleLight(targetLight);
                break;
            case LightChoice.Light4:
                targetLight = flickerLight4;
                ToggleLight(targetLight);
                break;
            default:
                targetLight.enabled = true;
                break;
        }

    }

    void TimerInterval() 
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            // Ensure selectedLight index is within bounds
            int index = Mathf.Clamp((int)selectedLight, 0, lights.Length - 1);

            ToggleLight(lights[index]);
        }
    }

    void ToggleLight(Light target)
    {
        if (target == null) 
        {
            return;
        }

        isOn = !isOn;
        target.enabled = isOn;

        if (isOn)
        {
            interval = Random.Range(0, maxWait);
        }
        else
        {
            interval = Random.Range(0, maxFlicker);
        }

        timer = 0;
    }
}
