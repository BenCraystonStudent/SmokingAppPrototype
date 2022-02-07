using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class C_Movement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    private XRRig rig;
    private Vector2 i_axis;
    private CharacterController playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out i_axis);
    }

    private void FixedUpdate()
    {
        Quaternion yaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = yaw * new Vector3(i_axis.x, 0, i_axis.y);

        playerMovement.Move(direction * Time.deltaTime * speed);
    }
}
