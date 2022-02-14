using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrepareGrabBox : MonoBehaviour
{
    public Animator animator;

    public void HoverOver()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isCloseToBox", true);
    }
}
