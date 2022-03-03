using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCigarette : MonoBehaviour
{
    public GameObject wCigarette, woCigarette, wCigaretteR, woCigaretteR, cigarette, rightHand, leftHand, rSpent, lSpent;
    private Vector3 handLeftPosition, handRightPosition;
    private Quaternion handLeftRotation, handRightRotation;
    public Animator mAnimator;
    public bool hasDroppedR;

    // Start is called before the first frame update
    void Start()
    {
        wCigarette.SetActive(false);
        woCigaretteR.SetActive(true);
    }

    // Update is called once per frame
    public void DropFromLeftHand()
    {
        if (wCigarette.activeSelf || lSpent.activeSelf)
        {
            woCigarette.SetActive(true);
            wCigarette.SetActive(false);
            lSpent.SetActive(false);
            cigarette = Instantiate(cigarette, handLeftPosition, handLeftRotation);
            //cigarette.transform.localScale = new Vector3(0.52f, 0.52f, 0.52f);
            leftHand.GetComponent<LightCigarette>().isLit = false;
            leftHand.GetComponent<LightCigarette>().litCylinderMeshLeft.enabled = false;
            rightHand.GetComponent<LightCigarette>().isLit = false;
            rightHand.GetComponent<LightCigarette>().litCylinderMeshRight.enabled = false;
        }
    }

    public void DropFromRightHand()
    {
        if(wCigaretteR.activeSelf || rSpent.activeSelf)
        {
            woCigaretteR.SetActive(true);
            wCigaretteR.SetActive(false);
            rSpent.SetActive(false);
            cigarette = Instantiate(cigarette, handRightPosition, handRightRotation);
            mAnimator.SetBool("isCloseToBox", false);
            mAnimator.SetBool("isGrabbingBox", false);
            mAnimator.SetBool("boxAction", false);
            rightHand.GetComponent<LightCigarette>().isLit = false;
            rightHand.GetComponent<LightCigarette>().litCylinderMeshLeft.enabled = false;
            leftHand.GetComponent<LightCigarette>().isLit = false;
            leftHand.GetComponent<LightCigarette>().litCylinderMeshRight.enabled = false;
        }
    }    

    void Update()
    {
        handLeftPosition = leftHand.transform.position;
        handLeftRotation = leftHand.transform.rotation;
        handRightPosition = rightHand.transform.position;
        handRightRotation = rightHand.transform.rotation;
        hasDroppedR = false;
        //leftHand.GetComponent<LightCigarette>().isLit = false;
       // rightHand.GetComponent<LightCigarette>().isLit = false;
       // leftHand.GetComponent<LightCigarette>().litCylinderMeshLeft.enabled = false;
       // rightHand.GetComponent<LightCigarette>().litCylinderMeshRight.enabled = false;
        // Destroy(cigarette, 4.0f);
    }
}
