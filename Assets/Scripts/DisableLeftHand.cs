using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableLeftHand : MonoBehaviour
{
    // Start is called before the first frame update
    float distance;
    public XRGrabInteractable cigBox;
    public XRBaseInteractor leftHand;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       distance = Vector3.Distance(cigBox.transform.position, leftHand.transform.position);
       if (distance < 0.2)
       {
            leftHand.enableInteractions = false;
       }
       else
            {
            leftHand.enableInteractions = true;
        }
    }
}
