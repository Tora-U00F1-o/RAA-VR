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

public class ActManager : MonoBehaviour
{
    
    private int actNumber = 0;
    public ActController act;
    private List<NpcDialogManager> npcsList;

    public NpcDialogManager NPC_E;
    public NpcDialogManager NPC_D;
    public NpcDialogManager NPC_A;
    public NpcDialogManager NPC_P;
    

    private bool selectUp, selectDown = false;
    private float verticalAxis;

    // Start is called before the first frame update
    void Start()
    {   
        npcsList = new List<NpcDialogManager>();
        npcsList.Add(NPC_E);
        npcsList.Add(NPC_D);
        npcsList.Add(NPC_A);
        npcsList.Add(NPC_P);

        foreach (NpcDialogManager manager in npcsList)
        {
            manager.enableDialogIndicator(true);
        }

        act.prepare();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("act:" +actNumber);
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
                manager.enableDialogIndicator(false);
                ConversationManager.Instance.StartConversation(manager.getConversation(actNumber));
                return;
            }
        }
        if(actNumber == 0 && collider.gameObject.CompareTag("PosOrla")) {
            nextAct();
            return;
        }
        if(actNumber == 3 && collider.gameObject.CompareTag("PosOrlaEscondida")) {
            nextAct();
            return;
        }

    }

     void OnTriggerExit (Collider collider)
     {
       // * Ends conversation for two NPCs 
 
        foreach (NpcDialogManager manager in npcsList)
        {
            if(collider.gameObject.CompareTag(manager.tag)) 
            {
                ConversationManager.Instance.EndConversation();
            }
        }
     }


     public void nextAct() {
        this.act = act.changeToNextAct();
        this.actNumber++;
        foreach (NpcDialogManager manager in npcsList)
        {
            manager.enableDialogIndicator(true);
        }
        act.prepare();
        
    }
}
