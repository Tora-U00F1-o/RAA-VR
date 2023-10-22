using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActDController : ActController
{

    public GameObject puerta; 
    private Animator animator;
    
    void Start()
    {
        animator = puerta.GetComponent<Animator>();
    }
    
    public override void prepare()
    {
        base.prepare();

        animator.SetBool("Open", true);
    }


}

