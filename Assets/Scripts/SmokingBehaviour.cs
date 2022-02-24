using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingBehaviour : MonoBehaviour
{
    public GameObject leftHand, rightHand;
    public ParticleSystem smoke;
    public TrailRenderer smokeTrail;
    // Start is called before the first frame update
    void Start()
    {
        smoke.Stop();
        smokeTrail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        while (leftHand.GetComponent<LightCigarette>().isLit == true || rightHand.GetComponent<LightCigarette>().isLit == true)
        {
            smoke.Play();
            smokeTrail.emitting = true;
        }
    }
}
