using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet : MonoBehaviour {

    // Variables
    public Light directionalLight;
    public float timeForSunSet; // value between 0-100, 100 goes down from maximum intensity to 0 in 100 seconds.

    // Use this for initialization
    void Start () {
        directionalLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        while(timeForSunSet >= 0)
        {
            timeForSunSet -= Time.deltaTime;
            Debug.Log(timeForSunSet);
            directionalLight.intensity = (timeForSunSet / 100);
            if (timeForSunSet == 0)
            {
                directionalLight.intensity = 0;
                break;
            }
        }
    }      
}
