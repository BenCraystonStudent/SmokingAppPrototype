using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class isGrabbingBox : MonoBehaviour
{
    public Animator animator;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isGrabbingBox", false);
    }

    public void GrabbedBox()
    {
        animator = rightHand.GetComponent<Animator>();
        animator.SetBool("isGrabbingBox", true);
    }

    public void LetGoOfBox()
    {
        animator = rightHand.GetComponent<Animator>();
        animator.SetBool("isGrabbingBox", false);
    }
    
}
