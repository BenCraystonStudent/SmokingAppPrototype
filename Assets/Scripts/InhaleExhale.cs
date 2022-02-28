using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class InhaleExhale : MonoBehaviour
{
    public GameObject inhaleExhaleTracker, VRcamera, leftHand, rightHand, lcigarette, rcigarette;
    public ParticleSystem mBlownSmoke;
    private float distanceLeft, distanceRight;
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool exhaling;

    // Start is called before the first frame update
    void Start()
    { 
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
        mBlownSmoke.Play(false);

        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); 
        microphoneInput.GetData(waveData, micPosition);

        
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));

        if (level > sensitivity && !exhaling)
        {
        
            exhaling = true;

    }
        if (level < sensitivity && exhaling) { 
            exhaling = false;
    }

    inhaleExhaleTracker.transform.position = VRcamera.transform.position;
    inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;

        distanceLeft = Vector3.Distance(lcigarette.transform.position, inhaleExhaleTracker.transform.position);
        if ((distanceLeft < 0.5) && leftHand.GetComponent<LightCigarette>().leftSmoke.isPlaying && exhaling)
        {
            Exhale();
        }

        distanceRight = Vector3.Distance(rcigarette.transform.position, inhaleExhaleTracker.transform.position);
        if ((distanceRight < 0.5) && rightHand.GetComponent<LightCigarette>().rightSmoke.isPlaying && exhaling)
        {
            Exhale();
        }

        Debug.Log("Level: " + level);
        //Debug.Log(distance);
    }

    void Exhale()
    {
        mBlownSmoke.Play(true);
    }

    

    
}
