using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCigarette : MonoBehaviour
{
    public MeshRenderer litCylinderMeshLeft, litCylinderMeshRight;
    public GameObject litCylinderLeft, litCylinderRight;
    public ParticleSystem lighterFire, leftSmoke, rightSmoke;
    public TrailRenderer leftTrail, rightTrail;
    public bool isLit = false;
    private float lighterFireDistanceL, lighterFireDistanceR;
    // Start is called before the first frame update
    void Start()
    {
        isLit = false;
        litCylinderMeshLeft.enabled = false;
        litCylinderMeshRight.enabled = false;
        leftTrail.emitting = false;
        rightTrail.emitting = false;
       
    }

    public void LightCigaretteMethod()
    {
        lighterFireDistanceL = Vector3.Distance(lighterFire.transform.position, litCylinderLeft.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
      
        lighterFireDistanceL = Vector3.Distance(lighterFire.transform.position, litCylinderLeft.transform.position);
        lighterFireDistanceR = Vector3.Distance(lighterFire.transform.position, litCylinderRight.transform.position);
        if (lighterFireDistanceL < 0.05 && lighterFire.isPlaying)
        {
            litCylinderMeshLeft.enabled = true;
            isLit = true;
        }
        if (lighterFireDistanceR < 0.05 && lighterFire.isPlaying)
        {
            litCylinderMeshRight.enabled = true;
            isLit = true;
        }

        if (isLit)
        {
            leftSmoke.Play();
            leftTrail.emitting = true;
            rightSmoke.Play();
            rightTrail.emitting = true;
        }
        else
        {
            leftTrail.emitting = false;
            rightTrail.emitting = false;
        }
        Debug.Log("From the LightCigarette script: isLit is: " + isLit);
        Debug.Log("Cigarette fire is " + litCylinderMeshLeft.enabled);
        Debug.Log("Cigarette fire right is " + litCylinderMeshRight.enabled);

    }
}
