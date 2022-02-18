using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ModelSwitch : MonoBehaviour
{
    public GameObject wCigarette, woCigarette;
    public InputDevice controller1, controller2;

    // Start is called before the first frame update

    private void Awake()
    {
        controller1 = GetComponent<InputDevice>();
        controller2 = GetComponent<InputDevice>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller1.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary) && primary)
        {
            Debug.Log("Pressed!");
        }
    }
}
