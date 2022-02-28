using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhale : MonoBehaviour
{
    AudioClip micAudio;
    public ParticleSystem mBlownSmoke;
    // Start is called before the first frame update
    void Start()
    {
        micAudio = Microphone.Start("Rift Audio", true, 3, 44100);
        mBlownSmoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeldCigarette")
        {
            mBlownSmoke.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "HeldCigarette")
        {
            mBlownSmoke.Stop();
        }
    }
}
