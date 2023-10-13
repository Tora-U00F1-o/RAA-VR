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
        NPCConversation conv = ActB;
        if(act == 0) {
            
            Debug.Log("dev 0 "+(ActA == null? " no " : "si"));    
            conv =  ActA;
        } 
        if(act == 1) {
        
            Debug.Log("dev 1 "+(ActB == null? " no " : "si"));    
            conv =  ActB;
        } 
        return conv;
    }

    
    public void enableDialogIndicator(bool isOn) {
        dialogIndicator.SetActive(isOn);
    }
}
