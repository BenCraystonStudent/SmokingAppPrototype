using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class actionBox : MonoBehaviour
{
    public Animator mAnimator;
    public GameObject cigaretteBox;
    void Start()
    {
        mAnimator.SetBool("boxAction", false);
    }

    public void SetBoxAction()
    {
        mAnimator = cigaretteBox.GetComponent<Animator>();
        mAnimator.SetBool("boxAction", true);
    }

    public void CloseBox()
    {
        mAnimator = cigaretteBox.GetComponent<Animator>();
        mAnimator.SetBool("boxAction", false);
    }

    
}
