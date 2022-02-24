using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingBehaviour : MonoBehaviour
{
    public GameObject leftHand, rightHand;
    public ParticleSystem smoke;
    public TrailRenderer smokeTrail;
    private bool leftHandLit, rightHandLit;
    bool isLitSB;
    // Start is called before the first frame update
    void Start()
    {
        smoke.Stop();
        smokeTrail.emitting = false;
        isLitSB = leftHand.GetComponent<LightCigarette>().isLit; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("From SmokingBehaviour: The left hand is lit: " + isLitSB);
       /* if ((leftHand.GetComponent<LightCigarette>().isLit = true) || (rightHand.GetComponent<LightCigarette>().isLit = true))
        {
            smoke.Play();
            smokeTrail.emitting = true;
        } */
    }
}
