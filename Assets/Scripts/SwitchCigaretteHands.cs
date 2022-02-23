using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCigaretteHands : MonoBehaviour
{
    public GameObject leftHand, rightHand;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if ((leftHand.GetComponent<LightCigarette>().isLit == true) || (rightHand.GetComponent<LightCigarette>().isLit == true))
        {
            leftHand.GetComponent<LightCigarette>().litCylinderMesh.enabled = true;
            rightHand.GetComponent<LightCigarette>().litCylinderMesh.enabled = true;
        }
    }
}
