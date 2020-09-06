using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private string steeringInput = "Horizontal";
    [SerializeField] private string throttleInput = "Vertical";

    public float SteeringInput { get; private set; }
    public float ThrottleInput { get; private set; }

    void Start()
    {

    }

    void Update()
    {
        SteeringInput = Input.GetAxis(steeringInput);
        ThrottleInput = Input.GetAxis(throttleInput);
    }
}
