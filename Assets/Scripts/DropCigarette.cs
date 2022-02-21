﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCigarette : MonoBehaviour
{
    public GameObject wCigarette, woCigarette, wCigaretteR, woCigaretteR, cigarette;
    private Vector3 handLeftPosition, handRightPosition;
    private Quaternion handLeftRotation, handRightRotation;
    public Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        wCigarette.SetActive(false);
        woCigaretteR.SetActive(true);
    }

    // Update is called once per frame
    public void DropFromLeftHand()
    {
        if (wCigarette.activeSelf)
        {
            woCigarette.SetActive(true);
            wCigarette.SetActive(false);
            cigarette = Instantiate(cigarette, handLeftPosition, handLeftRotation);
            //cigarette.transform.localScale = new Vector3(0.52f, 0.52f, 0.52f);
        }
    }

    public void DropFromRightHand()
    {
        if(wCigaretteR.activeSelf)
        {
            woCigaretteR.SetActive(true);
            wCigaretteR.SetActive(false);
            cigarette = Instantiate(cigarette, handRightPosition, handRightRotation);
            mAnimator.SetBool("isCloseToBox", false);
            mAnimator.SetBool("isGrabbingBox", false);
        }
    }    

    void Update()
    {
        handLeftPosition = woCigarette.transform.position;
        handLeftRotation = woCigarette.transform.rotation;
        handRightPosition = woCigarette.transform.position;
        handRightRotation = woCigaretteR.transform.rotation;
       // Destroy(cigarette, 4.0f);
    }
}
