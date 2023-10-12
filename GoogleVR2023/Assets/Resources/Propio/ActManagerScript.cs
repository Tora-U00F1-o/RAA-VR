using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ActManagerScript : MonoBehaviour
{

    public string tag;
    public NPCConversation ActA;
    public NPCConversation ActB;
    
    public NPCConversation getConversation(int act) {
        if(act == 0) {
            
            Debug.Log("dev 0 "+(ActA == null? " no " : "si"));    
        return ActA;
        } 
        if(act == 1) {
        
            Debug.Log("dev 1 "+(ActB == null? " no " : "si"));    
            return ActB;
        } 

        return ActB;
    }
}
