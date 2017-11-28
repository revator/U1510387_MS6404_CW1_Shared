using UnityEngine;

public class OK_PlayerMovement : MonoBehaviour
{
    public float fl_Speed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moving();

    }


    void Moving()
    {
        float fl_translation = Input.GetAxis("Vertical") * fl_Speed;
        float fl_straffe = Input.GetAxis("Horizontal") * fl_Speed;
        fl_translation *= Time.deltaTime;
        fl_straffe *= Time.deltaTime;

        transform.Translate(fl_straffe, 0, fl_translation);



    }
}
