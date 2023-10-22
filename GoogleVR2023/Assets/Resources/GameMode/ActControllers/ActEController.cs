using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActEController : ActController
{

    public GameObject orla; 
    private Animator animator;
    
    void Start()
    {
        animator = orla.GetComponent<Animator>();
    }
    
    public override void prepare()
    {
        base.prepare();

        animator.SetBool("Colgada", true);
    }


}
