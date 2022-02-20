using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCigarette : MonoBehaviour
{
    public GameObject wCigarette, woCigarette, cigarette;
    private Vector3 handPosition;
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
            cigarette = Instantiate(cigarette, handPosition, Quaternion.identity);
            cigarette.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    void Update()
    {
        handPosition = woCigarette.transform.position;
    }
}
