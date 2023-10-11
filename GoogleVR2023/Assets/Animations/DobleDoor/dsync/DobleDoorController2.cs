using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DobleDoorController2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Component leftDoor;
    public Component rightDoor;

    private Animator leftAnim;
    private Animator rightAnim;

    private void Awake()
    {
        leftAnim = leftDoor.GetComponent<Animator>();
        rightAnim = rightDoor.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (rightAnim && leftAnim)
        {
            rightAnim.SetBool("Mirando", true);
            leftAnim.SetBool("Mirando", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (rightAnim && leftAnim)
        {
            rightAnim.SetBool("Mirando", false);
            leftAnim.SetBool("Mirando", false);
        }
    }

}

