using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrepareGrabBox : MonoBehaviour
{
    public Animator animator;
    public GameObject rightHand;

    private void Start()
    {
        animator.SetBool("isCloseToBox", false);
    }

    public void HoverOver()
    {
        animator = rightHand.GetComponent<Animator>();
        animator.SetBool("isCloseToBox", true);
    }

    public void HoverEnd()
    {
        animator = rightHand.GetComponent<Animator>();
        animator.SetBool("isCloseToBox", false);
    }
}
