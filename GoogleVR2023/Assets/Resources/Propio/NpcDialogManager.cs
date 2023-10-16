using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NpcDialogManager : MonoBehaviour
{

    public string tag;
    public GameObject  dialogIndicator;
    public NPCConversation ActA;
    public NPCConversation ActB = null;
    
    public NPCConversation getConversation(int act) {
        NPCConversation conv = null;
        if(act == 0) {
            conv =  ActA;
        } 
        if(act == 1) {
            conv =  ActB;
        } 
        
        return conv == null ? ActA : conv;
    }

    
    public void enableDialogIndicator(bool isOn) {
        dialogIndicator.SetActive(isOn);
    }
}
