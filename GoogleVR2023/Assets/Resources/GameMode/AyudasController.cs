using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyudasController : MonoBehaviour
{

    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;

    // Start is called before the first frame update
    void Start()
    {
        showHelp(false);
    }

    public void showHelp(bool active) {
        if(ob1 != null)
        {
            ob1.SetActive(active);
        }
        if(ob2 != null)
        {
            ob2.SetActive(active);
        }
        if(ob3 != null)
        {
            ob3.SetActive(active);
        }
    }

}
