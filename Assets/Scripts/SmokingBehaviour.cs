using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingBehaviour : MonoBehaviour
{
    public GameObject leftHand, rightHand;
    public ParticleSystem smoke;
    public TrailRenderer smokeTrail;
    private bool leftHandLit, rightHandLit;
    // Start is called before the first frame update
    void Start()
    {
        smoke.Stop();
        smokeTrail.emitting = false;
      //  leftHandLit = leftHand.GetComponent<LightCigarette>().isLit;
      //  rightHandLit = rightHand.GetComponent<LightCigarette>().isLit;
      //  leftHandLit = false;
      //  rightHandLit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("From SmokingBehaviour: The left hand is lit: " + leftHand.GetComponent<LightCigarette>().isLit);
       /* if ((leftHand.GetComponent<LightCigarette>().isLit = true) || (rightHand.GetComponent<LightCigarette>().isLit = true))
        {
            smoke.Play();
            smokeTrail.emitting = true;
        } */
    }
}
