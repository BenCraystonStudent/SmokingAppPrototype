using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCigarette : MonoBehaviour
{
    public MeshRenderer litCylinderMeshLeft, litCylinderMeshRight;
    public GameObject litCylinderLeft, litCylinderRight;
    public ParticleSystem lighterFire;
    public bool isLit;
    private float lighterFireDistance, heldCigaretteDistance;
    // Start is called before the first frame update
    void Start()
    {
        isLit = false;
        litCylinderMeshLeft.enabled = false;
        litCylinderMeshRight.enabled = false;
    }

    public void LightCigaretteMethod()
    {
        lighterFireDistance = Vector3.Distance(lighterFire.transform.position, litCylinderLeft.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("From the LightCigarette script: isLit is: " + isLit);
        lighterFireDistance = Vector3.Distance(lighterFire.transform.position, litCylinderLeft.transform.position);
        if (lighterFireDistance < 0.05f && lighterFire.isPlaying)
        {
            litCylinderMeshLeft.enabled = true;
            isLit = true;
        }
    }
}
