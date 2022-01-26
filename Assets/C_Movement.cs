using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class C_Movement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    private Vector2 i_axis;
    private CharacterController playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out i_axis);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(i_axis.x, 0, i_axis.y);

        playerMovement.Move(direction * Time.deltaTime * speed);
    }
}
