using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform centerOfMass;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CarWheels[] carWheels;

    [SerializeField] private float motorTorque = 1500f;
    [SerializeField] private float steeringAngle = 20f;

    private float Steering { get; set; }
    private float Throttling { get; set; }

    private void Awake()
    {
        //this will look for all the components in cars children objects 
        //and find all the CarWheels(script) component and it will return all the wheels and put them into the CarWheels array
        //this way we could have different number of wheeler cars such as 8 wheeler truck   
        carWheels = GetComponentsInChildren<CarWheels>();

        //changing the center of mass location of the car so the car won't roll over while steering
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    private void Update()
    {
        //Car gets steering input and throttle input from InputController
        Steering = GameManager.Instance.InputController.SteeringInput;
        Throttling = GameManager.Instance.InputController.ThrottleInput;

        //instead of typing the code over and over for each wheel
        foreach (var wheel in carWheels)
        {
            wheel.SteeringAngle = Steering * steeringAngle;
            wheel.MotorTorque = Throttling * motorTorque;
        }
    }
}

