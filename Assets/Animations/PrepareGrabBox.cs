using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrepareGrabBox : MonoBehaviour
{
    public Animator animator;
    public GameObject rightHand;

    public void HoverOver()
    {
        animator = rightHand.GetComponent<Animator>();
        animator.SetBool("isCloseToBox", true);
    }

    public bool IsCloseToBox()
    {
        animator = rightHand.GetComponent<Animator>();
        return animator.GetBool("isCloseToBox");
    }
}
