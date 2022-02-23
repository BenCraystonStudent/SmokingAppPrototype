using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCigarette : MonoBehaviour
{
    public MeshRenderer litCylinderMesh;
    public GameObject litCylinder;
    public ParticleSystem lighterFire;
    public bool isLit;
    private float lighterFireDistance, heldCigaretteDistance;
    // Start is called before the first frame update
    void Start()
    {
        litCylinderMesh.enabled = false;
    }

    public void LightCigaretteMethod()
    {
        lighterFireDistance = Vector3.Distance(lighterFire.transform.position, litCylinder.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        lighterFireDistance = Vector3.Distance(lighterFire.transform.position, litCylinder.transform.position);
        if (lighterFireDistance < 0.05f && lighterFire.isPlaying)
        {
            litCylinderMesh.enabled = true;
            isLit = true;
        }
    }
}
