using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCigarette : MonoBehaviour
{
    public GameObject wCigarette, woCigarette, cigarette;
    private Vector3 handPosition;
    private Quaternion handRotation;
    // Start is called before the first frame update
    void Start()
    {
        wCigarette.SetActive(false);
    }

    // Update is called once per frame
    public void Drop()
    {
        if (wCigarette.activeSelf)
        {
            woCigarette.SetActive(true);
            wCigarette.SetActive(false);
            cigarette = Instantiate(cigarette, handPosition, handRotation);
            //cigarette.transform.localScale = new Vector3(0.52f, 0.52f, 0.52f);
        }
    }

    void Update()
    {
        handPosition = woCigarette.transform.position;
        handRotation = woCigarette.transform.rotation;
       // Destroy(cigarette, 4.0f);
    }
}
