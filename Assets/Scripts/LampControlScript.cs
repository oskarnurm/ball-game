//LampsControlScript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsControllerScript : MonoBehaviour
{
    /* 
    Variables accessible from the Unity Editor
    Once the values are changed in the editor, the values
    below are no longer valid, and are only there as a
    baseline and sensible default.
    */
    public bool isOn = true;
    public float spotLightStrength = 10.0f;
    public float pointLightStrength = 2.0f;
    public Light[] spotLights;
    public Light[] pointLights;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Loop through all light source reference pairs, and set the light radius
        according to the values provided in the editor through
        the point/spotLightStrength variables above.
        */
        for (int i = 0; i < spotLights.Length; i++)
        {
            if (isOn)
            {
                spotLights[i].range = spotLightStrength;
                pointLights[i].range = pointLightStrength;
            }
            else
            {
                spotLights[i].range = 0.0f;
                pointLights[i].range = 0.0f;

            }
        }
    }

    public void TurnOff()
    {
        isOn = false;
    }
    public void TurnOn()
    {
        isOn = true;
    }

    public void SetPointLightStrength(float s)
    {
        pointLightStrength = s;
    }
    public void SetSpotLightStrength(float s)
    {
        spotLightStrength = s;
    }
}