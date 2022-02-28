using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhale : MonoBehaviour
{
    AudioClip micAudio;
    // Start is called before the first frame update
    void Start()
    {
        micAudio = Microphone.Start("Rift Audio", true, 3, 44100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
