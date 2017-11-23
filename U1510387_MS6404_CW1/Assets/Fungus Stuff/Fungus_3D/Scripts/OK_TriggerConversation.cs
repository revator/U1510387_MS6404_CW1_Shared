using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityStandardAssets.Characters.FirstPerson;

public class OK_TriggerConversation : MonoBehaviour
{

    // Variables

    // These private variables are set within the start and are used to control the player character when they enter the trigger box.
    private GameObject GO_Player;
    private CharacterController cc_PlayerController;
    private bool bl_Toggle;
    private MouseLook cs_FPSControl;
    public bool bl_requiresInput;
    private GameObject GO_GameMana;
    


    // This public variable is for setting the flowchart. You should be able to set the flowchart per trigger in the editor.
    public Flowchart fc_NPCDialog;
    public string st_MessageReciever;

    // Use this for initialization
    void Start()
    {
        // Game Objects and components are found so that we can reference them later in the script.
        GO_Player = GameObject.FindGameObjectWithTag("Player");

        cc_PlayerController = GO_Player.GetComponent<CharacterController>();

        // We need to set the image and flowchart to false so that we can activate them when the player enters the trigger.

        fc_NPCDialog.gameObject.SetActive(false);
        GO_GameMana = GameObject.FindGameObjectWithTag("GameController");



    }

    private void OnTriggerEnter(Collider cl_trigger)
    {
        OK_GameManager Manager = GO_GameMana.GetComponent<OK_GameManager>();

        if (cl_trigger.gameObject.tag == "Player")
        {
            Manager.ImageOn();

        }
    }
    //This void 
    private void OnTriggerStay(Collider cl_trigger)
    {
        if (cl_trigger.gameObject.tag == "Player")
        {
            if (bl_requiresInput == false)
            {
                fc_NPCDialog.gameObject.SetActive(true);
                fc_NPCDialog.SendFungusMessage(st_MessageReciever);
                cc_PlayerController.enabled = true;
                //cs_FPSControl.lockCursor = false;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                fc_NPCDialog.gameObject.SetActive(true);
                fc_NPCDialog.SendFungusMessage(st_MessageReciever);
                cc_PlayerController.enabled = false;
                //cs_FPSControl.lockCursor = false;
            }
        }
    }
    private void OnTriggerExit(Collider cl_trigger)
    {
        OK_GameManager Manager = GO_GameMana.GetComponent<OK_GameManager>();
        if (cl_trigger.gameObject.tag == "Player")
        {

            Manager.ImageOn();
            fc_NPCDialog.gameObject.SetActive(false);

        }
    }

    public void CCEnable()
    {
        cc_PlayerController.enabled = true;
        //cs_FPSControl.lockCursor = true;

    }

    private void OnTriggerEnter2D(Collider2D cl_trigger)
    {
        OK_GameManager Manager = GO_GameMana.GetComponent<OK_GameManager>();

        if (cl_trigger.gameObject.tag == "Player")
        {
            Manager.ImageOn();

        }
    }

    private void OnTriggerStay2D(Collider2D cl_trigger)
    {

        if (cl_trigger.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                fc_NPCDialog.gameObject.SetActive(true);
                fc_NPCDialog.SendFungusMessage(st_MessageReciever);
                GO_Player.gameObject.SendMessage("StopMove");

                //cc_PlayerController.enabled = false;
                //cs_FPSControl.lockCursor = false;

            }
        }

    }

    private void OnTriggerExit2D(Collider2D cl_trigger)
    {
        OK_GameManager Manager = GO_GameMana.GetComponent<OK_GameManager>();
        if (cl_trigger.gameObject.tag == "Player")
        {
            Manager.ImageOn();
            fc_NPCDialog.gameObject.SetActive(false);
            GO_Player.gameObject.SendMessage("StartMove");
        }
    }

}
