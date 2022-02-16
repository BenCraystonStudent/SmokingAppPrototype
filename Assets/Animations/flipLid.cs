using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class flipLid : MonoBehaviour
{
    public Animator animator;
    public GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("flippedLid", false);
    }

    public void flippingLid()
    {
        animator = rightHand.GetComponent<Animator>();
        animator.SetBool("flippedLid", true);
    }
}
