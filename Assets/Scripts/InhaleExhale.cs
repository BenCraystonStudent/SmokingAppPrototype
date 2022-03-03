using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class InhaleExhale : MonoBehaviour
{
    public GameObject inhaleExhaleTracker, VRcamera, leftHand, rightHand, lcigarette, rcigarette;
    public ParticleSystem mBlownSmoke;
    ParticleSystem.EmissionModule mEmissionModule;
    ParticleSystem.MainModule mMainModule;
    private float distanceLeft, distanceRight;
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool noise;
    float level, chargedLevel;
    bool chargedLungs;

    // Start is called before the first frame update
    void Start()
    {
        mEmissionModule = mBlownSmoke.emission;
        mMainModule = mBlownSmoke.main;
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
        mBlownSmoke.Play(false);

        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }

    void Inhale()
    {
        chargedLungs = true;
        chargedLevel = level;
    }

    void Exhale()
    {
        mEmissionModule.rateOverTime = level * 500;
       
        while (noise)
        {
            mBlownSmoke.Play();
            noise = false;
        }
        
        chargedLungs = false;
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
        level = Mathf.Sqrt(Mathf.Sqrt(levelMax));

        if (level > sensitivity && !noise)
        {
            noise = true;

    }
        if (level < sensitivity && noise) {
            noise = false;
    }

    inhaleExhaleTracker.transform.position = VRcamera.transform.position;
    inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;


        distanceRight = Vector3.Distance(rcigarette.transform.position, inhaleExhaleTracker.transform.position);
        distanceLeft = Vector3.Distance(lcigarette.transform.position, inhaleExhaleTracker.transform.position);
        if ((distanceLeft < 0.2) && leftHand.GetComponent<LightCigarette>().isLit && noise)
        {
            chargedLungs = true;
            Inhale();
        }
        else if (distanceRight < 0.2 && rightHand.GetComponent<LightCigarette>().isLit && noise)
        {
            chargedLungs = true;
            Inhale();
        }


        else if (distanceRight > 0.2 && noise && chargedLungs)
        {
            chargedLevel = level;
            Exhale();
        }


        else if (distanceLeft > 0.2 && noise && chargedLungs)
        {
            chargedLevel = level;
            Exhale();
        }

        Debug.Log("Level: " + level);
        Debug.Log("Noise: " + noise);
        Debug.Log("Charged Lungs: " + chargedLungs);
    }

    

    

    
}
