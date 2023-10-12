using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System.Configuration.Assemblies;

/* IMPORTANT */
// Use this version of TextDialogue only for conversations with a MAXIMUM OF TWO OPTIONS *responses
// This Script is a component of the PLAYER
// It includes two NPCs and conversations, adapt it to the number of NPCs and conversations in your scene.
// Change: Class properties and methods OnTriggerEnter and OnTriggerExit.

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class TextDialog2Opt2 : MonoBehaviour
{
    
    private int act = 0;
    public ActManagerScript NPC1;


    private bool selectUp, selectDown = false;
    private float verticalAxis;

    public void changeActTo(int nact) {
        this.act = nact;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if ((ConversationManager.Instance != null) & (ConversationManager.Instance.IsConversationActive))
        {
            verticalAxis = Input.GetAxis("Vertical");
            if (!selectUp & verticalAxis > 0)
            {
                selectUp = true;
                selectDown = false;
                ConversationManager.Instance.SelectPreviousOption();
            }
            else if (!selectDown & verticalAxis < 0)
            {
                selectDown = true;
                selectUp = false;
                ConversationManager.Instance.SelectNextOption();
            }
            else if (Input.GetAxis("Fire1") == 1)
            {
                selectUp = selectDown = false;
                ConversationManager.Instance.PressSelectedOption();
            }
        }        
    }


    void OnTriggerEnter(Collider collider)
    {
       // * Starts conversation for two NPCs 
 
        if(collider.gameObject.CompareTag(NPC1.tag))
        {
            Debug.Log("npc-e act:"+act);
            ConversationManager.Instance.StartConversation(NPC1.getConversation(act));
        }

        // if(collider.gameObject.CompareTag(NPC2Tag))
        // {
        //     ConversationManager.Instance.StartConversation(NPC2Conversation);
        // }
    }

     void OnTriggerExit (Collider collider)
     {
       // * Ends conversation for two NPCs 
 
        if(collider.gameObject.CompareTag(NPC1.tag)) // || collider.gameObject.CompareTag(NPC2Tag))
        {
            ConversationManager.Instance.EndConversation();
            Debug.Log("npc-e fin nact:"+act);
        }
     }
}
