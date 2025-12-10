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
    public Color32 colorA = new Color32(255, 215, 120, 255);
    public Color32 colorB = new Color32(255, 200, 80, 255);
    public float speed = 2f;
    public float waveOffset = 0f;
    public bool isOn;
    public float maxWait = 1;
    public float maxFlicker = 0.2f;
    public float scale = 0.5f;

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

    void Update()
    {
        LightWave();
    }

    #region
    //void TimerInterval() 
    //{
    //    timer += Time.deltaTime;

    //    if (timer > interval)
    //    {
    //        // Ensure selectedLight index is within bounds
    //        int index = Mathf.Clamp((int)selectedLight, 0, lights.Length - 1);

    //        ToggleLight(lights[index]);
    //    }
    //}
    #endregion

    void LightWave()
    {
        {
            float wave = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;

            Color newColor = Color.Lerp(colorA, colorB, wave);

            foreach (Light l in lights)
            {
                if (l != null)
                    l.color = newColor;
                l.intensity = scale;
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
}
