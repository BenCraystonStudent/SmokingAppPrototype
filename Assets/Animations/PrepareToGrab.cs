using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareToGrab : MonoBehaviour

{

    Animator mAnimator;

    private void OnTriggerEnter(Collider other)
    {
        mAnimator.SetBool("isClose", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
