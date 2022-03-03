using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class InhaleExhale : MonoBehaviour
{
    public GameObject inhaleExhaleTracker, VRcamera, leftHand, rightHand, lcigarette, rcigarette, rSpent, rHoldingCigarette, lHoldingCigarette, lSpent;
    public ParticleSystem mBlownSmoke;
    ParticleSystem.EmissionModule mEmissionModule;
    ParticleSystem.MainModule mMainModule;
    private float distanceLeft, distanceRight;
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity, smokeLength;
    public bool noise;
    float level, chargedLevel, wavePeak;
    bool chargedLungs;
    int smokeCounterLength;
    public int spentCounter;

    // Start is called before the first frame update
    void Start()
    {
        rSpent.SetActive(false);
        lSpent.SetActive(false);
        mEmissionModule = mBlownSmoke.emission;
        mMainModule = mBlownSmoke.main;
        inhaleExhaleTracker.transform.position = VRcamera.transform.position;
        inhaleExhaleTracker.transform.rotation = VRcamera.transform.rotation;
        mBlownSmoke.Stop();

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
        mEmissionModule.rateOverTime = level * 1000;
        smokeLength = mBlownSmoke.main.duration;
        while (noise)
        {
            smokeLength = level;
            mBlownSmoke.Play();
            smokeCounterLength++;
            noise = false;
        }
        if (smokeCounterLength > 100)
        {
            chargedLungs = false;
            smokeCounterLength = 0;
            spentCounter++;
        }
    }

    void SpentCigarette()
    {
        if (rHoldingCigarette.activeSelf)
        {
            rHoldingCigarette.SetActive(false);
            rSpent.SetActive(true);
            spentCounter = 0;
        }

        else if (lHoldingCigarette.activeSelf)
        {
            lHoldingCigarette.SetActive(false);
            lSpent.SetActive(true);
            spentCounter = 0;
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
            wavePeak = waveData[i] * waveData[i];
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

        if (spentCounter >= 2)
        {
            SpentCigarette();
        }

        

        // Debug.Log("Level: " + level);
        // Debug.Log("Noise: " + noise);
        //  Debug.Log("Charged Lungs: " + chargedLungs);
        Debug.Log("Smoke Length: " + smokeCounterLength);
    }

    

    

    
}
