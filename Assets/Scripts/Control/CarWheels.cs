using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheels : MonoBehaviour
{
    [SerializeField] private bool canSteer = false;
    [SerializeField] private bool shouldInvertSteer = false;
    [SerializeField] private bool canPower = false;

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    public float SteeringAngle { get; set; }
    public float MotorTorque { get; set; }

    private void Awake()
    {
        //Assigning wheel colliders to wheelCollider and wheel transforms to wheelTransfom at Awake
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    void Update()
    {
        //to rotate the transform(mesh) of wheels according to wheel colliders so wheels can rotate when the car moves
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot * Quaternion.Euler(0, 0, 90);
    }
    private void FixedUpdate() 
    {
        //we can decide which wheels can steer the car or not
        if (canSteer)
            wheelCollider.steerAngle = SteeringAngle * (shouldInvertSteer ? -1:1);
        //we can decide which wheels can give power for the car to move
        if (canPower)
            wheelCollider.motorTorque = MotorTorque;
    }
}

