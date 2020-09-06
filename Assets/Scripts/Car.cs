using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelColliderRightFront;
    [SerializeField] private WheelCollider wheelColliderLeftFront;
    [SerializeField] private WheelCollider wheelColliderRightBack;
    [SerializeField] private WheelCollider wheelColliderLeftBack;

    [SerializeField] private Transform wheelRightFront;
    [SerializeField] private Transform wheelLeftFront;
    [SerializeField] private Transform wheelRightBack;
    [SerializeField] private Transform wheelLeftBack;

    [SerializeField] private float motorTorque = 350f;
    [SerializeField] private float steeringAngle = 50f;

    [SerializeField] private Transform centerOfMass;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        wheelColliderLeftBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRightBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * steeringAngle;
        wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * steeringAngle;
    }

    private void Update() 
    {
        Vector3 position;
        Quaternion rotation;

        wheelColliderRightFront.GetWorldPose(out position, out rotation);
        wheelRightFront.position = position;
        wheelRightFront.rotation = rotation * Quaternion.Euler(0, 180, 90);

        wheelColliderRightBack.GetWorldPose(out position, out rotation);
        wheelRightBack.position = position;
        wheelRightBack.rotation = rotation * Quaternion.Euler(0, 180, 90);

        wheelColliderLeftFront.GetWorldPose(out position, out rotation);
        wheelLeftFront.position = position;
        wheelLeftFront.rotation = rotation* Quaternion.Euler(0, 0, 90);

        wheelColliderLeftBack.GetWorldPose(out position, out rotation);
        wheelLeftBack.position = position;
        wheelLeftBack.rotation = rotation * Quaternion.Euler(0, 0, 90);
    }
}
