using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_GameManager : MonoBehaviour {

    private GameObject GO_Image;



    // Use this for initialization
    void Start () {

        GO_Image = GameObject.Find("Interact_Text");
        GO_Image.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ImageOn()
    {
        if (GO_Image.active == true) //check if the screen is already active
            GO_Image.SetActive(false); //handle according to that
        else
            GO_Image.SetActive(true);

    }
}
