using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActController : MonoBehaviour
{

    public AyudasController ayudas;
    public ActController nextAct;
    
    public virtual void prepare() {
        if(ayudas != null)
            ayudas.showHelp(true);
    }

    public ActController changeToNextAct() {
        if(ayudas != null)
            ayudas.showHelp(false);
        return nextAct;
    }

}
