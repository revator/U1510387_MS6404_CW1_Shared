using UnityEngine;

public class OK_CameraLook : MonoBehaviour
{

    private Vector2 V2_Mouselook;
    private Vector2 V2_SmoothV;

    public float fl_Sensitive;
    public float fl_Smooth;

    private GameObject mGO_PlayerCharacter;

    public float fl_X_Max;
    public float fl_X_Min;
    public float fl_Y_Max;
    public float fl_Y_Min;

    public bool bl_YClamp;
    public bool bl_XClamp;
    public bool bl_Stationary;



    // Use this for initialization
    void Start()
    {
        mGO_PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_Stationary == true)
        {
            bl_Stationary = true;
            V2_Mouselook.y = Mathf.Clamp(V2_Mouselook.y, 0, 0);
            V2_Mouselook.x = Mathf.Clamp(V2_Mouselook.x, 0, 0);
            Cursor.lockState = CursorLockMode.None;
        }

        if (bl_Stationary == false)
        {
            CamLook();
        }

    }

    void CamLook()
    {

        Vector2 V2_MousePos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        V2_MousePos = Vector2.Scale(V2_MousePos, new Vector2(fl_Sensitive * fl_Smooth, fl_Sensitive * fl_Smooth));
        V2_SmoothV.x = Mathf.Lerp(V2_SmoothV.x, V2_MousePos.x, 1f / fl_Smooth);
        V2_SmoothV.y = Mathf.Lerp(V2_SmoothV.y, V2_MousePos.y, 1f / fl_Smooth);
        V2_Mouselook += V2_SmoothV;


        CamClamp();

        transform.localRotation = Quaternion.AngleAxis(-V2_Mouselook.y, Vector3.right);
        mGO_PlayerCharacter.transform.localRotation = Quaternion.AngleAxis(V2_Mouselook.x, mGO_PlayerCharacter.transform.up);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    void CamClamp()
    {
        if (bl_YClamp == true)
        {
            V2_Mouselook.y = Mathf.Clamp(V2_Mouselook.y, fl_Y_Min, fl_Y_Max);
        }
        if (bl_XClamp == true)
        {
            V2_Mouselook.x = Mathf.Clamp(V2_Mouselook.x, fl_X_Min, fl_X_Max);
        }

    }

    void Station(int in_Station)
    {
        if (in_Station == 1)
        bl_Stationary = true;
    }

    void CC_Enable()
    {
        bl_Stationary = false;

    }
}
