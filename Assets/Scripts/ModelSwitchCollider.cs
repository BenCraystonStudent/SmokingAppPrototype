using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitchCollider : MonoBehaviour
{
    public GameObject wCigarette, woCigarette;
    // Start is called before the first frame update
    void Start()
    {
        woCigarette.SetActive(true);
        wCigarette.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "LeftHandCollider")
        {
            wCigarette.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
