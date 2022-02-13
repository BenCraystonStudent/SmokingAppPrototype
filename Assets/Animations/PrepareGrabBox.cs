using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareGrabBox : MonoBehaviour
{
    [SerializeField] private Animator mAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            mAnimator.SetBool("isCloseToBox", true);
        }
    }
}
