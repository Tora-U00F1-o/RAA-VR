using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System.Configuration.Assemblies;

/* IMPORTANT */
// Controla los actos de dialogos del juego

///--------------------------------
///   Author: Jorge Toraño
///--------------------------------

public class TextDialog2InfNpcs : MonoBehaviour
{
    
    private int act = 0;
    private List<NpcDialogManager> npcsList;

    public NpcDialogManager NPC1;
    public NpcDialogManager NPC2;



    private bool selectUp, selectDown = false;
    private float verticalAxis;

    // Start is called before the first frame update
    void Start()
    {
        npcsList = new List<NpcDialogManager>();
        npcsList.Add(NPC1);
        npcsList.Add(NPC2);
        
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
       
        foreach (NpcDialogManager manager in npcsList)
        {
            if(collider.gameObject.CompareTag(manager.tag))
            {
                Debug.Log("npc-e act:"+act);
                manager.enableDialogIndicator(false);
                ConversationManager.Instance.StartConversation(manager.getConversation(act));
            }
        }

        // if(collider.gameObject.CompareTag(NPC2Tag))
        // {
        //     ConversationManager.Instance.StartConversation(NPC2Conversation);
        // }
    }

     void OnTriggerExit (Collider collider)
     {
       // * Ends conversation for two NPCs 
 
        foreach (NpcDialogManager manager in npcsList)
        {
            if(collider.gameObject.CompareTag(manager.tag)) // || collider.gameObject.CompareTag(NPC2Tag))
            {
                ConversationManager.Instance.EndConversation();
                Debug.Log("npc-e fin nact:"+act);
            }
        }
     }

     public void changeActTo(int nact) {
        this.act = nact;
        foreach (NpcDialogManager manager in npcsList)
        {
            manager.enableDialogIndicator(true);
        }
    }
}
