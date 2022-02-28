using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhale : MonoBehaviour
{
    AudioClip micAudio;
    public GameObject inhaleExhaleTracker, VRcamera, leftHand, lcigarette, rcigarette;
    public ParticleSystem mBlownSmoke;
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
        micAudio = Microphone.Start("Rift Audio", true, 3, 44100);
        mBlownSmoke.Play(false);
    }

    // Update is called once per frame
    void Update()
    {
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
        distance = Vector3.Distance(lcigarette.transform.position, inhaleExhaleTracker.transform.position);
        if ((distance < 0.9) && leftHand.GetComponent<LightCigarette>().leftSmoke.isPlaying)
        {
            Exhale();
        }
        Debug.Log(distance);
    }

    void Exhale()
    {
        mBlownSmoke.Play(true);
    }

    

    
}
