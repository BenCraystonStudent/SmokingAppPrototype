﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhale : MonoBehaviour
{
    AudioClip micAudio;
    public GameObject inhaleExhaleTracker, VRcamera, lcigarette, rcigarette;
    public ParticleSystem mBlownSmoke;
    
    // Start is called before the first frame update
    void Start()
    {
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
        micAudio = Microphone.Start("Rift Audio", true, 3, 44100);
        mBlownSmoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other == lcigarette || rcigarette) && VRcamera.GetComponent<LightCigarette>().litCylinderMeshLeft.enabled)
        {
            mBlownSmoke.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == rcigarette || lcigarette)
        {
            mBlownSmoke.Stop();
        }
    }
}
