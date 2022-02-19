using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ModelSwitch : MonoBehaviour
{
    public GameObject wCigarette, woCigarette, cigaretteBox;
    public Animator mAnimator;
    private float distance;
    bool isOpen;

    // Start is called before the first frame update

    void Start()
    {
        woCigarette.SetActive(true);
        wCigarette.SetActive(false);
        mAnimator = cigaretteBox.GetComponent<Animator>();
        isOpen = mAnimator.GetBool("boxAction");
    }

    public void ChangeModels()
    {
        if (woCigarette.activeSelf && distance <= 0.15 && (isOpen == true))
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

    void Update()
    {
        distance = Vector3.Distance(woCigarette.transform.position, cigaretteBox.transform.position);
        Debug.Log(isOpen.ToString());
    }
}
