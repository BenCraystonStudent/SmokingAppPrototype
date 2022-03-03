using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ModelSwitch : MonoBehaviour
{
    public GameObject wCigarette, woCigarette, wCigaretteR, woCigaretteR, cigaretteBox, heldCigarette, rSpent, lSpent;
    public Animator mAnimator;
    private float boxDistance, cigaretteDistance;

    // Start is called before the first frame update

    void Start()
    {
        woCigarette.SetActive(true);
        wCigarette.SetActive(false);
        woCigaretteR.SetActive(true);
        wCigaretteR.SetActive(false);
        mAnimator = cigaretteBox.GetComponent<Animator>();
        mAnimator.GetBool("boxAction");
        mAnimator.GetBool("isCloseToBox");
        mAnimator.GetBool("isGrabbingBox");
    }

    public void ChangeModels()
    {
        if (woCigarette.activeSelf && boxDistance <= 0.15 && mAnimator.GetBool("boxAction"))
        {
            wCigarette.SetActive(true);
            woCigarette.SetActive(false);
        }
    }

    public void SwitchCigaretteHeldHandToRight()
    {
        if(wCigarette.activeSelf && cigaretteDistance <= 0.12)
        {
            wCigarette.SetActive(false);
            woCigarette.SetActive(true);
            wCigaretteR.SetActive(true);
            woCigaretteR.SetActive(false);
            mAnimator.SetBool("isCloseToBox", false);
            mAnimator.SetBool("isGrabbingBox", false);
            mAnimator.SetBool("boxAction", false);
        }

        else if (lSpent.activeSelf && cigaretteDistance <= 0.12)
        {
            lSpent.SetActive(false);
            woCigarette.SetActive(true);
            rSpent.SetActive(true);
            woCigaretteR.SetActive(false);
            mAnimator.SetBool("isCloseToBox", false);
            mAnimator.SetBool("isGrabbingBox", false);
            mAnimator.SetBool("boxAction", false);
        }

    }

    public void SwitchCigaretteHeldHandToLeft()
    {
        if(wCigaretteR.activeSelf && cigaretteDistance <= 0.12 && boxDistance >= 0.15)
        {
            wCigarette.SetActive(true);
            woCigarette.SetActive(false);
            woCigaretteR.SetActive(true);
            wCigaretteR.SetActive(false);
            mAnimator.SetBool("isCloseToBox", false);
            mAnimator.SetBool("isGrabbingBox", false);
            mAnimator.SetBool("boxAction", false);
        }

        else if (rSpent.activeSelf && cigaretteDistance <= 0.12 && boxDistance >= 0.15)
        {
            rSpent.SetActive(false);
            woCigarette.SetActive(false);
            lSpent.SetActive(true);
            woCigaretteR.SetActive(true);
            mAnimator.SetBool("isCloseToBox", false);
            mAnimator.SetBool("isGrabbingBox", false);
            mAnimator.SetBool("boxAction", false);
        }
    }

    void Update()
    {
        boxDistance = Vector3.Distance(woCigarette.transform.position, cigaretteBox.transform.position);
        cigaretteDistance = Vector3.Distance(heldCigarette.transform.position, wCigarette.transform.position);
    }
}
