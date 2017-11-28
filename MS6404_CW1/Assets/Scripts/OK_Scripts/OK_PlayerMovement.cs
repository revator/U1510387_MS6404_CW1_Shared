using UnityEngine;

public class OK_PlayerMovement : MonoBehaviour
{
    public float fl_speed;
    public float fl_jumpHeight;

    public float fl_MidAirSpeed;
    private float fl_Speedset;
    
    public bool bl_isGrounded;
    private Rigidbody rb_PlayerRigid;


    // Use this for initialization
    void Start()
    {
        rb_PlayerRigid = GetComponent<Rigidbody>();
        fl_Speedset = fl_speed;
    }


    private void FixedUpdate()
    {
        Moving();
        CheckGrounded();
    }


    void Moving()
    {
        float fl_translation = Input.GetAxis("Vertical") * fl_speed;
        float fl_straffe = Input.GetAxis("Horizontal") * fl_speed;
        fl_translation *= Time.deltaTime;
        fl_straffe *= Time.deltaTime;

        //calculate the velocity vector
        //Vector3 _v3_move_direction = transform.position + (transform.TransformDirection(fl_straffe, 0, fl_translation));

        // Apply movement vector to the rigid body
        //rb_PlayerRigid.MovePosition(_v3_move_direction);

        transform.Translate(fl_straffe, 0, fl_translation);
        //rb_PlayerRigid.MovePosition(fl_straffe, 0, fl_translation);

        if (Input.GetKeyDown("space") && bl_isGrounded == true)
        {
            rb_PlayerRigid.velocity = new Vector3(0, fl_jumpHeight, 0);
        }

    }
    
    // ----------------------------------------------------------------------
    private void CheckGrounded()
    {
        RaycastHit hitInfo;

        if (Physics.SphereCast(transform.position, 0.4F, Vector3.down, out hitInfo, 0.65F))
        {
            bl_isGrounded = true;
            fl_speed = fl_Speedset;
        }

        else
        {
            bl_isGrounded = false;
            fl_speed = fl_MidAirSpeed;
        }

    }//------ 
}
