using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet : MonoBehaviour
{

    // Variables
    public Light directionalLight;
    public float timeForSunSet; // value between 0-100, 100 goes down from maximum intensity to 0 in 100 seconds.
    public float rotationSpeed;

    public bool bl_Tick;

    // Use this for initialization
    void Start()
    {
        directionalLight = GetComponent<Light>();
        bl_Tick = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SunSetOverdrive();
        RotateSun();
        //Debug.Log(rotationSpeed);
    }

    void SunSetOverdrive()
    {
        if (bl_Tick == true)
        {
            timeForSunSet -= 1 * Time.deltaTime;
            //Debug.Log(timeForSunSet);
            directionalLight.intensity = (timeForSunSet / 100);
        }
        else if (bl_Tick == false)
        {
            directionalLight.intensity = 0;
        }
        if (timeForSunSet <= 0)
        {
            bl_Tick = false;
        }
    }
    void RotateSun()
    {
        Debug.Log(transform.rotation.x);
        if (transform.rotation.x <= 0)
        {
            transform.Rotate(rotationSpeed, 0, 0);
        }
    }
}
