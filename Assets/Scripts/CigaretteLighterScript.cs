﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretteLighterScript : MonoBehaviour
{
    public GameObject rightHand, cigaretteLighter;
    public ParticleSystem flames;

    // Start is called before the first frame update

    void Start()
    {
        flames.Stop();
    }

    public void ToggleFlames()
    {
        if (flames.isStopped)
        {
            flames.Play();
        }
        else
        {
            flames.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
