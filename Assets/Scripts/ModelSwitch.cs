using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ModelSwitch : MonoBehaviour
{
    public GameObject wCigarette, woCigarette;
    public XRController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<XRController>();
        woCigarette.SetActive(true);
        wCigarette.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            wCigarette.SetActive(true);
            woCigarette.SetActive(false);
        }
    }
}
