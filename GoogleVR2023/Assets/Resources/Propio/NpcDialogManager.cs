using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NpcDialogManager : MonoBehaviour
{

    public string tag;
    public GameObject  dialogIndicator;
    public NPCConversation ActA;
    public NPCConversation ActB;
    
    public NPCConversation getConversation(int act) {
        if(act == 0) {
            return  ActA;
        } else if(act == 1) {
            return  ActB;
        } else {
            return ActA;
        } 
    }

    
    public void enableDialogIndicator(bool isOn) {
        dialogIndicator.SetActive(isOn);
    }
}
