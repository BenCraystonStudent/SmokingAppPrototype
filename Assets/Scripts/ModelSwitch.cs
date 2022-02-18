using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ModelSwitch : MonoBehaviour
{
    public GameObject wCigarette, woCigarette;

    // Start is called before the first frame update

    void Start()
    {
        woCigarette.SetActive(true);
        wCigarette.SetActive(false);
    }

    public void ChangeModels()
    {
        if (woCigarette.activeSelf)
        {
            wCigarette.SetActive(true);
            woCigarette.SetActive(false);
        }
        else
        {
            woCigarette.SetActive(true);
            wCigarette.SetActive(false);
        }
    }
}
